using System;
using System.Numerics;
namespace UMI.Network.Server
{
    class UMIServerHandle
    {
        public static void welcomReceived(int client, UMIPacket packet)
        {
            UMI.Log("Success Red");
            int UID = packet.ReadInt();
            string txt = packet.ReadString();

            UMI.Log($"UMI::CONNEC()->LOG->connected successfully {UMIServer.clients[client].TCP.socket.Client.RemoteEndPoint} and is now player {UID}");
            if (client != UID)
            {
                UMI.Log($"Player {UID} id : {client}");
            }
           UMIServer.clients[UID].SendIntoGame(txt);
        }
        public static void playerMovement(int _fClient, UMIPacket packet)
        {
            Vector3 _position = packet.ReadVector3();


            UMIServer.clients[_fClient].player.setInput(_position);
            

        }
        public static void disconnectReceive(int _fClient, UMIPacket packet)
        {

            int _id = packet.ReadInt();
            Console.WriteLine(_id);
            UMIServerSend.disconnectSend(_id);


        }



    }
}