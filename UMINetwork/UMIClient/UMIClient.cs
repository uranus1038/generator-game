using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System;
namespace UMI.Network.Client
{
    public class UMIClient : MonoBehaviour
    {
        public static UMIClient hInst;
        public static int dataBufferSize = 4096;
        public string IP = "127.0.0.1";
        public int port = 8000;
        public int UID = 0;
        public UMITCP TCP;
        public UMIUDP UDP;
        private bool isConnected = false;
        private delegate void packetHandler(UMIPacket packet);
        private static Dictionary<int, packetHandler> packetHandlers;
        private void Awake()
        {
            if (hInst == null)
            {
                hInst = this;
            }
            else if (hInst != this)
            {
                UMI.Log($"UMI::DESTROY()->INSTANCE");
                Destroy(this);
            }
            
            
        }
        private void Start()
        {
            this.TCP = new UMITCP();
            this.UDP = new UMIUDP();
            
         
        }
        public void OnApplicationQuit()
        {
            UMIClientSend.DisconnectSend(this.UID);
            Disconnect();
           
        }
        public void connectServer()
        {

            InitializeClientData();
            this.isConnected = true;
            this.TCP.Connect();
            
        }
        public class UMITCP
        {
            
            public TcpClient socket;
            private UMIPacket receiveData;
            private NetworkStream stream;
            private byte[] receiveBuffer;
            private float float_1; 
      
          
         
          
            public void Connect()
            {
               
                socket = new TcpClient { ReceiveBufferSize = dataBufferSize, SendBufferSize = dataBufferSize };

                receiveBuffer = new byte[dataBufferSize];
                socket.BeginConnect(hInst.IP, hInst.port, ConnectCallback, socket);

            }
            private void ConnectCallback(IAsyncResult result)
            {
                if (!socket.Connected)
                {
                    
                    UMI.Log("UMI::SERVERSTATUS()->DOWN");
                    return;
                }

                
                stream = socket.GetStream();
                receiveData = new UMIPacket();
                stream.BeginRead(receiveBuffer, 0, dataBufferSize, ReceiveCallback, null);
            }

            public void SendData(UMIPacket packet)
            {
                try
                {
                    if (this.socket != null)
                    {
                        UMI.Log("success write");
                        stream.BeginWrite(packet.ToArray(), 0, packet.Length(), null, null);
                    }
                }
                catch (Exception ex)
                {
                    UMI.Log($"UMI::ERRSEND()->{ex}");
                }
            }
            private void ReceiveCallback(IAsyncResult result)
            {
                try
                {
                    int byteLength = stream.EndRead(result);
                    // Data < 4
                    if (byteLength <= 0)
                    {

                        hInst.Disconnect();
                        UMIClientSend.DisconnectSend(UMIClient.hInst.UID);
                        return;
                    }
                    byte[] data = new byte[byteLength];
                    Array.Copy(receiveBuffer, data, byteLength);

                    receiveData.Reset(HandleData(data));
                    stream.BeginRead(receiveBuffer, 0, dataBufferSize, ReceiveCallback, null);
                }
                catch
                {
                    UMIClientSend.DisconnectSend(UMIClient.hInst.UID);
                    Disconnect();
                }
            }

            private bool HandleData(byte[] data)
            {
                int packetLenght = 0;

                receiveData.SetBytes(data);
                if (receiveData.UnreadLength() >= 4)
                {
                    packetLenght = receiveData.ReadInt();
                    if (packetLenght <= 0)
                    {
                        return true;
                    }
                }
                while (packetLenght > 0 && packetLenght <= receiveData.UnreadLength())
                {
                    byte[] packetByte = receiveData.ReadBytes(packetLenght);
                    UMIThreadManager.umiExecuteOnMainThread(() =>
                    {
                        using (UMIPacket packet = new UMIPacket(packetByte))
                        {
                            int packetId = packet.ReadInt();
                            packetHandlers[packetId](packet);
                        }

                    });
                    packetLenght = 0;
                    if (receiveData.UnreadLength() >= 4)
                    {
                        packetLenght = receiveData.ReadInt();
                        if (packetLenght <= 0)
                        {
                            return true;
                        }
                    }
                }
                if (packetLenght <= 1)
                {
                    return true;
                }
                return false;
            }

            private void Disconnect()
            {
                hInst.Disconnect();
                this.stream = null;
                this.receiveData = null;
                this.receiveBuffer = null;
                this.socket = null;
            }

        }

        public class UMIUDP
        {
            public UdpClient socket;
            public IPEndPoint endPoint;
            public UMIUDP()
            {
                endPoint = new IPEndPoint(IPAddress.Parse(hInst.IP), hInst.port);
            }
            public void Connect(int localPort)
            {
                socket = new UdpClient(localPort);
                socket.Connect(endPoint);
                socket.BeginReceive(umiReceiveCallback, null);

                using (UMIPacket packet = new UMIPacket())
                {
                    SendData(packet);
                }

            }
            public void SendData(UMIPacket packet)
            {
                try
                {
                    packet.InsertInt(hInst.UID);
                    if (this.socket != null)
                    {
                        socket.BeginSend(packet.ToArray(), packet.Length(), null, null);
                    }
                }
                catch (Exception ex)
                {
                    UMI.Log($"UMI::ERRSEND()->{ex}");
                }
            }
            private void umiReceiveCallback(IAsyncResult result)
            {
                try
                {
                    byte[] data = socket.EndReceive(result, ref endPoint);
                    socket.BeginReceive(umiReceiveCallback, null);
                    if (data.Length < 4)
                    {
                        UMIClientSend.DisconnectSend(UMIClient.hInst.UID);
                        hInst.Disconnect();
                        return;
                    }
                    HandleData(data);
                }
                catch
                {
                    UMIClientSend.DisconnectSend(UMIClient.hInst.UID);
                    Disconnect();
                }
            }
            private void HandleData(byte[] data)
            {
                using (UMIPacket packet = new UMIPacket(data))
                {
                    int packetLength = packet.ReadInt();
                    data = packet.ReadBytes(packetLength);
                }

                UMIThreadManager.umiExecuteOnMainThread(() =>
                {
                    using (UMIPacket packet = new UMIPacket(data))
                    {
                        int packetId = packet.ReadInt();
                        packetHandlers[packetId](packet);
                    }
                });
            }



            private void Disconnect()
            {
                hInst.Disconnect();
                this.endPoint = null;
                this.socket = null;
            }

        }
        private void Disconnect()
        {
            if (isConnected)
            {

                this.isConnected = false;
                this.TCP.socket.Close();
                //udp.Socket.Close();
                UMI.Log($"UMI::DISCONNECT()");
            }
        }
        private void InitializeClientData()
        {
            packetHandlers = new Dictionary<int, packetHandler>()
        {
           { (int)YUMIServerPackets.welcome ,UMIClientHandle.Welcom},
           { (int)YUMIServerPackets.spawnPlayer ,UMIClientHandle.spawnPlayer},
           { (int)YUMIServerPackets.playerPosition ,UMIClientHandle.playerPosition},
           { (int)YUMIServerPackets.disConnectSv ,UMIClientHandle.DisconnectReceive},
           { (int)YUMIServerPackets.hello , UMIClientHandle.asd},

        };

        }

    }
}