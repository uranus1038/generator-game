using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
namespace UMI.Network.Server
{
    class UMIServer
    {
        public static int maxPlayer { get; private set; }
        public static int port { get; private set; }
        public static Dictionary<int, UMIClientServer> clients = new Dictionary<int, UMIClientServer>();
        public delegate void PacketHandler(int client, UMIPacket packet);
        public static Dictionary<int, PacketHandler> packetHandle;


        private static UdpClient UMIUDPListener;
        private static TcpListener UMITCPListener;
       
        public static void Start(int maxPlayerV, int portV)
        {
            maxPlayer = maxPlayerV;
            port = portV;
            UMI.Log("UMI::START()->SERVERRUNNING");
            initializeServerData();

            // Start Server
            UMITCPListener = new TcpListener(IPAddress.Any, port);
            UMITCPListener.Start();
            UMITCPListener.BeginAcceptTcpClient(new AsyncCallback(TCPConnectCallback), null);


            UMIUDPListener = new UdpClient(port);
            UMIUDPListener.BeginReceive(UDPReceiveCallback, null);

            UMI.Log($"UMI::PORT->{port}");
        }

        private static void TCPConnectCallback(IAsyncResult result)
        {
            TcpClient client = UMITCPListener.EndAcceptTcpClient(result);
            UMITCPListener.BeginAcceptTcpClient(new AsyncCallback(TCPConnectCallback), null);
            UMI.Log($"UMI::CONNECTFROMIPADRESS()->{client.Client.RemoteEndPoint}");

            for (int i = 1; i <= maxPlayer; i++)
            {

                if (clients[i].TCP.socket == null)
                {
                    clients[i].TCP.Connect(client);
                    return;
                }
            }
            UMI.Log($"UMI::STATUSSERVER()->{client.Client.RemoteEndPoint}.FULL");
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
                    UMI.Log("UMI::STATUSSERVER()->ERRCONNECT");
                    return;
                }
                using (UMIPacket packet = new UMIPacket(data))
                {
                    int CID = packet.ReadInt();
                    if (CID == 0)
                    {
                        UMI.Log("UMI::ERRMESSAGE()->CODE_0");
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
                UMI.Log($"UMI::ERRSENDUDP()->{ex}");


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
                UMI.Log($"UMI::ERRSENDUDP()->{ex}");
            }
        }
        private static void initializeServerData()

        {
            for (int i = 1; i <= maxPlayer; i++)
            {
                clients.Add(i, new UMIClientServer(i));
            }
            packetHandle = new Dictionary<int, PacketHandler>()
            {
                //receive
                {   (int)YUMIClientPackets.welcomeReceived , UMIServerHandle.welcomReceived },
                {   (int)YUMIClientPackets.playerMovement , UMIServerHandle.playerMovement},
                {   (int)YUMIClientPackets.disConnectClient , UMIServerHandle.disconnectReceive}

            };
            UMI.Log("initializeServer");
        }


    }
}
