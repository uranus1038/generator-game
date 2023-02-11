using System.Numerics; 
namespace UMI.Network.Server
{
    // Setting Player
    public class UMIPlayer 
    {
        public static UMIPlayer star;
        public int UID;
        public string userName;
        public Vector3 position;
        public Quaternion rotation;
        public UMIPlayer(int UID, string userName, Vector3 spawnPosition)
        {
            this.UID = UID;
            this.userName = userName;
            this.position = spawnPosition;
            this.rotation = Quaternion.Identity;
        }
        public void UMIUpdate()
        {
            UMIServerSend.playerPosition2D(this);
        }
        public void resPosition(Vector3 position)
        {
            this.position = position;
        }
    }
}
