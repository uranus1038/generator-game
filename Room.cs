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
    private int nPlayer;
    private int nReady;
    protected float display_0;
    protected float delay_0;
    private Texture texture_0;
    private Texture texture_1;
    private Texture texture_2;
    private Texture texture_3;
    private Texture texture_4;
    private Texture texture_5;
    private Texture texture_6;
    private GUIStyle style_0;
    private GUIStyle style_1;
    private GUIStyle style_2;
    private GUIStyle style_3;
    private GUIStyle style_4;
    private GUIStyle style_5;
    private GUIStyle style_6;
    private GUIStyle style_7;
    // Resources
    private List<string> playerObject_0;
    private List<string> playerObject_1;
    private Dictionary<int, bool> players;
    private Dictionary<int, bool> isReady;
    //enum
    eRoomState eRoomState_0;
    private void Awake()
    {
        this.Init();
        this.eRoomState_0 = eRoomState.Init;
        star = this;
        this.nReady = 1;
        this.nPlayer = 0;
    }
    private void Init()
    {
        this.texture_0 = (Texture)Resources.Load("GUI/Room/Room_book", typeof(Texture));
        this.texture_2 = (Texture)Resources.Load("GameAssets/Characters/2DCharacter/boyCharacter", typeof(Texture));
        this.texture_3 = (Texture)Resources.Load("GameAssets/Characters/2DCharacter/girlCharacter", typeof(Texture));
        this.texture_4 = (Texture)Resources.Load("GUI/Room/hopeIcon", typeof(Texture));
        this.texture_5 = (Texture)Resources.Load("GUI/Room/manaoIcon", typeof(Texture));
        this.texture_6 = (Texture)Resources.Load("GUI/Lobby/Notice_bar", typeof(Texture));
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
        this.style_4 = new GUIStyle();
        this.style_4.font = (Font)Resources.Load("GUI/Fonts/Prompt-Bold", typeof(Font));
        this.style_4.normal.textColor = new Color(0f, 0.1f, 0.2f, 0.8f);
        this.style_4.fontSize = 18;
        this.style_4.alignment = TextAnchor.MiddleCenter;
        this.style_5 = new GUIStyle();
        this.style_5.font = (Font)Resources.Load("GUI/Fonts/Prompt-Bold", typeof(Font));
        this.style_5.normal.textColor = new Color(0f, 0.1f, 0.2f, 0.5f);
        this.style_5.hover.background = (Texture2D)((Texture)Resources.Load("GUI/Room/Target", typeof(Texture)));
        this.style_5.fontSize = 38;
        this.style_5.alignment = TextAnchor.MiddleCenter;
        this.style_6 = new GUIStyle();
        this.style_6.font = (Font)Resources.Load("GUI/Fonts/Prompt-Bold", typeof(Font));
        this.style_6.fontSize = 22;
        this.style_6.normal.textColor = new Color(0f, 0.5f, 0f, 0.8f);
        this.style_7 = new GUIStyle();
        this.style_7.font = (Font)Resources.Load("GUI/Fonts/Prompt-Bold", typeof(Font));
        this.style_7.fontSize = 22;
        this.style_7.normal.textColor = new Color(0.5f, 0f, 0f, 0.8f);
        this.setInit();

    }
    private void setInit()
    {
        this.players = new Dictionary<int, bool>() { { 1, true }, { 2, false }, { 3, false }, { 4, false } };
        this.playerObject_0 = new List<string>() { "0", "1", "2", "3", "4" };
        this.playerObject_1 = new List<string>() { "0", "1", "2", "3", "4" };
        this.isReady = new Dictionary<int, bool>() { { 1, true } , { 2, true }, { 3, true }, { 4, true } };
    }
    public void OnDisconnectServer()
    {
        if (!players[1])
        {
            this.OnLeaveRoom();
            this.resetGame();
            this.delay_0 = Time.time;
            this.eRoomState_0 = eRoomState.serverDisconnect;
            return;
        }

    }
    public void OnCancelPlayer(int UID , string msg)
    {
        if (UID == UMIClientManager.star.UID)
        {
            this.OnLeaveRoom();
            this.resetGame();
            this.delay_0 = Time.time;
            this.eRoomState_0 = eRoomState.playerOut;
        }
    }
    private void OnCancelPlayer(int UID)
    {
        UMIClientSend.cancelPlayer(UID);
    }
    private void hClose()
    {
        UMIServer.resetNetwork();
    }
    private void resetGame()
    {
        UMIClientManager.star.TCP.socket = null; 
        UMIGame.Serve = true;
        UMIGame.connectLobby = true;
        UMIGame.Connecting = true;
        UMIGame.Connected = true;
        UMIGame.Successed = true;
        UMIGame.Leave = false;
        this.setInit();
        UMI.UMISystem.L0g("ResetRoom");
    }
    private void OnLeaveRoom()
    {
        UMIClientSend.leaveRoom(UMIClientManager.star.UID);
    }
    private void OnSubmitReady()
    {
        UMIClientSend.submitReadyPlayer(UMIClientManager.star.UID);
    }
    private void OnCancelReady()
    {
        UMIClientSend.submitCancelReady(UMIClientManager.star.UID);
    }
    private void OnStartGame()
    {
        UMI.UMISystem.L0g(this.nPlayer);
        UMI.UMISystem.L0g(this.nReady);
        if (this.nPlayer == this.nReady)
        {
            this.OnJoinGame();
            UMI.UMISystem.L0g("Game Start");
        }else
        {
            this.delay_0 = Time.time;
            this.eRoomState_0 = eRoomState.playerAllReady;
        }
    }
    public void OnCancel(int fClient)
    {
        this.nReady -= 1;
        this.isReady[fClient] = true; 
    }
    public void OnReady(int fClient)
    {
        this.isReady[fClient] = false;
        this.nReady += 1;
    }
    private void OnJoinGame()
    {

    }
    public void roomManager(int clientUID)
    {
        this.nPlayer -= 1;
        if(!this.isReady[clientUID])
        {
            this.nReady -= 1; 
        }
        this.players[clientUID] = false;
        UMI.UMISystem.L0g(this.nPlayer);
        UMI.UMISystem.L0g(this.nReady);
    }
    public void spawnLobby(int slot, string userName, string gender , bool isReady)
    {
        this.nPlayer += 1;
        this.playerObject_0[slot] = gender;
        this.playerObject_1[slot] = userName;
        this.players[slot] = true;
        this.isReady[slot] = isReady;
        UMI.UMISystem.L0g("spawn");
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
            if (this.UID == 1)
            {
                if (GUI.Button(new Rect(0.5f * this.display_0 + 520f, 800f, 334f / 2f, 206f / 2f), Language.getMessage("LobbyGui", 04), this.style_3))
                {
                    UMIGame.isHeader = true; 
                    this.hClose();
                    this.resetGame();
                    this.delay_0 = Time.time;
                    return;
                }
                if (GUI.Button(new Rect(0.5f * this.display_0 - 395f, 670f, 130f, 130f), Language.getMessage("LobbyGui", 22), this.style_5))
                {
                    this.OnStartGame();
                }
            }
            else
            {
                if (GUI.Button(new Rect(0.5f * this.display_0 + 520f, 800f, 334f / 2f, 206f / 2f), Language.getMessage("LobbyGui", 04), this.style_3))
                {
                    this.OnLeaveRoom();
                    this.resetGame();
                    this.delay_0 = Time.time;
                    return;
                }
                if (isReady[1])
                {
                    if (GUI.Button(new Rect(0.5f * this.display_0 - 395f, 670f, 130f, 130f), Language.getMessage("LobbyGui", 23), this.style_5))
                    {
                        this.isReady[1] = false;
                        this.OnSubmitReady();
                    }
                }
                else
                {
                    if (GUI.Button(new Rect(0.5f * this.display_0 - 395f, 670f, 130f, 130f), Language.getMessage("LobbyGui", 21), this.style_5))
                    {
                        this.isReady[1] = true;
                        this.OnCancelReady();
                    }
                }
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
            else
            {
                this.OnDisconnectServer();
                return;
            }
            if (players[2])
            {
                if (GUI.Button(new Rect(0.5f * this.display_0 - 530f, 383f, 238f / 3f, 238f / 3f), playerObject_1[2].ToString(), this.style_0)) { }
                if (this.UID == 1)
                {
                    if (GUI.Button(new Rect(0.5f * this.display_0 - 130f, 383f, 104F / 2F, 99F / 2F), string.Empty, this.style_1))
                    {
                        UMI.UMISystem.L0g("cancel player");
                        this.OnCancelPlayer(2);
                    }
                    if (isReady[2])
                    {
                        if (GUI.Button(new Rect(0.5f * this.display_0 - 230f, 383f, 104F / 2F, 99F / 2F), Language.getMessage("LobbyGui", 20), this.style_7))
                        {

                        }
                    }
                    else
                    {
                        if (GUI.Button(new Rect(0.5f * this.display_0 - 230f, 383f, 104F / 2F, 99F / 2F), Language.getMessage("LobbyGui", 19), this.style_6))
                        {

                        }
                    }
                }
                else
                {
                    if (isReady[2])
                    {
                        if (GUI.Button(new Rect(0.5f * this.display_0 - 150f, 383f, 104F / 2F, 99F / 2F), Language.getMessage("LobbyGui", 20), this.style_7))
                        {

                        }
                    }
                    else
                    {
                        if (GUI.Button(new Rect(0.5f * this.display_0 - 150f, 383f, 104F / 2F, 99F / 2F), Language.getMessage("LobbyGui", 19), this.style_6))
                        {

                        }
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
                        this.OnCancelPlayer(3);
                    }
                    if (isReady[3])
                    {
                        if (GUI.Button(new Rect(0.5f * this.display_0 - 230f, 476f, 104F / 2F, 99F / 2F), Language.getMessage("LobbyGui", 20), this.style_7))
                        {

                        }
                    }
                    else
                    {
                        if (GUI.Button(new Rect(0.5f * this.display_0 - 230f, 476f, 104F / 2F, 99F / 2F), Language.getMessage("LobbyGui", 19), this.style_6))
                        {

                        }
                    }
                }
                else
                {
                    if (isReady[3])
                    {
                        if (GUI.Button(new Rect(0.5f * this.display_0 - 150f, 476f, 104F / 2F, 99F / 2F), Language.getMessage("LobbyGui", 20), this.style_7))
                        {

                        }
                    }
                    else
                    {
                        if (GUI.Button(new Rect(0.5f * this.display_0 - 150f, 476f, 104F / 2F, 99F / 2F), Language.getMessage("LobbyGui", 19), this.style_6))
                        {

                        }
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
                        this.OnCancelPlayer(4);
                    }
                    if (isReady[4])
                    {
                        if (GUI.Button(new Rect(0.5f * this.display_0 - 230f, 569f, 104F / 2F, 99F / 2F), Language.getMessage("LobbyGui", 20), this.style_7))
                        {

                        }
                    }
                    else
                    {
                        if (GUI.Button(new Rect(0.5f * this.display_0 - 230f, 569f, 104F / 2F, 99F / 2F), Language.getMessage("LobbyGui", 19), this.style_6))
                        {

                        }
                    }
                }
                else
                {
                    if (isReady[4])
                    {
                        if (GUI.Button(new Rect(0.5f * this.display_0 - 150f, 569f, 104F / 2F, 99F / 2F), Language.getMessage("LobbyGui", 20), this.style_7))
                        {

                        }
                    }
                    else
                    {
                        if (GUI.Button(new Rect(0.5f * this.display_0 - 150f, 569f, 104F / 2F, 99F / 2F), Language.getMessage("LobbyGui", 19), this.style_6))
                        {

                        }
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

        }
        switch (this.eRoomState_0)
        {
            case eRoomState.playerOut:
                if (Time.time < this.delay_0 + 2f)
                {
                    this.RenderNoticeMessage(Language.getMessage("LobbyGui", 17));
                    return;
                }
                this.delay_0 = Time.time;
                this.eRoomState_0 = eRoomState.Init;
                break;
            case eRoomState.serverDisconnect:
                if (Time.time < this.delay_0 + 2f)
                {
                    this.RenderNoticeMessage(Language.getMessage("LobbyGui", 18));
                    return;
                }
                this.delay_0 = Time.time;
                this.eRoomState_0 = eRoomState.Init;
                break;
            case eRoomState.playerAllReady:
                this.RenderNoticeMessage(Language.getMessage("LobbyGui", 25));
                if (Time.time - this.delay_0 > 1f)
                {
                    this.delay_0 = Time.time;
                    this.eRoomState_0 = eRoomState.Init;
                    return;
                }
                break;
        }
    }
    private void RenderNoticeMessage(string message)
    {
        GUI.DrawTexture(new Rect(0.5f * this.display_0 - 645f / 2.8f, 1024 / 2.5f, 735f / 1.4f, 243f / 1.4f), this.texture_6);
        GUI.Label(new Rect(0.5f * this.display_0 - 645f / 2.8f, 1024f / 2.5f, 700f / 1.4f, 268f / 1.4f), message, this.style_4);
    }
}

