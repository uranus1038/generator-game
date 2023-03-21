using UnityEngine;
public class MIssionManager : MonoBehaviour
{
    public static void setPlayer(UMI.Network.Client.UMIPacket packet )
    {
      
        int UID = packet.ReadInt();
        string userName = packet.ReadString();
        Vector3 position = packet.ReadVector3();
        Quaternion rotation = packet.ReadQuaternion();
        string gender = packet.ReadString();
        int misssion = packet.ReadInt();
        setMission(UID , userName, position,rotation,gender,misssion);
    }
    private static void setMission(int UID,string userName,Vector3 position , Quaternion rotation,string gender ,int nMisssion)
    {
        UMI.UMISystem.L0g(nMisssion);
        switch (nMisssion)
        {
            case 101 : C001_MeadowOfWind.star.createPlayer(UID, userName, position, rotation, gender); break; 
        }
    }

}
