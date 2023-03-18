using UMI.Manager.Data; 
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
        private static void sendTCPDataALL(UMIPacket packet)
        {
            packet.WriteLength();
            for (int i = 1; i <= UMIServer.maxPlayer; i++)
            {
                UMIServer.clients[i].TCP.SendData(packet);
            }
        }
        private static void sendTCPDataExceptClient(int exceptClient, UMIPacket packet)
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
        private static void sendUDPDataALL(UMIPacket packet)
        {
            packet.WriteLength();
            for (int i = 1; i <= UMIServer.maxPlayer; i++)
            {
                UMIServer.clients[i].UDP.SendData(packet);
            }
        }
        private static void sendUDPDataExceptClient(int exceptClient, UMIPacket packet)
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
        public static void spawnPlayerLobby(int toClient, UMIPlayerData Data)
        {
            using (UMIPacket packet = new UMIPacket((int)YUMIServerPackets.resSpawnPlayerLobby))
            {
                packet.Write(Data.UID);
                packet.Write(Data.userName);
                packet.Write(Data.gender);
                SendTCPData(toClient, packet);
            }
        }
        public static void playerPosition2D(UMIPlayer player)
        {
            using (UMIPacket packet = new UMIPacket((int)YUMIServerPackets.resPlayerPosition))
            {
                packet.Write(player.UID);
                packet.Write(player.position);
                sendUDPDataExceptClient(player.UID,packet);
            }
        }
        public static void playerAnimation(int UID,int actor)
        {
            using (UMIPacket packet = new UMIPacket((int)YUMIServerPackets.resAnimation))
            {
                packet.Write(UID);
                packet.Write(actor);
                sendUDPDataExceptClient(UID, packet);
            }
        }
        public static void disconnectSend(int client)
        {
            using (UMIPacket packet = new UMIPacket((int)YUMIServerPackets.resDisconnect))
            {
                packet.Write(client);
                sendUDPDataExceptClient(client, packet);
            }
        }

        public static void cancelPlayerSend(int client)
        {
            using (UMIPacket packet = new UMIPacket((int)YUMIServerPackets.resCancelPlayer))
            {
                packet.Write(client);
                sendTCPDataALL( packet);
            }
        }
        public static void leaveRoom(int client)
        {
            using (UMIPacket packet = new UMIPacket((int)YUMIServerPackets.resLeaveRoom))
            {
                packet.Write(client);
                sendTCPDataExceptClient(client, packet);
            }
        }
        public static void readyPlayerSend(int client)
        {
            using (UMIPacket packet = new UMIPacket((int)YUMIServerPackets.resReady))
            {
                packet.Write(client);
                sendTCPDataALL(packet);
            }
        }
        public static void readyCancelSend(int client)
        {
            using (UMIPacket packet = new UMIPacket((int)YUMIServerPackets.resCancelReady))
            {
                packet.Write(client);
                sendTCPDataALL(packet);
            }
        }


    }
}