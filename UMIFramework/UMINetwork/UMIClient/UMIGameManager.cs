using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UMI.Network.Server;
namespace UMI.Network.Client
{
    public class UMIGameManager : MonoBehaviour
    {
        public static UMIGameManager star;
        // Resources
        List<string> playerObject_0 = new List<string>();
        private GameObject player_0;
        public static Dictionary<int, UMIPlayerManager> players = new Dictionary<int, UMIPlayerManager>();
        private void Awake()
        {
            this.Init();
            if (star == null)
            {
                star = this;
            }
            else if (star != this)
            {
                Debug.Log($"UMI::DESTROY()->INSTANCE");
                Destroy(this);
            }
        }
        private void Init()
        {
            this.playerObject_0.Add("GameAssets/Characters/viewChar/boyChar");
            this.playerObject_0.Add("GameAssets/Characters/viewChar/boyCharPlayer");
            this.playerObject_0.Add("GameAssets/Characters/viewChar/girlChar");
            this.playerObject_0.Add("GameAssets/Characters/viewChar/girlCharPlayer");
        }
        public void spawnPlayer(int UID, string userName, Vector3 position, Quaternion rotation)
        {

            if (UID == UMIClientManager.star.UID)
            {
                this.player_0 = (GameObject)UnityEngine.Object.Instantiate((GameObject)Resources.Load(this.playerObject_0[2], typeof(GameObject)), position, rotation);

            }
            else
            {
                this.player_0 = (GameObject)UnityEngine.Object.Instantiate((GameObject)Resources.Load(this.playerObject_0[3], typeof(GameObject)), position, rotation);

            }

            player_0.GetComponent<UMIPlayerManager>().UID = UID;
            player_0.GetComponent<UMIPlayerManager>().userName = userName;
            players.Add(UID, player_0.GetComponent<UMIPlayerManager>());

        }


    }
}