using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UMI.Network.Client
{
    public class UMIGameManager : MonoBehaviour
    {
       
        public static UMIGameManager hInst;

        public static Dictionary<int, UMIPlayerManager> players = new Dictionary<int, UMIPlayerManager>();

        public GameObject localPlayerPrefab;
        public GameObject playerPrefab;
        private void Awake()
        {

            if (hInst == null)
            {
                hInst = this;
            }
            else if (hInst != this)
            {
                Debug.Log($"UMI::DESTROY()->INSTANCE");
                Destroy(this);
            }

        }
     


        public void spawnPlayer(int UID, string userName, Vector3 position, Quaternion rotation)
        {
            GameObject player_0;
            if (UID == UMIClient.hInst.UID)
            {
                player_0 = (GameObject)UnityEngine.Object.Instantiate((GameObject)Resources.Load("GameAssets/Characters/viewChar/boyChar", typeof(GameObject))
  , position, Quaternion.Euler(0f, 0f, 0f));

            }
            else
            {
                player_0 = (GameObject)UnityEngine.Object.Instantiate((GameObject)Resources.Load("GameAssets/Characters/viewChar/boyChar", typeof(GameObject))
  , position, Quaternion.Euler(0f, 0f, 0f));

            }


            player_0.GetComponent<UMIPlayerManager>().UID = UID;
            player_0.GetComponent<UMIPlayerManager>().userName = userName;
            if(players[UID] == null)
            {
                players.Add(UID, player_0.GetComponent<UMIPlayerManager>());
            }else
            {
                Destroy(UMIGameManager.players[UID].gameObject);
            }





        }

    }
}