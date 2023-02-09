using System;
using System.Numerics;
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
        public static void Welcome(int _toClient, string _msg)
        {
            using (UMIPacket _packet = new UMIPacket((int)YUMIServerPackets.welcome))
            {
                _packet.Write(_msg);
                _packet.Write(_toClient);

                SendTCPData(_toClient, _packet);
                
            }
        }
        public static void low(int _toClient, string _msg)
        {
            using (UMIPacket _packet = new UMIPacket((int)YUMIServerPackets.welcome))
            {
                _packet.Write(_msg);
                _packet.Write(_toClient);

                SendTCPData(_toClient, _packet);

            }
        }
        public static void spawnPlayer(int toClient, UMIPlayer player)
        {
            using (UMIPacket packet = new UMIPacket((int)YUMIServerPackets.spawnPlayer))
            {
                packet.Write(player.UID);
                packet.Write(player.userName);
                packet.Write(player.position);
                packet.Write(player.rotation);

                SendTCPData(toClient, packet);

            }
        }
        public static void playerPosition(UMIPlayer player)
        {
            using (UMIPacket packet = new UMIPacket((int)YUMIServerPackets.playerPosition))
            {
                packet.Write(player.UID);
                packet.Write(player.position);
                


                SendUDPDataX(player.UID, packet);
            }
        }

        public static void disconnectSend(int client)
        {
            using (UMIPacket packet = new UMIPacket((int)YUMIServerPackets.disConnectSv))
            {

                packet.Write(client);

                SendUDPDataX(client, packet);
            }
        }





    }
}