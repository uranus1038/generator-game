using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System;
namespace UMI.Network.Client
{
    public class UMIClientManager : MonoBehaviour
    {
        public static UMIClientManager star;
        public static int dataBufferSize = 4096;
        public string IP = "127.0.0.1";
        public int port =8080;
        public int UID = 0;
        public UMITCP TCP;
        public UMIUDP UDP;
        private bool isConnected = false;
        private delegate void packetHandler(UMIPacket packet);
        private static Dictionary<int, packetHandler> packetHandlers;
        private void Awake()
        {
            if (star == null)
            {
                star = this;
            }
            else if (star != this)
            {
                UMISystem.Log($"UMI::DESTROY()->INSTANCE");
                Destroy(this);
            }
            this.TCP = new UMITCP();
            this.UDP = new UMIUDP();
        }         
        
        // Quit Gmae 
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
        // TCP
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
                socket.BeginConnect(star.IP, star.port, ConnectCallback, socket);
            }
            private void ConnectCallback(IAsyncResult result)
            {
                if (!socket.Connected)
                {
                    UMISystem.Log("UMI::SERVERSTATUS()->DOWN");
                    UMISystem.Log("UMI::SERVER_RESPON_STATUS()->LOG->CODE-400");
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
                        stream.BeginWrite(packet.ToArray(), 0, packet.Length(), null, null);
                    }
                }
                catch (Exception ex)
                {
                    UMISystem.Log($"UMI::ERRSEND()->{ex}");
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

                        star.Disconnect();
                        UMIClientSend.DisconnectSend(UMIClientManager.star.UID);
                        return;
                    }
                    byte[] data = new byte[byteLength];
                    Array.Copy(receiveBuffer, data, byteLength);

                    receiveData.Reset(HandleData(data));
                    stream.BeginRead(receiveBuffer, 0, dataBufferSize, ReceiveCallback, null);
                }
                catch
                {
                    UMIClientSend.DisconnectSend(UMIClientManager.star.UID);
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
                    UMIThreadManager.UMIExecuteOnMainThread(() =>
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
                star.Disconnect();
                this.stream = null;
                this.receiveData = null;
                this.receiveBuffer = null;
                this.socket = null;
            }

        }
        // UDP
        public class UMIUDP
        {
            public UdpClient socket;
            public IPEndPoint endPoint;
            public UMIUDP()
            {
                endPoint = new IPEndPoint(IPAddress.Parse(star.IP), star.port);
            }
            public void Connect(int localPort)
            {
                socket = new UdpClient(localPort);
                socket.Connect(endPoint);
                socket.BeginReceive(ReceiveCallback, null);

                using (UMIPacket packet = new UMIPacket())
                {
                    SendData(packet);
                }

            }
            public void SendData(UMIPacket packet)
            {
                try
                {
                    packet.InsertInt(star.UID);
                    if (this.socket != null)
                    {
                        socket.BeginSend(packet.ToArray(), packet.Length(), null, null);
                    }
                }
                catch (Exception ex)
                {
                    UMISystem.Log($"UMI::ERRSEND()->{ex}");
                }
            }
            private void ReceiveCallback(IAsyncResult result)
            {
                try
                {
                    byte[] data = socket.EndReceive(result, ref endPoint);
                    socket.BeginReceive(ReceiveCallback, null);
                    if (data.Length < 4)
                    {
                        UMIClientSend.DisconnectSend(UMIClientManager.star.UID);
                        star.Disconnect();
                        return;
                    }
                    HandleData(data);
                }
                catch
                {
                    UMIClientSend.DisconnectSend(UMIClientManager.star.UID);
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

                UMIThreadManager.UMIExecuteOnMainThread(() =>
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
                star.Disconnect();
                this.endPoint = null;
                this.socket = null;
            }

        }
        // Discoonect from server 
        private void Disconnect()
        {
            if (isConnected)
            {

                this.isConnected = false;
                this.TCP.socket.Close();
                //udp.Socket.Close();
                UMISystem.Log($"UMI::DISCONNECT()");
            }
        }
        // Receive from server
        private void InitializeClientData()
        {
            packetHandlers = new Dictionary<int, packetHandler>()
        {
                //Receive respon 
           { (int)YUMIServerPackets.resServer ,UMIClientHandle.connectRespon},
           { (int)YUMIServerPackets.resSpawnPlayer ,UMIClientHandle.spawnPlayer},
           { (int)YUMIServerPackets.resPlayerPosition ,UMIClientHandle.playerPosition2D},
           { (int)YUMIServerPackets.resDisconnect ,UMIClientHandle.disconnectGetRespon},
           { (int)YUMIServerPackets.resAnimation ,UMIClientHandle.playerAnimation},
        };
        }
    }
}