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
            UMI.Manager.UMIGame.Connected = false;
            UMI.Manager.UMIGame.isFull = false;
            if (UMI.Manager.UMIGame.connectLobby)
            {
                UMISystem.L0g("Connect");
                UMIClientSend.requastConnectLobby();
                UMI.Manager.UMIGame.connectLobby = false;
            }
            UMIClientManager.star.UDP.Connect(((IPEndPoint)UMIClientManager.star.TCP.socket.Client.LocalEndPoint).Port);
        }
        public static void spawnPlayer(UMIPacket packet)
        {
            int UID = packet.ReadInt();
            string userName = packet.ReadString();
            Vector3 position = packet.ReadVector3();
            Quaternion rotation = packet.ReadQuaternion();
            UMIGameManager.star.spawnPlayer(UID, userName, position, rotation);
        }
        public static void spawnPlayerLobby(UMIPacket packet)
        {
            int UID = packet.ReadInt();
            string userName = packet.ReadString();
            string gender = packet.ReadString();
            Room.star.spawnLobby(UID, userName, gender);
        }
        public static void playerPosition2D(UMIPacket packet)
        {
            int UID = packet.ReadInt();
            Vector3 position = packet.ReadVector3();
            //Quaternion rotation = Packet.ReadQuaternion();
            UMIGameManager.players[UID].transform.position = position;

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

        }

        public static void leaveRoom(UMIPacket packet)
        {
            int clientUID = packet.ReadInt();
            Room.star.roomManager(clientUID);
        }
        public static void isMax(UMIPacket packet)
        {
            UMISystem.L0g("send");
            int num = packet.ReadInt();
            if (UMIClientManager.star.UID == num)
            {
                UMISystem.L0g("SERVER IS FULL");
                UMIClientManager.star.TCP.socket.Close();
                UMI.Manager.UMIGame.isFull = false;
            }
        }
    }
}