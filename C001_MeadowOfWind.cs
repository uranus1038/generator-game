using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UMI.Network.Server;
using UMI.Network.Client;
public class C001_MeadowOfWind : MonoBehaviour
{
    public static C001_MeadowOfWind star;
    private float delay_0;
    private float display_0;
    // Resources
    List<string> playerObject_0 = new List<string>();
    private GameObject player_0;
    public static Dictionary<int, UMIPlayerManager> players = new Dictionary<int, UMIPlayerManager>();
    private void Awake()
    {
        this.Init();
        star = this;
    }
    public void Start()
    {
        UMIClientSend.OnJoinGame("MeadowOfWind", 101);
    }
    private void Init()
    {
        this.playerObject_0.Add("GameAssets/Characters/viewChar/boyChar");
        this.playerObject_0.Add("GameAssets/Characters/viewChar/boyCharPlayer");
        this.playerObject_0.Add("GameAssets/Characters/viewChar/girlChar");
        this.playerObject_0.Add("GameAssets/Characters/viewChar/girlCharPlayer");
    }
    public void createPlayer(int UID, string userName, Vector3 position, Quaternion rotation, string gender)
    {
        UMI.UMISystem.L0g("Handler ! ");
        if (UID == UMIClientManager.star.UID)
        {
            if (gender == "male")
            {
                this.player_0 = (GameObject)UnityEngine.Object.Instantiate((GameObject)Resources.Load(this.playerObject_0[0], typeof(GameObject)), position, rotation);
            }
            else
            {
                this.player_0 = (GameObject)UnityEngine.Object.Instantiate((GameObject)Resources.Load(this.playerObject_0[2], typeof(GameObject)), position, rotation);
            }

        }
        else
        {
            if (gender == "male")
            {
                this.player_0 = (GameObject)UnityEngine.Object.Instantiate((GameObject)Resources.Load(this.playerObject_0[1], typeof(GameObject)), position, rotation);
            }
            else
            {
                this.player_0 = (GameObject)UnityEngine.Object.Instantiate((GameObject)Resources.Load(this.playerObject_0[3], typeof(GameObject)), position, rotation);
            }

        }
        player_0.GetComponent<UMIPlayerManager>().UID = UID;
        player_0.GetComponent<UMIPlayerManager>().userName = userName;
        players.Add(UID, player_0.GetComponent<UMIPlayerManager>());
    }
    private void OnGUI()
    {
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3((float)Screen.height / 1024f, (float)Screen.height / 1024f, 1f));
        GUI.depth = 2;
        this.display_0 = (float)(1024 * Screen.width / Screen.height);

    }
}
