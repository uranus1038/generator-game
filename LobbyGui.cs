using UnityEngine;
using UMI.Network.Server;
using UMI.Network.Client;
using UMI.Network;
using UMI.Manager;
using UMI.Network.API;
public class LobbyGui : MonoBehaviour
{
    private LoadingGui LoadingGui;
    //flot 
    private float delay_0;
    private float display_0;
    protected float float_0 = 0.5f;
    //enum
    eLobbyMenuState eLobbyMenuState_0;
    eLobbyState eLobbyState_0;
    eLobbyLoadingState eLobbyLoading_0;
    eLobbyRoomState eLobbyRoom_0;
    //Texture
    private Texture texture_0;
    private Texture texture_1;
    private Texture texture_2;
    private Texture texture_3;
    private Texture texture_4;
    private Texture texture_5;
    private Texture texture_6;
    private Texture texture_7;
    private Texture texture_8;
    private Texture texture_9;
    private Texture texture_10;
    private Texture texture_11;
    private Texture texture_12;
    private Texture texture_13;
    private Texture texture_14;
    private Texture texture_15;
    // GUI
    private GUIStyle style_0;
    private GUIStyle style_1;
    private GUIStyle style_2;
    private GUIStyle style_3;
    private GUIStyle style_4;
    private GUIStyle style_5;
    private void Awake()
    {
        this.LoadingGui = GetComponent<LoadingGui>();
        this.eLobbyState_0 = eLobbyState.lobbyMenu;
        this.eLobbyMenuState_0 = eLobbyMenuState.Init;
        this.eLobbyLoading_0 = eLobbyLoadingState.Start;
        this.eLobbyRoom_0 = eLobbyRoomState.Start;
        this.InitaMenu();
        this.InitCreateRoom();
    }
    private void Start()
    {
#pragma warning disable UNT0010 // Component instance creation
        if (this.LoadingGui == null)
            this.LoadingGui = GetComponent<LoadingGui>();
#pragma warning restore UNT0010 // Component instance creation
    }

    private void InitaMenu()
    {
        this.texture_0 = (Texture)Resources.Load("GUI/Lobby/Lobby_background01", typeof(Texture));
        this.texture_1 = (Texture)Resources.Load("GUI/Lobby/White", typeof(Texture));
        this.texture_2 = (Texture)Resources.Load("GUI/Lobby/Lobby_background02", typeof(Texture));
        this.style_0 = new GUIStyle();
        this.style_0.hover.background = (Texture2D)((Texture)Resources.Load("GUI/Lobby/Play_button", typeof(Texture)));
        this.style_0.hover.textColor = new Color(0f, 0.1f, 0.2f, 0.8f);
        this.style_0.fontSize = 32;
        this.style_0.alignment = TextAnchor.MiddleCenter;
        this.style_0.font = (Font)Resources.Load("GUI/Fonts/Prompt-Bold", typeof(Font));
        this.style_1 = new GUIStyle();
        this.style_1.hover.background = (Texture2D)((Texture)Resources.Load("GUI/Lobby/Option_button", typeof(Texture)));
        this.style_1.hover.textColor = new Color(0f, 0.1f, 0.2f, 0.8f);
        this.style_1.fontSize = 32;
        this.style_1.alignment = TextAnchor.MiddleCenter;
        this.style_1.font = (Font)Resources.Load("GUI/Fonts/Prompt-Bold", typeof(Font));
        this.style_2 = new GUIStyle();
        this.style_2.hover.background = (Texture2D)((Texture)Resources.Load("GUI/Lobby/Quit_button", typeof(Texture)));
        this.style_2.hover.textColor = new Color(0f, 0.1f, 0.2f, 0.8f);
        this.style_2.fontSize = 32;
        this.style_2.alignment = TextAnchor.MiddleCenter;
        this.style_2.font = (Font)Resources.Load("GUI/Fonts/Prompt-Bold", typeof(Font));
        this.style_3 = new GUIStyle();
        this.style_3.font = (Font)Resources.Load("GUI/Fonts/Prompt-Bold", typeof(Font));
        this.style_3.normal.textColor = new Color(0f, 0.1f, 0.2f, 0.8f);
        this.style_3.fontSize = 18;
        this.style_3.alignment = TextAnchor.MiddleCenter;
        this.style_5 = new GUIStyle();
        this.style_5.font = (Font)Resources.Load("GUI/Fonts/Prompt-Bold", typeof(Font));
        this.style_5.normal.textColor = new Color(0f, 0.1f, 0.2f, 0.8f);
        this.style_5.fontSize = 18;
        this.style_5.alignment = TextAnchor.MiddleCenter;

    }
    private void InitCreateRoom()
    {
        this.texture_7 = (Texture)Resources.Load("GUI/Lobby/sky00", typeof(Texture));
        this.texture_8 = (Texture)Resources.Load("GUI/Lobby/sky01", typeof(Texture));
        this.texture_9 = (Texture)Resources.Load("GUI/Lobby/Lobby_book_bg00", typeof(Texture));
        this.texture_10 = (Texture)Resources.Load("GUI/Lobby/Lobby_book_bg01", typeof(Texture));
        this.texture_11 = (Texture)Resources.Load("GUI/Lobby/Note01", typeof(Texture));
        this.texture_14 = (Texture)Resources.Load("GUI/Lobby/Notice_bar", typeof(Texture));
        this.texture_15 = (Texture)Resources.Load("GUI/Lobby/Friend_box_wait", typeof(Texture));
        this.style_4 = new GUIStyle();
        this.style_4.normal.background = (Texture2D)((Texture)Resources.Load("GUI/Lobby/Button01", typeof(Texture)));
        this.style_4.hover.background = (Texture2D)((Texture)Resources.Load("GUI/Lobby/Button01_h", typeof(Texture)));
        this.style_4.hover.textColor = new Color(0f, 0.1f, 0.2f, 0.8f);
        this.style_4.fontSize = 23;
        this.style_4.alignment = TextAnchor.MiddleCenter;
        this.style_4.font = (Font)Resources.Load("GUI/Fonts/Prompt-Bold", typeof(Font));

    }

