
using UnityEngine;

namespace UMI.Network.Client
{
    public class UMIClientSend : MonoBehaviour
    {
        #region UMIFUNC SEND TCP & UDP
        private static void SendTCPData(UMIPacket packet)
        {
            packet.WriteLength();
            UMIClientManager.star.TCP.SendData(packet);
        }
        private static void SendUDPData(UMIPacket packet)
        {
            packet.WriteLength();
            UMIClientManager.star.UDP.SendData(packet);
        }
        #endregion
        public static void requastConnect()
        {
            using (UMIPacket packet = new UMIPacket((int)YUMIClientPackets.getRespon))
            {
                packet.Write(UMIClientManager.star.UID);
                packet.Write("GODU");
                SendTCPData(packet);
            }
        }
        public static void reqPlayerMoveMent(Vector3 position)
        {
            using (UMIPacket packet = new UMIPacket((int)YUMIClientPackets.reqPlayerMovement))
            {
                packet.Write(position);
                // _Packet.Write(GameManager.players[Client.instance.my_Id].transform.rotation);
                SendUDPData(packet);
            }
        }
        public static void DisconnectSend(int id)
        {
            using (UMIPacket packet = new UMIPacket((int)YUMIClientPackets.reqDisconnect))
            {
                packet.Write(id);
                // _Packet.Write(GameManager.players[Client.instance.my_Id].transform.rotation);
                SendTCPData(packet);
            }
        }
        public static void reqCreatePlayer()
        {
            using (UMIPacket packet = new UMIPacket((int)YUMIClientPackets.reqSpawnPlayer))
            {
                packet.Write(UMIClientManager.star.UID);
                packet.Write("GODU");
                SendTCPData(packet);
            }
        }
    }
}