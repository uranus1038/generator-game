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
    // GUI
    private GUIStyle guistyle_0;

    private UMIJSON JSON = new UMIJSON();
    UMIJSON req;
    private void Awake()
    {
        this.userName_0 = string.Empty;
        this.QUk8sYq_x = string.Empty;
        this.Init();
        this.eLoginState_0 = eLoginState.Init;
    }

    void Init()
    {
        //Texture
        this.texture_0 = (Texture)Resources.Load("GUI/Login/Black", typeof(Texture));
        this.texture_1 = (Texture)Resources.Load("GUI/Login/Login_background01", typeof(Texture));
        this.texture_2 = (Texture)Resources.Load("GUI/Login/Login_bar", typeof(Texture));

        //GUI
        this.guistyle_0 = new GUIStyle();
        this.guistyle_0.font = (Font)Resources.Load("GUI/Fonts/Prompt-Bold", typeof(Font));
        this.guistyle_0.normal.textColor = new Color(0.2f,0.5f,1f,1f);
        this.guistyle_0.fontSize = 18;
        //this.guistyle_0.alignment = TextAnchor.MiddleLeft;
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
        if(this.eLoginState_0 == eLoginState.fadeIn)
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
            this.userName_0 = GUI.TextField(new Rect(0.5f * this.display_0 - 98f, 772f, 288f, 30f), this.userName_0, 15 , this.guistyle_0);
            // Password Input
            this.QUk8sYq_x = GUI.PasswordField(new Rect(0.5f * this.display_0 - 98f, 812f, 288f, 30f), this.QUk8sYq_x, "*"[0], 15 , this.guistyle_0);
            if (GUI.Button(new Rect(0.5f * this.display_0 - 156f, 864f, 108f, 37f), "Login"))
            {
                this.delay_0 = Time.time;
                StartCoroutine(UMIAPI.star.UMIGetUser(this.userName_0, this.QUk8sYq_x, UMICallback.getUserCallback));
                this.eLoginState_0 = eLoginState.Loading;
            }
        }
        if (this.eLoginState_0 == eLoginState.Loading)
        {
            if (Time.time < this.delay_0 + 2f)
            {
                GUI.TextField(new Rect(0.5f * this.display_0 - 125f, 400f, 250f, 38f), "Loading . . .");
                try
                {
                    req = JSON.UMIRespon(UMIData.getStringPlayerData(8));
                    UMISystem.L0g(req.status);
                }
                catch
                {
                    UMISystem.L0g("ERRSEND()->LOG->processing server.");
                }
                return;
            }
            this.delay_0 = Time.deltaTime;
            this.eLoginState_0 = eLoginState.vetifyUser;
            return;
        }
        if (this.eLoginState_0 == eLoginState.vetifyUser)
        {
            if (UMIData.getStringPlayerData(8) == null)
            {
                this.eLoginState_0 = eLoginState.serverDown;
                this.delay_0 = Time.time;
                return;
            }
            else
            if (req.status == "fail")
            {
                this.eLoginState_0 = eLoginState.loginFail;
                this.delay_0 = Time.time;
                return;
            }
            else if (req.status == "none")
            {
                this.eLoginState_0 = eLoginState.notFound;
                this.delay_0 = Time.time;
                return;
            }
            else if (req.status == "successed")
            {
                this.eLoginState_0 = eLoginState.succesed;
                this.delay_0 = Time.time;
                return;
            }
        }
        if (this.eLoginState_0 == eLoginState.loginFail)
        {
            if (Time.time < this.delay_0 + 1.5f)
            {
                GUI.TextField(new Rect(0.5f * this.display_0 - 125f, 400f, 250f, 38f), "Login Fail . . .");
                return;
            }
            this.delay_0 = Time.time;
            this.eLoginState_0 = eLoginState.Login;
            return;

        }
        if (this.eLoginState_0 == eLoginState.notFound)
        {
            if (Time.time < this.delay_0 + 1.5f)
            {
                GUI.TextField(new Rect(0.5f * this.display_0 - 125f, 400f, 250f, 38f), "No player information .");
                return;
            }
            this.delay_0 = Time.time;
            this.eLoginState_0 = eLoginState.Login;
            return;

        }
        if (this.eLoginState_0 == eLoginState.serverDown)
        {
            if (Time.time < this.delay_0 + 1.5f)
            {
                GUI.TextField(new Rect(0.5f * this.display_0 - 125f, 400f, 250f, 38f), "Server Down");
                return;
            }
            this.delay_0 = Time.time;
            this.eLoginState_0 = eLoginState.Login;
            return;

        }
        if (this.eLoginState_0 == eLoginState.succesed)
        {
            this.delay_0 = Time.time;
            this.eLoginState_0 = eLoginState.connecting;
            return;
        }
        if (this.eLoginState_0 == eLoginState.connecting)
        {
            if (Time.time < this.delay_0 + 1.5f)
            {
                GUI.TextField(new Rect(0.5f * this.display_0 - 125f, 400f, 250f, 38f), "Connecting..");
                return;
            }
            this.delay_0 = Time.time;
            this.eLoginState_0 = eLoginState.connected;
            return;

        }
        if (this.eLoginState_0 == eLoginState.connected)
        {
            if (Time.time < this.delay_0 + 1.5f)
            {
                GUI.TextField(new Rect(0.5f * this.display_0 - 125f, 400f, 250f, 38f), "Retrieving player data..");
                return;
            }
            UMIData.Add(1, req.data.namestar);
            UMIData.Add(2, req.data.gender);
            this.delay_0 = Time.time;
            this.eLoginState_0 = eLoginState.join;
            return;

        }
        if (this.eLoginState_0 == eLoginState.join)
        {
            if (Time.time < this.delay_0 + 1.5f)
            {
                GUI.TextField(new Rect(0.5f * this.display_0 - 125f, 400f, 250f, 38f), "Entering Generator Of Aumi ...");
                return;
            }
            this.delay_0 = Time.time;
            UMIGame.LoadNextLevel(2);
            return;
        }


    }

}
