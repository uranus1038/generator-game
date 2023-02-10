﻿using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Numerics;

namespace UMI.Network.Server
{
    class UMIServerManager
    { 
        public int UID;
        public UMITCP TCP;
        public UMIUDP UDP;
        public static int dataBufferSize = 4096;
        public UMIPlayer player;
        public UMIServerManager(int CUID)
        {
            this.UID = CUID;
            this.TCP = new UMITCP(UID);
            this.UDP = new UMIUDP(UID);
        }
        public class UMITCP { 
            public TcpClient socket;
            public UMIPacket receiveData;
            private readonly int UID;
            private byte[] receiveBuffer;
            private NetworkStream stream;


            public UMITCP(int UID)
            {
                this.UID = UID;
            }
            public void Connect(TcpClient socket)
            {
                this.socket = socket;
                socket.ReceiveBufferSize = dataBufferSize;
                socket.SendBufferSize = dataBufferSize;

                stream = this.socket.GetStream();
                receiveBuffer = new byte[dataBufferSize];
                stream.BeginRead(receiveBuffer, 0, dataBufferSize, ReceiveCallback, null);
                receiveData = new UMIPacket();
                UMIServerSend.serverOn(this.UID, "SERVER_RESPON_STATUS()->LOG->CODE-200");
            }
            public void SendData(UMIPacket packet)
            {
                try
                {
                    if (this.socket != null)
                    {
                        this.stream.BeginWrite(packet.ToArray(), 0, packet.Length(), null, null);
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
                    if (byteLength <= 0)
                    {
                        //Console.WriteLine(_byte_Length);
                        UMIServer.clients[this.UID].Disconnect();
                        return;
                    }
                    byte[] data = new byte[byteLength];
                    Array.Copy(receiveBuffer, data, byteLength);

                    receiveData.Reset(HandleData(data));
                    stream.BeginRead(receiveBuffer,
                        0, dataBufferSize, ReceiveCallback, null);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("UMI::ERRSEND()->"+ex);
                    UMIServer.clients[this.UID].Disconnect();
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
                            int packetUID = packet.ReadInt();
                            UMIServer.packetHandle[packetUID](this.UID, packet);
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

            public void Disconnect()
            {
                this.socket.Close();
                this.stream = null;
                this.receiveBuffer = null;
                this.receiveData = null;
                this.socket = null;
            }

        }

        public class UMIUDP
        {
            public IPEndPoint endPoint;

            private int UID;
            public UMIUDP(int UID)
            {
                this.UID = UID;
            }
            public void Connect(IPEndPoint endPoint)
            {
                this.endPoint = endPoint;
            }
            public void SendData(UMIPacket packet)
            {
                UMIServer.SendUdpData(endPoint, packet);
            }
            public void HandleData(UMIPacket packetData)
            {
                int packetLength = packetData.ReadInt();
                byte[] packetBytes = packetData.ReadBytes(packetLength);

                UMIThreadManager.UMIExecuteOnMainThread(() =>
                {
                    using (UMIPacket packet = new UMIPacket(packetBytes))
                    {
                        int packetUID = packet.ReadInt();
                        UMIServer.packetHandle[packetUID](this.UID, packet);
                    }
                });

            }
            public void Disconnect()
            {
                endPoint = null;
            }

        }
        public void Disconnect()
        {
            UMI.Log($"UMI::DISCONNECT()->{TCP.socket.Client.RemoteEndPoint}");
            player = null;
           
            TCP.Disconnect();
            UDP.Disconnect();
        }

        public void SendIntoGame(string playerName)
        {
            UMI.Log("ok");
            player = new UMIPlayer(this.UID, playerName, new Vector3(0, 0, 0));
            foreach (UMIServerManager client in UMIServer.clients.Values)
            {
                if (client.player != null)
                {
                    if (client.UID != this.UID)
                    {
                        UMIServerSend.spawnPlayer(this.UID, client.player);
                    }

                }
            }
            foreach (UMIServerManager client in UMIServer.clients.Values)
            {
                if (client.player != null)
                {
                    UMIServerSend.spawnPlayer(client.UID, this.player);

                }
            }
        }
    }
}