using System;
using System.Numerics;
namespace UMI.Network.Server
{
    class UMIServerHandle
    {
        public static void connectReq(int client, UMIPacket packet)
        {
            int UID = packet.ReadInt();
            string userName = packet.ReadString();
            UMIServer.clients[UID].SendIntoGame(userName);
           
            UMI.Log($"UMI::CONNEC()->LOG->connected successfully {UMIServer.clients[client].TCP.socket.Client.RemoteEndPoint} and is now player {UID}");
            if (client != UID)
            {
                UMI.Log($"Player {UID} id : {client}");
            }
        }
        public static void spawnPlayer(int client, UMIPacket packet)
        {
            int UID = packet.ReadInt();
            string userName = packet.ReadString();
            UMIServer.clients[UID].SendIntoGame(userName);
        }
        public static void playerMovement2D(int fClient, UMIPacket packet)
        {
            try
            {
                Vector3 position = packet.ReadVector3();
                UMIServer.clients[fClient].player.resPosition(position);
            }catch
            {
                UMI.L0g("ERRSEND()->LOG->NOTPLAYER");
            }
        }
        public static void disconnectReceive(int fClient, UMIPacket packet)
        {
            int id = packet.ReadInt();
            UMIServerSend.disconnectSend(id);
        }

        public static void playerAnimation(int fClient, UMIPacket packet)
        {
            int actor = packet.ReadInt();
            UMIServerSend.playerAnimation(fClient, actor);
        }


    }
}