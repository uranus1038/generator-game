
using UnityEngine;

namespace UMI.Network.Client
{
    public class UMIClientSend : MonoBehaviour
    {
        #region UMIFUNC SEND TCP & UDP
        private static void SendTCPData(UMIPacket packet)
        {
            packet.WriteLength();
            UMIClient.hInst.TCP.SendData(packet);
        }
        private static void SendUDPData(UMIPacket packet)
        {
            packet.WriteLength();
            UMIClient.hInst.UDP.SendData(packet);
        }
        #endregion
        public static void welcomReceive()
        {
            using (UMIPacket packet = new UMIPacket((int)YUMIClientPackets.welcomeReceived))
            {
                packet.Write(UMIClient.hInst.UID);
                packet.Write("GODU");
                SendUDPData(packet);
            }
        }

        public static void playerMoveMent(Vector3 position)
        {
            using (UMIPacket packet = new UMIPacket((int)YUMIClientPackets.playerMovement))
            {

                packet.Write(position);
                // _Packet.Write(GameManager.players[Client.instance.my_Id].transform.rotation);
                SendUDPData(packet);
            }
        }

        public static void DisconnectSend(int id)
        {
            using (UMIPacket packet = new UMIPacket((int)YUMIClientPackets.disConnectClient))
            {

                packet.Write(id);
                // _Packet.Write(GameManager.players[Client.instance.my_Id].transform.rotation);
                SendTCPData(packet);
            }
        }




    }
}