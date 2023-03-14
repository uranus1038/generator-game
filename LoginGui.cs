using UnityEngine;
using UMI.Network.API;
using UMI.Manager;
using UMI.Network;
using UMI;
public class LoginGui : MonoBehaviour
{
    private float delay_0;
    private float display_0;
    public string userName_0;
    private string QUk8sYq_x;
    //Enum
    public eLoginState eLoginState_0;
    //Texture
    private Texture texture_0;
    private Texture texture_1;
    private Texture texture_2;
    private Texture texture_3;
    private Texture texture_4;
    // GUI
    private GUIStyle guistyle_0;
    private GUIStyle guistyle_1;
    private GUIStyle guistyle_2;

    private UMIJSON JSON = new UMIJSON();
    UMIJSON req;
    private void Awake()
    {
        this.userName_0 = PlayerPrefs.GetString("userName", string.Empty);
        this.QUk8sYq_x = string.Empty;
        this.Init();
        this.eLoginState_0 = eLoginState.Init;
    }
    private void Start()
    {
        Application.targetFrameRate = 80;
        Application.runInBackground = true;
        Application.backgroundLoadingPriority = ThreadPriority.High;
        //UMI.UMISystem.L0g("Unity version : " + Application.unityVersion);
    }
    void Init()
    {
        //Texture
        this.texture_0 = (Texture)Resources.Load("GUI/Login/Black", typeof(Texture));
        this.texture_1 = (Texture)Resources.Load("GUI/Login/Login_background01", typeof(Texture));
        this.texture_2 = (Texture)Resources.Load("GUI/Login/Login_bar", typeof(Texture));
        this.texture_3 = (Texture)Resources.Load("GUI/Login/Notice_bar", typeof(Texture));
        this.texture_4 = (Texture)Resources.Load("GUI/Login/Chack_01", typeof(Texture));

        //GUI
        this.guistyle_0 = new GUIStyle();
        this.guistyle_0.font = (Font)Resources.Load("GUI/Fonts/Prompt-Bold", typeof(Font));
        this.guistyle_0.normal.textColor = new Color(0f, 0.1f, 0.2f, 0.8f);
        this.guistyle_0.fontSize = 18;
        //this.guistyle_0.alignment = TextAnchor.MiddleLeft;
        this.guistyle_1 = new GUIStyle();
        this.guistyle_1.hover.background = (Texture2D)((Texture)Resources.Load("GUI/Login/Login_button_h", typeof(Texture)));
        //GUI
        this.guistyle_2 = new GUIStyle();
        this.guistyle_2.font = (Font)Resources.Load("GUI/Fonts/Prompt-Bold", typeof(Font));
        this.guistyle_2.normal.textColor = new Color(0f, 0.1f, 0.2f, 0.8f);
        this.guistyle_2.fontSize = 18;
        this.guistyle_2.alignment = TextAnchor.MiddleCenter;
    }