    private void OnGUI()
    {
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3((float)Screen.height / 1024f, (float)Screen.height / 1024f, 1f));
        GUI.depth = 2;
        this.display_0 = (float)(1024 * Screen.width / Screen.height);
        if (this.eLobbyState_0 == eLobbyState.lobbyMenu)
        {
            this.RenderMenu();
        }
        else
        {
            if (this.eLobbyState_0 == eLobbyState.Loading)
            {
                this.RenderLoading();
                return;
            }
            else
            {
                if (this.eLobbyState_0 == eLobbyState.createRoom)
                {
                    this.RenderCreateRoom();
                    return;
                }
            }
        }
    }
    private void RenderCreateRoom()
    {
        if (this.eLobbyRoom_0 == eLobbyRoomState.Start)
        {
            GUI.DrawTexture(new Rect(0.5f * this.display_0 - 960f, 0f, 1920f, 1024f), this.texture_8);
            if (Time.time < this.delay_0 + 1f)
            {
                this.LoadingGui.fadeInTimer(0.5f);
                return;
            }
            this.delay_0 = Time.time;
            this.eLobbyRoom_0 = eLobbyRoomState.Normal;
            return;
        }
        if (this.eLobbyRoom_0 == eLobbyRoomState.Normal)
        {
            GUI.DrawTexture(new Rect(0.5f * this.display_0 - 960f, 0f, 1920f, 1024f), this.texture_8);
            if (Time.time < this.delay_0 + 1f)
            {
                GUI.DrawTexture(new Rect(0.5f * this.display_0 - 1638f / 4f, Mathf.SmoothStep(-1620f / 2f, 100, (Time.time - this.delay_0) / 1f), 1638f / 2f, 1620f / 2f),
                    this.texture_9);
                return;
            }
            this.delay_0 = Time.time;
            this.eLobbyRoom_0 = eLobbyRoomState.fadeIn;
            return;
        }
        if (this.eLobbyRoom_0 == eLobbyRoomState.fadeIn)
        {

            if (Time.time < this.delay_0 + 0.5f)
            {
                GUI.DrawTexture(new Rect(0.5f * this.display_0 - 960f, 0f, 1920f, 1024f), this.texture_8);
                GUI.DrawTexture(new Rect(0.5f * this.display_0 - 1638f / 4f, 100f, 1638f / 2f, 1620f / 2f),
                       this.texture_9);
                return;
            }
            this.delay_0 = Time.time;
            this.eLobbyRoom_0 = eLobbyRoomState.createRoom;
            return;
        }
        if (this.eLobbyRoom_0 == eLobbyRoomState.createRoom)
        {
            this.LoadingGui.fadeShiro();
            GUI.DrawTexture(new Rect(0.5f * this.display_0 - 960f, 0f, 1920f, 1024f), this.texture_7);
            GUI.DrawTexture(new Rect(0.5f * this.display_0 - 2989f / 4f, 100f, 2989F / 2f, 1673F / 2f),
                 this.texture_10);
            GUI.DrawTexture(new Rect(0.5f * this.display_0 + 80f, 210f, 1016f / 2f, 995f / 2f), this.texture_11);
            if (GUI.Button(new Rect(0.5f * this.display_0 + 98f, 660f, 334f / 2f, 206f / 2f), Language.getMessage("LobbyGui", 03), this.style_4))
            {
                UMI.Manager.UMIGame.Serve = true;
                this.delay_0 = Time.time;
                this.eLobbyRoom_0 = eLobbyRoomState.isCreateRoom;
            }
            if (GUI.Button(new Rect(0.5f * this.display_0 + 380f, 660f, 334f / 2f, 206f / 2f), Language.getMessage("LobbyGui", 03), this.style_4))
            {
                UMI.Manager.UMIGame.connectLobby = true;
                UMI.Manager.UMIGame.Join = true;
                this.delay_0 = Time.time;
                this.eLobbyRoom_0 = eLobbyRoomState.isJoin;
            }
            if (GUI.Button(new Rect(0.5f * this.display_0 + 520f, 800f, 334f / 2f, 206f / 2f), Language.getMessage("LobbyGui", 04), this.style_4))
            {
                this.delay_0 = Time.time;
                this.eLobbyRoom_0 = eLobbyRoomState.isBack;
            }
        }
        if (this.eLobbyRoom_0 == eLobbyRoomState.isJoin)
        {
            if (Time.time < this.delay_0 + 1.5f)
            {
                this.RenderCreateRoomConnect();
                this.RenderNoticeMessage(Language.getMessage("LobbyGui", 05));
                return; 
            }
            this.delay_0 = Time.time;
            this.eLobbyRoom_0 = eLobbyRoomState.Join;
            return;
        }
        if (this.eLobbyRoom_0 == eLobbyRoomState.Join)
        {
            
            if (Time.time < this.delay_0 + 1.5f)
            {
                if (UMIGame.Join)
                {
                    this.OnJoinServe();
                    UMIGame.Join = false;
                }
                this.RenderCreateRoomConnect();
                this.RenderNoticeMessage(Language.getMessage("LobbyGui", 06));
                return; 
            }
            if(UMIGame.Connecting)
            {
                this.RenderCreateRoomConnect();
                this.RenderNoticeMessage(Language.getMessage("LobbyGui", 06));
                if(!UMIGame.Connected)
                {
                    this.delay_0 = Time.time;
                    this.eLobbyRoom_0 = eLobbyRoomState.Room;
                    UMIGame.Connected = true; 
                    return;
                }
            }
            else
            {
                this.delay_0 = Time.time;
                this.eLobbyRoom_0 = eLobbyRoomState.notFound;
                return;
            }
        }
        if (this.eLobbyRoom_0 == eLobbyRoomState.notFound)
        {
            if (Time.time < this.delay_0 + 1.5f)
            {
                this.RenderCreateRoomConnect();
                this.RenderNoticeMessage(Language.getMessage("LobbyGui", 07));
                return; 
            }
            this.delay_0 = Time.time;
            this.eLobbyRoom_0 = eLobbyRoomState.createRoom;
            return;
        }
        if (this.eLobbyRoom_0 == eLobbyRoomState.isCreateRoom)
        {  
            if (Time.time < this.delay_0 + 1.5f)
            {
                if (UMIGame.Serve)
                {
                    UMIServe.star.StartServe();
                    UMIGame.Serve = false;
                }
                this.RenderCreateRoomConnect();
                this.RenderNoticeMessage(Language.getMessage("LobbyGui",05));
                return;
            }
            this.delay_0 = Time.time;
            this.eLobbyRoom_0 = eLobbyRoomState.isRoom;
            return;
        }
        if(this.eLobbyRoom_0 == eLobbyRoomState.isRoom)
        {
            if (Time.time < this.delay_0 + 1.5f)
            {
                this.RenderCreateRoomConnect();
                this.RenderNoticeMessage(Language.getMessage("LobbyGui", 06));
                return;
            }
            this.delay_0 = Time.time;
            this.eLobbyRoom_0 = eLobbyRoomState.Room;
            return;
        }
        if (this.eLobbyRoom_0 == eLobbyRoomState.Room)
        {
            this.LoadingGui.fadeShiroTimer(0.5f);
            this.RenderRoom();
        }
        if (this.eLobbyRoom_0 == eLobbyRoomState.isBack)
        {
            GUI.DrawTexture(new Rect(0.5f * this.display_0 - 960f, 0f, 1920f, 1024f), this.texture_8);
            GUI.DrawTexture(new Rect(0.5f * this.display_0 - 1638f / 4f, 100f, 1638f / 2f, 1620f / 2f),
                   this.texture_9);
            if (Time.time < this.delay_0 + 0.5f)
            {
                this.LoadingGui.fadeShiroTimer(0.5f);
                return;
            }
            this.delay_0 = Time.time;
            this.eLobbyRoom_0 = eLobbyRoomState.isNormalBack;
            return;
        }
        if (this.eLobbyRoom_0 == eLobbyRoomState.isNormalBack)
        {
            GUI.DrawTexture(new Rect(0.5f * this.display_0 - 960f, 0f, 1920f, 1024f), this.texture_8);
            if (Time.time < this.delay_0 + 1f)
            {
                GUI.DrawTexture(new Rect(0.5f * this.display_0 - 1638f / 4f, Mathf.SmoothStep( 100, -1620f / 2f, (Time.time - this.delay_0) / 1f), 1638f / 2f, 1620f / 2f),
                   this.texture_9);
                return;
            }
            this.delay_0 = Time.time;
            this.eLobbyRoom_0 = eLobbyRoomState.fadeBack;
            return;
        }
        if(this.eLobbyRoom_0 == eLobbyRoomState.fadeBack)
        {
            GUI.DrawTexture(new Rect(0.5f * this.display_0 - 960f, 0f, 1920f, 1024f), this.texture_8);
            if (Time.time < delay_0 + 1f)
            {
                this.LoadingGui.fadeOutTimer(0.5f);
                return;
            }
            this.delay_0 = Time.time;
            this.eLobbyState_0 = eLobbyState.lobbyMenu;
            this.eLobbyRoom_0 = eLobbyRoomState.Start;
            return; 
        }
    }
    private void RenderRoom()
    {
        UMIGame.Successed = false; 
        GUI.DrawTexture(new Rect(0.5f * this.display_0 - 960f, 0f, 1920f, 1024f), this.texture_7);
        GUI.DrawTexture(new Rect(0.5f * this.display_0 - 2989f / 4f, 100f, 2989F / 2f, 1673F / 2f),
             this.texture_10);
        GUI.DrawTexture(new Rect(0.5f * this.display_0 - 638f, 180f, 508f / 2f, 629f / 2f), this.texture_15);
        GUI.DrawTexture(new Rect(0.5f * this.display_0 - 338f, 220f, 508f / 2f, 629f / 2f), this.texture_15);
        GUI.DrawTexture(new Rect(0.5f * this.display_0 + 88f, 220f, 508f / 2f, 629f / 2f), this.texture_15);
        GUI.DrawTexture(new Rect(0.5f * this.display_0 + 388f, 180f, 508f / 2f, 629f / 2f), this.texture_15);
        if (UMIGame.Join)
        {
            this.OnJoinServe();
            UMIGame.Join = false;
        }
    }
    private void RenderLoading()
    {
        GUI.DrawTexture(new Rect(0.5f * this.display_0 - 960f, 0f, 1920f, 1024f), this.texture_2);
        if (this.eLobbyLoading_0 == eLobbyLoadingState.Start)
        {
            GUI.DrawTexture(new Rect(this.display_0 - 460, 0f, 420f, 60f), this.texture_1);
            GUI.Label(new Rect(this.display_0 - 460, 0f, 420, 60f),
            UMIData.getStringPlayerData(1), this.style_3);
            if (Time.time < this.delay_0 + 0.5f)
            {
                this.LoadingGui.fadeShiro();
                return;
            }
            this.delay_0 = Time.time;
            this.eLobbyLoading_0 = eLobbyLoadingState.Normal;
            return;
        }
        if (this.eLobbyLoading_0 == eLobbyLoadingState.Normal)
        {
            if (Time.time < delay_0 + 1f)
            {
                GUI.DrawTexture(new Rect(this.display_0 - 460, 0f, 420f, 60f), this.texture_1);
                GUI.Label(new Rect(this.display_0 - 460, 0f, 420, 60f),
                     UMIData.getStringPlayerData(1), this.style_3);
                return;
            }
            this.delay_0 = Time.time;
            this.eLobbyLoading_0 = eLobbyLoadingState.Loading;
            return;
        }
        if (this.eLobbyLoading_0 == eLobbyLoadingState.Loading)
        {
            if (Time.time < delay_0 + 1f)
            {
                GUI.DrawTexture(new Rect(this.display_0 - 460, Mathf.SmoothStep(0f, -60f, (Time.time - this.delay_0) / 0.5f), 420f, 60f), this.texture_1);
                GUI.Label(new Rect(this.display_0 - 460, Mathf.SmoothStep(0f, -60f, (Time.time - this.delay_0) / 0.5f), 420f, 60f),
                    UMIData.getStringPlayerData(1), this.style_3);
                return;
            }
            this.delay_0 = Time.time;
            this.eLobbyLoading_0 = eLobbyLoadingState.fadeOut;
            return;
        }
        if (this.eLobbyLoading_0 == eLobbyLoadingState.fadeOut)
        {
            if (Time.time < delay_0 + 1f)
            {
                this.LoadingGui.fadeOutTimer(0.5f);
                return;
            }
            this.delay_0 = Time.time;
            this.eLobbyState_0 = eLobbyState.createRoom;
            this.eLobbyLoading_0 = eLobbyLoadingState.Start; 
            return;
        }

    }
    private void RenderMenu()
    {
        GUI.DrawTexture(new Rect(0.5f * this.display_0 - 1920f / 2f, 0f, 1920f, 1024f), this.texture_0);
        if (this.eLobbyMenuState_0 == eLobbyMenuState.Init)
        {
            this.delay_0 = Time.time;
            this.eLobbyMenuState_0 = eLobbyMenuState.fadeIn;
            return;
        }
        if (this.eLobbyMenuState_0 == eLobbyMenuState.fadeIn)
        {
            if (Time.time < this.delay_0 + 1.5f)
            {
                this.RenderMenuOption();
                this.LoadingGui.CloudFadeInTimer(1.5f);
                return;
            }
            this.delay_0 = Time.time;
            this.eLobbyMenuState_0 = eLobbyMenuState.Menu;
            return;
        }
        if (this.eLobbyMenuState_0 == eLobbyMenuState.Menu)
        {
            GUI.DrawTexture(new Rect(this.display_0 - 460, Mathf.SmoothStep(-60f, 0f, (Time.time - this.delay_0) / 0.5f), 420f, 60f), this.texture_1);
            GUI.Label(new Rect(this.display_0 - 460, Mathf.SmoothStep(-60f, 0f, (Time.time - this.delay_0) / 0.5f), 420f, 60f),
                UMIData.getStringPlayerData(1), this.style_3);
            this.RenderMenuOption();
        }
    }
    private void RenderMenuOption()
    {
        if (GUI.Button(new Rect(0.5f * this.display_0 - 136f, 238f, 535f / 2f, 357f / 2f),
            Language.getMessage("LobbyGui", 00), this.style_0))
        {
            this.delay_0 = Time.time;
            this.eLobbyState_0 = eLobbyState.Loading;
            this.eLobbyMenuState_0 = eLobbyMenuState.Init; 
        }
        if (GUI.Button(new Rect(0.5f * this.display_0 - 136f, 446f, 535f / 2f, 396f / 2f),
            Language.getMessage("LobbyGui", 01), this.style_1))
        {
            UMIGame.LoadNextLevel(1);
        }
        if (GUI.Button(new Rect(0.5f * this.display_0 - 136f, 656f, 535f / 2f, 408f / 2f),
             Language.getMessage("LobbyGui", 02), this.style_2))
        {

        }
    }
    private void RenderNoticeMessage(string message)
    {
        GUI.DrawTexture(new Rect(0.5f * this.display_0 - 645f / 2.8f, 1024/2.5f, 735f / 1.4f, 243f / 1.4f), this.texture_14);
        GUI.Label(new Rect(0.5f * this.display_0 - 645f / 2.8f, 1024f/2.5f, 700f / 1.4f, 268f / 1.4f), message, this.style_5);
    }
    private void RenderCreateRoomConnect()
    {
        this.LoadingGui.fadeShiro();
        GUI.DrawTexture(new Rect(0.5f * this.display_0 - 960f, 0f, 1920f, 1024f), this.texture_7);
        GUI.DrawTexture(new Rect(0.5f * this.display_0 - 2989f / 4f, 100f, 2989F / 2f, 1673F / 2f),
             this.texture_10);
        GUI.DrawTexture(new Rect(0.5f * this.display_0 + 80f, 210f, 1016f / 2f, 995f / 2f), this.texture_11);
        if (GUI.Button(new Rect(0.5f * this.display_0 + 98f, 660f, 334f / 2f, 206f / 2f), Language.getMessage("LobbyGui", 03), this.style_4))
        {
            
        }
        if (GUI.Button(new Rect(0.5f * this.display_0 + 520f, 800f, 334f / 2f, 206f / 2f), Language.getMessage("LobbyGui", 04), this.style_4))
        {
            
        }

    }
    private void OnJoinGame()
    {
        UMIGame.LoadNextLevel(1);
    } private void OnJoinServe()
    {
        UMIClientManager.star.connectServer("127.0.0.1");
    }
}
