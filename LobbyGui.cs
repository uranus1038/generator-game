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
    eLobbyLoadingState eLobbyLoading_0 = eLobbyLoadingState.Start;
    //Texture
    private Texture texture_0;
    private Texture texture_1;
    private Texture texture_2;
    private Texture texture_3;
    private Texture texture_4;
    private Texture texture_5;
    private Texture texture_6;
    // GUI
    private GUIStyle style_0;
    private GUIStyle style_1;
    private GUIStyle style_2;
    private GUIStyle style_3;
    private void Awake()
    {
        this.LoadingGui = GetComponent<LoadingGui>();
        this.eLobbyState_0 = eLobbyState.lobbyMenu;
        this.eLobbyMenuState_0 = eLobbyMenuState.Init;
        this.InitaMenu();   
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
                float a = 2f * (this.delay_0 + 0.5f - Time.time);
                Color color = GUI.color;
                color.a = a;
                GUI.color = color;
                GUI.DrawTexture(new Rect(0.5f * this.display_0 - 960f, 0f, 1920f, 1024f), this.texture_1);
                Color color2 = GUI.color;
                color2.a = 1f;
                GUI.color = color2;
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
            if (Time.time < delay_0 + 1.8f)
            {
                GUI.DrawTexture(new Rect(this.display_0 - 460, Mathf.SmoothStep(0f, -300f, (Time.time - this.delay_0) / 0.8f), 420f, 60f), this.texture_1);
                GUI.Label(new Rect(this.display_0 - 460, Mathf.SmoothStep(0f, -300f, (Time.time - this.delay_0) / 0.8f), 420f, 60f),
                    UMIData.getStringPlayerData(1), this.style_3);
                return;
            }
            this.delay_0 = Time.time;
            this.eLobbyLoading_0 = eLobbyLoadingState.fadeOut;
            return;
        }
        if (this.eLobbyLoading_0 == eLobbyLoadingState.fadeOut)
        {
            this.LoadingGui.fadeOut(1f);
        }

    }
    private void RenderMenu()
    {
        GUI.DrawTexture(new Rect(0.5f*this.display_0 - 1920f/2f, 0f, 1920f, 1024f), this.texture_0);
        if (this.eLobbyMenuState_0 == eLobbyMenuState.Init)
        {
            this.delay_0 = Time.time;
            this.eLobbyMenuState_0 = eLobbyMenuState.fadeIn;
            return;
        }
        if (this.eLobbyMenuState_0 == eLobbyMenuState.fadeIn)
        {
            if (Time.time < this.delay_0 + 1.8f)
            {
                this.RenderMenuOption();
                this.LoadingGui.CloudFadeIn(1.8f);
                return; 
            }
            this.delay_0 = Time.time;
            this.eLobbyMenuState_0 = eLobbyMenuState.Menu;
            return;
        }
        if (this.eLobbyMenuState_0 == eLobbyMenuState.Menu)
        {
            GUI.BeginGroup(new Rect(1680, 300, 200, 200));
            GUILayout.BeginArea(new Rect(300, 300, 200, 200));
            GUILayout.Label("hello");
            GUILayout.EndArea();
            GUI.EndGroup();
            GUI.DrawTexture(new Rect(this.display_0 - 460, Mathf.SmoothStep(-300f, 0f, (Time.time - this.delay_0)/0.8f), 420f, 60f), this.texture_1);
            GUI.Label(new Rect(this.display_0 - 460, Mathf.SmoothStep(-300f, 0f, (Time.time - this.delay_0) / 0.8f), 420f, 60f),
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
   
    private void OnJoinGame()
    {
        UMIGame.LoadNextLevel(1);
    }
}
