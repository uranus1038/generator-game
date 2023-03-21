
using UnityEngine;

namespace UMI.Network.Client
{
    public class UMIClientSend : MonoBehaviour
    {
        #region UMIFUNC SEND TCP & UDP
        private static void sendTCPData(UMIPacket packet)
        {
            packet.WriteLength();
            UMIClientManager.star.TCP.SendData(packet);
        }
        private static void sendUDPData(UMIPacket packet)
        {
            packet.WriteLength();
            UMIClientManager.star.UDP.SendData(packet);
        }
        private static void sendUDPData(int UID, UMIPacket packet)
        {
            packet.WriteLength();
            UMIClientManager.star.UDP.SendData(packet);
        }
        #endregion
        public static void OnJoinGame(string Discription, int nMission)
        {
            using (UMIPacket packet = new UMIPacket((int)YUMIClientPackets.reqSpawnPlayer))
            {
                UMI.UMISystem.L0g("Send! ->");
                packet.Write(UMIClientManager.star.UID);
                packet.Write(UMI.Network.API.UMIData.getStringPlayerData(1));
                packet.Write(UMI.Network.API.UMIData.getStringPlayerData(2));
                packet.Write((nMission));
                sendTCPData(packet);
            }
        }
        public static void requastConnectLobby()
        {
            using (UMIPacket packet = new UMIPacket((int)YUMIClientPackets.getConnectLobby))
            {
                UMISystem.L0g("SEND");
                packet.Write(UMIClientManager.star.UID);
                packet.Write(UMI.Network.API.UMIData.getStringPlayerData(1));
                packet.Write(UMI.Network.API.UMIData.getStringPlayerData(2));
                sendTCPData(packet);
            }
        }
        public static void reqPlayerMoveMent(Vector3 position)
        {
            //using (UMIPacket packet = new UMIPacket((int)YUMIClientPackets.reqPlayerMovement))
            //{
            //    packet.Write(position);
            //    // _Packet.Write(GameManager.players[Client.instance.my_Id].transform.rotation);
            //    sendUDPData(packet);
            //}
        }
        public static void reqAnimation(int actor)
        {
            //using (UMIPacket packet = new UMIPacket((int)YUMIClientPackets.reqAnimation))
            //{
            //    packet.Write(actor);
            //    // _Packet.Write(GameManager.players[Client.instance.my_Id].transform.rotation);
            //    sendUDPData(packet);
            //}
        }
        public static void DisconnectSend(int id)
        {
            using (UMIPacket packet = new UMIPacket((int)YUMIClientPackets.reqDisconnect))
            {
                packet.Write(id);
                // _Packet.Write(GameManager.players[Client.instance.my_Id].transform.rotation);
                sendTCPData(packet);
            }
        }
        public static void leaveRoom(int id)
        {
            using (UMIPacket packet = new UMIPacket((int)YUMIClientPackets.reqLeaveRoom))
            {
                packet.Write(id);
                sendTCPData(packet);
            }
        }
        public static void submitReadyPlayer(int id)
        {
            using (UMIPacket packet = new UMIPacket((int)YUMIClientPackets.reqReady))
            {
                packet.Write(id);
                sendTCPData(packet);
            }
        }
        public static void submitCancelReady(int id)
        {
            using (UMIPacket packet = new UMIPacket((int)YUMIClientPackets.reqCancelReady))
            {
                packet.Write(id);
                sendTCPData(packet);
            }
        }
        public static void cancelPlayer(int id)
        {
            using (UMIPacket packet = new UMIPacket((int)YUMIClientPackets.reqCancelPlayer))
            {
                packet.Write(id);
                sendTCPData(packet);
            }
        }
        public static void OnSubmitStart(string msg)
        {
            using (UMIPacket packet = new UMIPacket((int)YUMIClientPackets.reqStartGame))
            {
                packet.Write(msg);
                sendTCPData(packet);
            }
        }
    }
}