    private void OnGUI()
    {
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3((float)Screen.height / 1024f, (float)Screen.height / 1024f, 1f));
        GUI.depth = 2;
        this.display_0 = (float)(1024 * Screen.width / Screen.height);
        GUI.DrawTexture(new Rect(0.5f * this.display_0 - 960f, 0f, 1920f, 1024f), this.texture_1);
        //State : 1 
        if (this.eLoginState_0 == eLoginState.Init)
        {
            this.delay_0 = Time.time;
            this.eLoginState_0 = eLoginState.fadeIn;
            return;
        }
        if (this.eLoginState_0 == eLoginState.fadeIn)
        {
            if (Time.time < this.delay_0 + 0.5f)
            {
                float a = 2f * (this.delay_0 + 0.5f - Time.time);
                Color color = GUI.color;
                color.a = a;
                GUI.color = color;
                GUI.DrawTexture(new Rect(0.5f * this.display_0 - 960f, 0f, 1920f, 1024f), this.texture_0);
                Color color2 = GUI.color;
                color2.a = 1f;
                GUI.color = color2;
                return;
            }
            this.delay_0 = Time.time;
            this.eLoginState_0 = eLoginState.Login;
            return;
        }
        if (this.eLoginState_0 == eLoginState.Login)
        {
            GUI.DrawTexture(new Rect(0.5f * this.display_0 - 222.25f, 713f, 444.5f, 212.5f), this.texture_2);
            // Text Input
            this.userName_0 = GUI.TextField(new Rect(0.5f * this.display_0 - 98f, 772f, 288f, 30f), this.userName_0, 15, this.guistyle_0);
            // Password Input
            this.QUk8sYq_x = GUI.PasswordField(new Rect(0.5f * this.display_0 - 98f, 812f, 288f, 30f), this.QUk8sYq_x, "*"[0], 15, this.guistyle_0);
            if (this.QUk8sYq_x.Length > 4 && this.userName_0 != string.Empty)
            {
                if (GUI.Button(new Rect(0.5f * this.display_0 - 142f, 863f, 253f / 2f, 124f / 2f), string.Empty, this.guistyle_1))
                {
                    this.delay_0 = Time.time;
                    UMIGame.loginFail = true;
                    UMIGame.loginConnect = true;
                    StartCoroutine(UMIAPI.star.UMIGetUser(this.userName_0, this.QUk8sYq_x, UMICallback.getUserCallback));
                    this.eLoginState_0 = eLoginState.Loading;
                }
            }

            if (GUI.Button(new Rect(0.5f * this.display_0 - 0f, 858f, 30f, 28f), string.Empty, this.guistyle_0))
            {
                if (PlayerPrefs.GetInt("saveUser", 0) != 0)
                {
                    PlayerPrefs.SetInt("saveUser", 0);
                    PlayerPrefs.SetString("userName", string.Empty);
                }
                else
                {
                    PlayerPrefs.SetInt("saveUser", 1);
                }
            }
            if (PlayerPrefs.GetInt("saveUser", 0) != 0)
            {
                PlayerPrefs.SetString("userName", this.userName_0);
                GUI.DrawTexture(new Rect(0.5f * this.display_0 + 8f, 850f, 30f, 30f), this.texture_4);
            }
        }
        if (this.eLoginState_0 == eLoginState.Loading)
        {
            this.RenderNoticeMessage("Loading . . .");
            if (Time.time < this.delay_0 + 0.5f)
            {
                try
                {
                    this.OnConnect();
                }
                catch
                {
                    UMISystem.L0g("ERRSEND()->LOG->processing server.");
                }
                return;
            }
            if (!UMIGame.loginConnect)
            {
                this.delay_0 = Time.deltaTime;
                this.eLoginState_0 = eLoginState.vetifyUser;
                return;
            }
            if (!UMIGame.loginFail)
            {
                this.delay_0 = Time.deltaTime;
                this.eLoginState_0 = eLoginState.Down;
                return;
            }
        }
        if (this.eLoginState_0 == eLoginState.vetifyUser)
        {
            try
            {
                if (req.status == "fail")
                {
                    this.delay_0 = Time.time;
                    this.eLoginState_0 = eLoginState.loginFail;
                }
                else if (req.status == "none")
                {
                    this.delay_0 = Time.time;
                    this.eLoginState_0 = eLoginState.notFound;
                }
                else if (req.status == "successed")
                {
                    this.delay_0 = Time.time;
                    this.eLoginState_0 = eLoginState.connecting;
                }
                else
                {
                    this.delay_0 = Time.deltaTime;
                    this.eLoginState_0 = eLoginState.Down;
                }
            }
            catch
            {
                this.delay_0 = Time.deltaTime;
                this.eLoginState_0 = eLoginState.Down;
            }

        }
        if (this.eLoginState_0 == eLoginState.Down)
        {
            this.delay_0 = Time.time;
            this.eLoginState_0 = eLoginState.serverDown;
        }
        if (this.eLoginState_0 == eLoginState.loginFail)
        {
            if (Time.time < this.delay_0 + 0.5f)
            {
                this.RenderNoticeMessage("Login Fail . . .");
                return;
            }
            this.delay_0 = Time.time;
            this.eLoginState_0 = eLoginState.Login;
            return;

        }
        if (this.eLoginState_0 == eLoginState.notFound)
        {
            if (Time.time < this.delay_0 + 0.5f)
            {
                this.RenderNoticeMessage("No player information.");
                return;
            }
            this.delay_0 = Time.time;
            this.eLoginState_0 = eLoginState.Login;
            return;

        }
        if (this.eLoginState_0 == eLoginState.serverDown)
        {
            if (Time.time < this.delay_0 + 0.5f)
            {
                this.RenderNoticeMessage("Server Down");
                return;
            }
            this.delay_0 = Time.time;
            this.eLoginState_0 = eLoginState.Login;
            return;

        }
        if (this.eLoginState_0 == eLoginState.connecting)
        {
            if (Time.time < this.delay_0 + 0.5f)
            {
                this.RenderNoticeMessage("Connecting . .");
                return;
            }
            this.delay_0 = Time.time;
            this.eLoginState_0 = eLoginState.connected;
            return;

        }
        if (this.eLoginState_0 == eLoginState.connected)
        {
            if (Time.time < this.delay_0 + 0.5f)
            {
                this.RenderNoticeMessage("Retrieving player data . .");
                return;
            }
            this.getDataPlayer();
            this.delay_0 = Time.time;
            this.eLoginState_0 = eLoginState.join;
            return;

        }
        if (this.eLoginState_0 == eLoginState.join)
        {
            if (Time.time < this.delay_0 + 0.5f)
            {
                this.RenderNoticeMessage("Entering Generator Of Aumi . . .");
                return;
            }
            this.delay_0 = Time.time;
            this.OnJoinGame();
            return;
        }
    }
    private void RenderNoticeMessage(string message)
    {
        GUI.DrawTexture(new Rect(0.5f * this.display_0 - 645f / 2.8f, 738f, 735f / 1.4f, 243f / 1.4f), this.texture_3);
        GUI.Label(new Rect(0.5f * this.display_0 - 645f / 2.8f, 738f, 700f / 1.4f, 268f / 1.4f), message, this.guistyle_2);
    }

    private void OnJoinGame()
    {
        UMIGame.LoadNextLevel(2);
    }
    private void OnConnect()
    {
        req = JSON.UMIRespon(UMIData.getStringPlayerData(8));
        UMISystem.L0g(req.status);
    }
    private void getDataPlayer()
    {
        UMIData.Add(1, req.data.namestar);
        UMIData.Add(2, req.data.gender);
    }
}
