using System;
namespace UMI.Network.Server
{
    public class UMIServerSend
    {
        #region UMIFUNC TCP & UDP Sendeer
        private static void SendTCPData(int toClient, UMIPacket packet)
        {
            packet.WriteLength();
            UMIServer.clients[toClient].TCP.SendData(packet);
        }
        private static void SendUDPData(int toClient, UMIPacket packet)
        {
            packet.WriteLength();
            UMIServer.clients[toClient].UDP.SendData(packet);
        }
        //Send tcp data to all users
        private static void SendTCPDataX(UMIPacket packet)
        {
            packet.WriteLength();
            for (int i = 1; i <= UMIServer.maxPlayer; i++)
            {
                UMIServer.clients[i].TCP.SendData(packet);
            }
        }
        private static void SendTCPDataX(int exceptClient, UMIPacket packet)
        {
            packet.WriteLength();
            for (int i = 1; i <= UMIServer.maxPlayer; i++)
            {
                if (i != exceptClient)
                {
                    UMIServer.clients[i].TCP.SendData(packet);
                }
            }
        }
        //Send udp data to all users
        private static void SendUDPDataX(UMIPacket packet)
        {
            packet.WriteLength();
            for (int i = 1; i <= UMIServer.maxPlayer; i++)
            {
                UMIServer.clients[i].UDP.SendData(packet);
            }
        }
        private static void SendUDPDataX(int exceptClient, UMIPacket packet)
        {
            packet.WriteLength();
            for (int i = 1; i <= UMIServer.maxPlayer; i++)
            {
                if (i != exceptClient)
                {
                    UMIServer.clients[i].UDP.SendData(packet);
                }
            }
        }
        #endregion
        public static void serverOn(int toClient, string msg)
        {
            using (UMIPacket packet = new UMIPacket((int)YUMIServerPackets.resServer))
            {
                packet.Write(msg);
                packet.Write(toClient);
                SendTCPData(toClient, packet);
            }
        }
        public static void spawnPlayer(int toClient, UMIPlayer player)
        {
            using (UMIPacket packet = new UMIPacket((int)YUMIServerPackets.resSpawnPlayer))
            {
                packet.Write(player.UID);
                packet.Write(player.userName);
                packet.Write(player.position);
                packet.Write(player.rotation);
                SendTCPData(toClient, packet);
            }
        }
        public static void playerPosition2D(UMIPlayer player)
        {
            using (UMIPacket packet = new UMIPacket((int)YUMIServerPackets.resPlayerPosition))
            {
                packet.Write(player.UID);
                packet.Write(player.position);
                SendUDPDataX(packet);
            }
        }
        public static void disconnectSend(int client)
        {
            using (UMIPacket packet = new UMIPacket((int)YUMIServerPackets.resDisconnect))
            {
                packet.Write(client);
                SendUDPDataX(client, packet);
            }
        }





    }
}