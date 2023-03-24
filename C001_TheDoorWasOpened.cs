using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UMI.Network.Server;
using UMI.Network.Client;
using UMI.Network.API;
using UMI.Manager.Period;
public class C001_TheDoorWasOpened : MonoBehaviour
{
    public static C001_TheDoorWasOpened star;
    private float delay_0;
    private float display_0;
    private eGameState eGameState_0;
    private LoadingGui LoadingGui;
    private TimeManager txt; 
    private Texture texture_0;
    private Texture texture_1;
    private GUIStyle style_0;
    private GameObject player_0;
    private string gender;
    public bool isMessage;
    public bool NEXT_MESSAGE;
    private void Awake()
    {
        this.isMessage = true; 
        this.NEXT_MESSAGE =  false;
        this.eGameState_0 = eGameState.Init;
        this.Init();
        star = this;
#pragma warning disable UNT0010
        this.LoadingGui = (LoadingGui)this.GetComponent(typeof(LoadingGui));
        this.txt = (TimeManager)this.GetComponent(typeof(TimeManager));
#pragma warning disable UNT0010
    }
    public void Start()
    {
        UMIClientSend.OnJoinGame("TheDoorWasOpened", 101);
        this.gender = UMIData.getStringPlayerData(2);
    }
    private void Init()
    {
        this.texture_0 = (Texture)Resources.Load("GUI/Game/Textbar_c2", typeof(Texture));
        this.texture_1 = (Texture)Resources.Load("GUI/Loading/White", typeof(Texture));
        this.style_0 = new GUIStyle();
        this.style_0.font = (Font)Resources.Load("GUI/Fonts/Prompt-Bold", typeof(Font));
        this.style_0.fontSize = 32;
        this.style_0.normal.textColor = new Color(0f, 0.1f, 0.2f, 0.8f);
    }
    public void createPlayer(int UID, string userName, Vector3 position, Quaternion rotation, string gender)
    {
        if (UID == UMIClientManager.star.UID)
        {
                this.player_0 = (GameObject)UnityEngine.Object.Instantiate((GameObject)Resources.Load($"GameAssets/Characters/viewChar/{gender}Char", typeof(GameObject)), position, rotation);
        }
        else
        {
                this.player_0 = (GameObject)UnityEngine.Object.Instantiate((GameObject)Resources.Load($"GameAssets/Characters/viewChar/{gender}CharPlayer", typeof(GameObject)), position, rotation);

        }
        player_0.GetComponent<UMIPlayerManager>().UID = UID;
        player_0.GetComponent<UMIPlayerManager>().userName = userName;
        player_0.GetComponent<UMIPlayerManager>().gender = gender;
        UMIGameManager.players.Add(UID, player_0.GetComponent<UMIPlayerManager>());
    }
    private void OnNetworkConnect()
    {
        if(UMIGameManager.players.Count ==  Room.star.nPlayer)
        {
            this.delay_0 = Time.time;
            this.eGameState_0 = eGameState.Normal;
        }
    }
    private void OnGUI()
    {
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3((float)Screen.height / 1024f, (float)Screen.height / 1024f, 1f));
        GUI.depth = 2;
        this.display_0 = (float)(1024 * Screen.width / Screen.height);
        if (this.eGameState_0 == eGameState.Init)
        {
            Game.camera_0 = true;
            GUI.DrawTexture(new Rect(0.5f * this.display_0 - 1980/2f,0f,1980f, 1024f), this.texture_1);
            this.OnNetworkConnect();
        }
        if (this.eGameState_0 == eGameState.Normal)
        {
            this.LoadingGui.fadeIn();
            GUI.DrawTexture(new Rect(Mathf.SmoothStep(-660f, -180f,(Time.time - this.delay_0) /1.5f),2f ,
               660f, 1020f), (Texture)Resources.Load($"GUI/Character/{this.gender}", typeof(Texture)));
            GUI.DrawTexture(new Rect(0.5f * this.display_0 - 1409f/2f, Mathf.SmoothStep(1000f, 625f, Time.time - this.delay_0),
                1409f, 355f), this.texture_0);
            if(Time.time - delay_0 <1.5f)
            {
                return;
            }
            if(this.isMessage)
            {
                StartCoroutine(this.txt.setMessage(Language.getMessage("C001", 100) , 3f));
                this.isMessage = false;
            }
            GUI.Box(new Rect(310, 728f,800, 200f),this.txt.getMessage(out NEXT_MESSAGE), this.style_0);
            if(NEXT_MESSAGE)
            {
                this.delay_0 = Time.time;
                this.eGameState_0 = eGameState.Start;
            }
        }

    }
  
}
