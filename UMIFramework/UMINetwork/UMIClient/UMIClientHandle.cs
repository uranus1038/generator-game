using UnityEngine;
using System.Net;
namespace UMI.Network.Client
{
    public class UMIClientHandle : MonoBehaviour
    {
        public static void connectRespon(UMIPacket packet)
        {
            string MAG = packet.ReadString();
            int UID = packet.ReadInt();
            UMISystem.Log($"UMI::SERVER_RESPON()->{MAG}");
            UMIClientManager.star.UID = UID;
            UMI.Manager.UMIGame.isFull = false;
            UMI.Manager.UMIGame.Connected = false;
            if (UMI.Manager.UMIGame.connectLobby)
            {
                UMISystem.L0g("Connect");
                UMIClientSend.requastConnectLobby();
                UMI.Manager.UMIGame.connectLobby = false;
            }
            try
            {

            UMIClientManager.star.UDP.Connect(((IPEndPoint)UMIClientManager.star.TCP.socket.Client.LocalEndPoint).Port);
            }catch
            {
                UMISystem.L0g("LocalEndPoint NULL");
            }
        }
        public static void spawnPlayerLobby(UMIPacket packet)
        {
            int UID = packet.ReadInt();
            string userName = packet.ReadString();
            string gender = packet.ReadString();
            bool isReady = packet.ReadBool();
            Room.star.spawnLobby(UID, userName, gender , isReady);
        }
        public static void playerPosition2D(UMIPacket packet)
        {
            int UID = packet.ReadInt();
            Vector3 position = packet.ReadVector3();
            //Quaternion rotation = Packet.ReadQuaternion();
            try
            {

             UMIGameManager.players[UID].transform.position = position;
            }
            catch
            {
                UMISystem.L0g("Loading");
                UMISystem.L0g("Loading");
            }

            //GameManager.players[UID].transform.rotation = rotation;
        }
        public static void playerAnimation(UMIPacket packet)
        {
            int UID = packet.ReadInt();
            int actor = packet.ReadInt();
            UMIGameManager.players[UID].GetComponent<CharacterControl>().OnAnimationPlayerController(actor);
        }
        public static void disconnectGetRespon(UMIPacket packet)
        {
            try
            {
                int UID = packet.ReadInt();
                Destroy(UMIGameManager.players[UID].gameObject);
                UMIGameManager.players.Remove(UID);
                UMISystem.Log(UID);
            }
            catch
            {
                UMISystem.Log("ERRSEND()->LOG->NOTPLAYER");
            }

        }
        public static void cancelPlayerRespon(UMIPacket packet)
        {
            int clientUID = packet.ReadInt();
            Room.star.OnCancelPlayer(clientUID , "kicked");
        }
        public static void leaveRoom(UMIPacket packet)
        {
            int clientUID = packet.ReadInt();
            Room.star.roomManager(clientUID);
        }
        public static void readyPlayerRespon(UMIPacket packet)
        {
            int clientUID = packet.ReadInt();
            Room.star.OnReady(clientUID);
        }
        public static void cancelReadyRespon(UMIPacket packet)
        {
            int clientUID = packet.ReadInt();
            Room.star.OnCancel(clientUID);
        }
        public static void getStart(UMIPacket packet)
        {
            Room.star.OnStart();
        }


    }
}