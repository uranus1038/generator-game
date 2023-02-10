using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UMI.Network.Client
{
    public class UMIGameManager : MonoBehaviour
    {
        public static UMIGameManager star;
        // Resources
        protected string playerObject_0; 
        protected string playerObject_1; 
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
            this.playerObject_0 = "GameAssets/Characters/viewChar/boyChar";
            this.playerObject_1 = "GameAssets/Characters/viewChar/boyCharPlayer";
        }
        public void spawnPlayer(int UID, string userName, Vector3 position, Quaternion rotation)
        {
            GameObject player_0;
            if (UID == UMIClientManager.star.UID)
            {
                player_0 = (GameObject)UnityEngine.Object.Instantiate((GameObject)Resources.Load(this.playerObject_0, typeof(GameObject)), position, rotation);

            }
            else
            {
                player_0 = (GameObject)UnityEngine.Object.Instantiate((GameObject)Resources.Load(this.playerObject_1, typeof(GameObject)), position, rotation);

            }
            player_0.GetComponent<UMIPlayerManager>().UID = UID;
            player_0.GetComponent<UMIPlayerManager>().userName = userName;
            players.Add(UID, player_0.GetComponent<UMIPlayerManager>());          
        }

    }
}