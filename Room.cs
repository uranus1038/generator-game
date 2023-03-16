using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UMI.Network.Client;
using UMI.Manager;
using UMI.Network.API;
using UMI.Network.Server;
public class Room : MonoBehaviour
{
    public static Room star;
    private int UID;
    protected float display_0;
    private Texture texture_0;
    private Texture texture_1;
    private Texture texture_2;
    private Texture texture_3;
    private Texture texture_4;
    private Texture texture_5;
    private GUIStyle style_0;
    private GUIStyle style_1;
    private GUIStyle style_2;
    private GUIStyle style_3;
    // Resources
    private List<string> playerObject_0;
    private List<string> playerObject_1;
    private Dictionary<int, bool> players;

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
        this.texture_0 = (Texture)Resources.Load("GUI/Room/Room_book", typeof(Texture));
        this.texture_2 = (Texture)Resources.Load("GameAssets/Characters/2DCharacter/boyCharacter", typeof(Texture));
        this.texture_3 = (Texture)Resources.Load("GameAssets/Characters/2DCharacter/girlCharacter", typeof(Texture));
        this.texture_4 = (Texture)Resources.Load("GUI/Room/hopeIcon", typeof(Texture));
        this.texture_5 = (Texture)Resources.Load("GUI/Room/manaoIcon", typeof(Texture));
        this.style_0 = new GUIStyle();
        this.style_0.font = (Font)Resources.Load("GUI/Fonts/Prompt-Bold", typeof(Font));
        this.style_0.fontSize = 22;
        this.style_0.normal.textColor = new Color(0f, 0.1f, 0.2f, 0.8f);
        this.style_1 = new GUIStyle();
        this.style_1.normal.background = (Texture2D)((Texture)Resources.Load("GUI/Room/Wrong", typeof(Texture)));
        this.style_1.hover.background = (Texture2D)((Texture)Resources.Load("GUI/Room/Wrong_h", typeof(Texture)));
        this.style_2 = new GUIStyle();
        this.style_2.font = (Font)Resources.Load("GUI/Fonts/Prompt-Bold", typeof(Font));
        this.style_2.fontSize = 26;
        this.style_2.normal.textColor = new Color(2f, 2f, 2f, 0.8f);
        this.style_3 = new GUIStyle();
        this.style_3.normal.background = (Texture2D)((Texture)Resources.Load("GUI/Lobby/Button01", typeof(Texture)));
        this.style_3.hover.background = (Texture2D)((Texture)Resources.Load("GUI/Lobby/Button01_h", typeof(Texture)));
        this.style_3.normal.textColor = new Color(0f, 0.1f, 0.2f, 0.8f);
        this.style_3.fontSize = 23;
        this.style_3.alignment = TextAnchor.MiddleCenter;
        this.style_3.font = (Font)Resources.Load("GUI/Fonts/Prompt-Bold", typeof(Font));
        this.setInit();

    }   
    private void setInit()
    {
        this.players = new Dictionary<int, bool>() { { 1, false }, { 2, false }, { 3, false }, { 4, false } };
        this.playerObject_0 = new List<string>() { "0", "1", "2", "3", "4" };
        this.playerObject_1 = new List<string>() { "0", "1", "2", "3", "4" };
    }
    private void hClose()
    {
        UMIGame.Leave = false;
        UMIGame.Successed = true;
        UMIServer.resetNetwork();
        UMI.UMISystem.L0g("ResetRoom!");
    }
    private void resetGame()
    {
        UMIGame.Serve = true;
        UMIGame.connectLobby = true;
        UMIGame.Connecting = true;
        UMIGame.Connected = true;
        UMIGame.Successed = true;
        this.setInit();
        UMI.UMISystem.L0g("ResetGame!");
    }
    public void spawnLobby(int slot, string userName, string gender)
    {
        this.playerObject_0[slot] = gender;
        this.playerObject_1[slot] = userName;
        this.players[slot] = true;
    }
    private void OnGUI()
    {
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3((float)Screen.height / 1024f, (float)Screen.height / 1024f, 1f));
        GUI.depth = 2;
        this.display_0 = (float)(1024 * Screen.width / Screen.height);
        if (!UMIGame.Successed)
        {
            this.UID = UMIClientManager.star.UID;
            if (UMIData.getStringPlayerData(2) == "male")
            {
                GUI.DrawTexture(new Rect(0.5f * this.display_0 + 220f, 160f, 508f / 2f, 728f / 2f), this.texture_2);
            }
            else
            {
                GUI.DrawTexture(new Rect(0.5f * this.display_0 + 220f, 160f, 508f / 2f, 728f / 2f), this.texture_3);
            }
            if (GUI.Button(new Rect(0.5f * this.display_0 + 520f, 800f, 334f / 2f, 206f / 2f), Language.getMessage("LobbyGui", 04), this.style_3))
            {
                this.hClose();
                this.resetGame();
                return; 
            }
            if (players[1])
            {
                if (GUI.Button(new Rect(0.5f * this.display_0 - 530f, 288f, 238f / 3f, 238f / 3f), playerObject_1[1].ToString(), this.style_0)) { }
                if (GUI.Button(new Rect(0.5f * this.display_0 - 180f, 288f, 238f / 3f, 238f / 3f), "[Header]", this.style_2)) { }
                if (playerObject_0[1].ToString() == "male")
                {

                    GUI.DrawTexture(new Rect(0.5f * this.display_0 - 630f, 248f, 238f / 3f, 238f / 3f), this.texture_4);
                }
                else
                {
                    GUI.DrawTexture(new Rect(0.5f * this.display_0 - 630f, 248f, 238f / 3f, 238f / 3f), this.texture_5);
                }
            }
            if (players[2])
            {
                if (GUI.Button(new Rect(0.5f * this.display_0 - 530f, 383f, 238f / 3f, 238f / 3f), playerObject_1[2].ToString(), this.style_0)) { }
                if (this.UID == 1)
                {
                    if (GUI.Button(new Rect(0.5f * this.display_0 - 130f, 383f, 104F / 2F, 99F / 2F), string.Empty, this.style_1))
                    {

                    }
                }
                if (playerObject_0[2].ToString() == "male")
                {
                    GUI.DrawTexture(new Rect(0.5f * this.display_0 - 630f, 343f, 238f / 3f, 238f / 3f), this.texture_4);
                }
                else
                {
                    GUI.DrawTexture(new Rect(0.5f * this.display_0 - 630f, 343f, 238f / 3f, 238f / 3f), this.texture_5);
                }
            }
            if (players[3])
            {
                if (GUI.Button(new Rect(0.5f * this.display_0 - 530f, 476f, 238f / 3f, 238f / 3f), playerObject_1[3].ToString(), this.style_0)) { }
                if (this.UID == 1)
                {
                    if (GUI.Button(new Rect(0.5f * this.display_0 - 130f, 476f, 104F / 2F, 99F / 2F), string.Empty, this.style_1))
                    {

                    }
                }
                if (playerObject_0[3].ToString() == "male")
                {
                    GUI.DrawTexture(new Rect(0.5f * this.display_0 - 630f, 436f, 238f / 3f, 238f / 3f), this.texture_4);
                }
                else
                {
                    GUI.DrawTexture(new Rect(0.5f * this.display_0 - 630f, 436f, 238f / 3f, 238f / 3f), this.texture_5);
                }
            }
            if (players[4])
            {
                if (GUI.Button(new Rect(0.5f * this.display_0 - 530f, 569f, 238f / 3f, 238f / 3f), playerObject_1[4].ToString(), this.style_0)) { }
                if (this.UID == 1)
                {
                    if (GUI.Button(new Rect(0.5f * this.display_0 - 130f, 569f, 104F / 2F, 99F / 2F), string.Empty, this.style_1))
                    {

                    }
                }
                if (playerObject_0[4].ToString() == "male")
                {
                    GUI.DrawTexture(new Rect(0.5f * this.display_0 - 630f, 529f, 238f / 3f, 238f / 3f), this.texture_4);
                }
                else
                {
                    GUI.DrawTexture(new Rect(0.5f * this.display_0 - 630f, 529f, 238f / 3f, 238f / 3f), this.texture_5);
                }
            }
            return; 

        }
    }

}

