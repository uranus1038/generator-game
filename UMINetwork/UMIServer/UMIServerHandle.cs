using System;
using System.Numerics;
namespace UMI.Network.Server
{
    class UMIServerHandle
    {
        public static void connectReq(int client, UMIPacket packet)
        {
            int UID = packet.ReadInt();
            string txt = packet.ReadString();
            UMIServer.clients[UID].SendIntoGame(txt);
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
            Vector3 position = packet.ReadVector3();
            UMIServer.clients[fClient].player.resPosition(position);
        }
        public static void disconnectReceive(int _fClient, UMIPacket packet)
        {
            int _id = packet.ReadInt();
            Console.WriteLine(_id);
            UMIServerSend.disconnectSend(_id);
        }



    }
}