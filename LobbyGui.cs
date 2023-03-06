using UnityEngine;
using UMI.Network.Server;
using UMI.Network.Client;
using UMI.Network;
using UMI.Manager;
using UMI.Network.API;
public class LobbyGui : MonoBehaviour
{
    //flot 
    private float delay_0;
    private float display_0;
    //enum
    eLobbyMenuState eLobbyMenuState_0;
    eLobbyState eLobbyState_0;
    //Texture
    private Texture texture_0;
    private Texture texture_1;
    // GUI
    private GUIStyle style_0;
    private GUIStyle style_1;
    private GUIStyle style_2;
    private GUIStyle style_3;
    private void Awake()
    {
        this.eLobbyState_0 = eLobbyState.lobbyMenu;
        this.eLobbyMenuState_0 = eLobbyMenuState.Init;
        this.InitaMenu();
    }
    private void InitaMenu()
    {
        this.texture_0 = (Texture)Resources.Load("GUI/Lobby/Lobby_background01", typeof(Texture));
        this.texture_1 = (Texture)Resources.Load("GUI/Lobby/White", typeof(Texture));

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

    }
    private void RenderMenu()
    {
        GUI.DrawTexture(new Rect(0.5f * this.display_0 - 960f, 0f, 1920f, 1024f), this.texture_0);
        if (this.eLobbyMenuState_0 == eLobbyMenuState.Init)
        {
            this.delay_0 = Time.time;
            this.eLobbyMenuState_0 = eLobbyMenuState.fadeIn;
            return;
        }
        if (this.eLobbyMenuState_0 == eLobbyMenuState.fadeIn)
        {
            this.MenuOption();
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
            this.eLobbyMenuState_0 = eLobbyMenuState.Menu;
            return;
        }

        if (this.eLobbyMenuState_0 == eLobbyMenuState.Menu)
        {
            GUI.DrawTexture(new Rect(1920f - 460f, Mathf.SmoothStep(-300f, 0f, Time.time - this.delay_0), 380f, 60f), this.texture_1);
            GUI.Label(new Rect(1920f - 460f, Mathf.SmoothStep(-300f, 0f, Time.time - this.delay_0), 380f, 60f),
                UMIData.getStringPlayerData(1), this.style_3);
            this.MenuOption();
        }
        if (this.eLobbyMenuState_0 == eLobbyMenuState.createRoom)
        {
            if (GUI.Button(new Rect(0.5f * this.display_0 - 125f, 400f, 250f, 38f), "CreateRoom"))
            {
                UMIServe.star.StartServe();
                this.eLobbyMenuState_0 = eLobbyMenuState.notice;
            }
        }
        if (this.eLobbyMenuState_0 == eLobbyMenuState.notice)
        {
            if (Time.time < this.delay_0 + 0.5f)
            {
                // # Notice
                GUI.TextField(new Rect(0.5f * this.display_0 - 125f, 400f, 250f, 38f), "Notice");
                return;
            }
            this.delay_0 = Time.time;
            this.eLobbyMenuState_0 = eLobbyMenuState.renderRoom;
            return;
        }
        if (this.eLobbyMenuState_0 == eLobbyMenuState.renderRoom)
        {
            if (GUI.Button(new Rect(0.5f * this.display_0 - 125f, 400f, 250f, 38f), "Start"))
            {

                this.OnJoinGame();
            }
        }
    }
    private void MenuOption()
    {
        if (GUI.Button(new Rect(0.5f * this.display_0 - 136f, 238f, 535f / 2f, 357f / 2f),
            Language.getMessage("LobbyGui", 00), this.style_0))
        {
            this.eLobbyMenuState_0 = eLobbyMenuState.createRoom;
        }
        if (GUI.Button(new Rect(0.5f * this.display_0 - 136f, 446f, 535f / 2f, 396f / 2f),
            Language.getMessage("LobbyGui",01), this.style_1))
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
