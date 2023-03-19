using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using UnityEngine;
namespace UMI.Network.Server
{
    class UMIServer : MonoBehaviour
    {
        public static UMIServer star;
        public static int maxPlayer { get; private set; }
        public static int port { get; private set; }
        public static Dictionary<int, UMIServerManager> clients = new Dictionary<int, UMIServerManager>();
        public delegate void PacketHandler(int client, UMIPacket packet);
        public static Dictionary<int, PacketHandler> packetHandle;
        public void Awake()
        {
            if (star == null)
            {
                star = this;
            }
            else if (star != this)
            {
                Debug.Log($"UMI::DESTROY()->INSTANCE");
                Destroy(this);
            }
        }
  

        public static UdpClient UMIUDPListener;
        public static TcpListener UMITCPListener;
        private static void initializeServerData()
        {
            for (int i = 1; i <= maxPlayer; i++)
            {
                try
                {
                    clients.Add(i, new UMIServerManager(i));
                }
                catch
                {
                    UMISystem.Log(i + "ERR");
                }
            }
            packetHandle = new Dictionary<int, PacketHandler>()
            {
                //receive
                {   (int)YUMIClientPackets.getRespon , UMIServerHandle.connectReq },
                {   (int)YUMIClientPackets.reqPlayerMovement , UMIServerHandle.playerMovement2D},
                {   (int)YUMIClientPackets.reqDisconnect , UMIServerHandle.disconnectReceive} ,
                {   (int)YUMIClientPackets.reqSpawnPlayer , UMIServerHandle.spawnPlayer} ,
                {   (int)YUMIClientPackets.reqAnimation , UMIServerHandle.playerAnimation} ,
                {   (int)YUMIClientPackets.getConnectLobby , UMIServerHandle.connectLobby} ,
                {   (int)YUMIClientPackets.reqCancelPlayer , UMIServerHandle.cancelPlayer} ,
                {   (int)YUMIClientPackets.reqLeaveRoom , UMIServerHandle.leaveRoom} ,
                {   (int)YUMIClientPackets.reqReady , UMIServerHandle.readyPlayer} ,
                {   (int)YUMIClientPackets.reqCancelReady , UMIServerHandle.readyCancel} ,
            };
            UMISystem.Log("UMI::DATA_SERVER()->LOG->initializeServer");
        }
        public static void Start(int maxPlayerV, int portV)
        {
            maxPlayer = maxPlayerV;
            port = portV;
            UMISystem.Log("UMI::START()->SERVERRUNNING");
            initializeServerData();

            // Start Server
            try
            {
                UMITCPListener = new TcpListener(IPAddress.Any, port);
                UMITCPListener.Start();
                UMITCPListener.BeginAcceptTcpClient(new AsyncCallback(TCPConnectCallback), null);
                UMIUDPListener = new UdpClient(port);
                UMIUDPListener.BeginReceive(UDPReceiveCallback, null);
            }
            catch
            {
                UMISystem.L0g($"IPAddress AllReady!");

            }
            UMISystem.Log($"UMI::PORT->{port}");
        }

        private static void TCPConnectCallback(IAsyncResult result)
        {
            TcpClient client = UMITCPListener.EndAcceptTcpClient(result);
            UMITCPListener.BeginAcceptTcpClient(new AsyncCallback(TCPConnectCallback), null);
            UMISystem.Log($"UMI::CONNECTFROMIPADRESS()->{client.Client.RemoteEndPoint}");
            if(!UMI.Manager.UMIGame.isHeader)
            {
                for (int i = 1; i <= maxPlayer; i++) 
                {
                    if (clients[i].TCP.socket == null)
                    {
                        clients[i].TCP.Connect(client);
                        return;
                    }
                }
                UMISystem.Log($"UMI::STATUSSERVER()->{client.Client.RemoteEndPoint}.FULL");
            }
          
            
        }
        public static void resetNetwork()
        {
            UMIServerSend.leaveRoom(1);
            clients.Clear();
            UMITCPListener.Stop();
            UMITCPListener.Server.Close();
            UMIUDPListener.Close();
        }

        private static void UDPReceiveCallback(IAsyncResult result)
        {
            try
            {
                IPEndPoint clientEndPoint = new IPEndPoint(IPAddress.Any, 0);
                byte[] data = UMIUDPListener.EndReceive(result, ref clientEndPoint);
                UMIUDPListener.BeginReceive(UDPReceiveCallback, null);
                if (data.Length < 4)
                {
                    UMISystem.Log("UMI::STATUSSERVER()->ERRCONNECT");
                    return;
                }
                using (UMIPacket packet = new UMIPacket(data))
                {
                    int CID = packet.ReadInt();

                    if (CID == 0)
                    {
                        UMISystem.Log("UMI::ERRMESSAGE()->CODE_0");
                        return;
                    }
                    if (clients[CID].UDP.endPoint == null)
                    {
                        clients[CID].UDP.Connect(clientEndPoint);
                        return;
                    }
                    if (clients[CID].UDP.endPoint.ToString() == clientEndPoint.ToString())
                    {
                        clients[CID].UDP.HandleData(packet);
                    }
                }
            }
            catch (Exception ex)
            {
                UMISystem.Log($"UMI::ERRSENDUDP()->{ex}");
            }


        }
        public static void SendUdpData(IPEndPoint cEndPoint, UMIPacket packet)
        {
            try
            {
                if (cEndPoint != null)
                {
                    UMIUDPListener.BeginSend(packet.ToArray(), packet.Length(), cEndPoint, null, null);
                }
            }
            catch (Exception ex)
            {
                UMISystem.Log($"UMI::ERRSENDUDP()->{ex}");
            }
        }



    }
}
