using UnityEngine;
using System.Net;
using System.Net.Sockets;
namespace UMI.Network.Client
{ 
public class UMIClientHandle : MonoBehaviour
{
    public static void Welcom(UMIPacket packet)
    {
        string MAG = packet.ReadString();
        int UID = packet.ReadInt();
        UMI.Log($"UMI::SERVER_RESPON()->{MAG}");
        UMIClient.hInst.UID = UID;
        UMIClientSend.welcomReceive();
        UMIClient.hInst.UDP.Connect(((IPEndPoint)UMIClient.hInst.TCP.socket.Client.LocalEndPoint).Port);
        UMI.Log(((IPEndPoint)UMIClient.hInst.TCP.socket.Client.LocalEndPoint).Port);
        
    }
        public static void asd(UMIPacket packet)
        {
            string MAG = packet.ReadString();
            int UID = packet.ReadInt();
            UMI.Log($"UMI::SERVER_RESPON()->{MAG}");
        }
        public static void spawnPlayer(UMIPacket packet)
        {
            int UID = packet.ReadInt();
            string userName = packet.ReadString();
            Vector3 position = packet.ReadVector3();
            Quaternion rotation = packet.ReadQuaternion();
            UMIGameManager.hInst.spawnPlayer(UID, userName, position, rotation);
        }
        public static void playerPosition(UMIPacket packet)
    {
        int UID = packet.ReadInt();
        Vector3 position = packet.ReadVector3();
        // Quaternion rotation = Packet.ReadQuaternion();
        UMIGameManager.players[UID].transform.position = position;
        //   GameManager.players[UID].transform.rotation = rotation;

    }

    public static void DisconnectReceive(UMIPacket packet)
    {
        int UID = packet.ReadInt();
        Destroy(UMIGameManager.players[UID].gameObject);
        UMIGameManager.players.Remove(UID);
        UMI.Log(UID);

    }
}
}