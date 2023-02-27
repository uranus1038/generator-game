using UnityEngine;
using UMI.Network.API;
using UMI.Manager;
using UMI.Network;
using UMI; 
public class LoginGui : MonoBehaviour
{
    private bool isVerify =true; 
    private float delay_0;
    private float display_0;
    public string userName_0;
    private string QUk8sYq_x ; 
    //Enum
    public eLoginState eLoginState_0;
    //Texture
    private Texture texture_0;
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

    }

    private void OnGUI()
    {
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3((float)Screen.height / 1024f, (float)Screen.height / 1024f, 1f));
        GUI.depth = 2;
        this.display_0 = (float)(1024 * Screen.width / Screen.height);
        //State : 1 
        if (this.eLoginState_0 == eLoginState.Init)
        {
            this.delay_0 = Time.deltaTime;
            this.eLoginState_0 = eLoginState.Login;
            return;
        }
        if (this.eLoginState_0 == eLoginState.Login)
        {
            GUI.DrawTexture(new Rect(0.5f * this.display_0 - 960f, 0f, 1920f, 1024f), this.texture_0);
            // Text Input
            this.userName_0 = GUI.TextField(new Rect(0.5f * this.display_0 - 118f, 713f, 288f, 30f), this.userName_0, 15);
            // Password Input
            this.QUk8sYq_x = GUI.PasswordField(new Rect(0.5f * this.display_0 - 118f, 762f, 288f, 30f), this.QUk8sYq_x, "*"[0], 15);
            if (GUI.Button(new Rect(0.5f * this.display_0 - 156f, 804f, 108f, 37f), "Login")) 
            {
               
                StartCoroutine(UMIAPI.star.UMIGetUser(this.userName_0 , this.QUk8sYq_x , UMICallback.getUserCallback));
                this.eLoginState_0 = eLoginState.vetifyUser;
            }
        }
        if(this.eLoginState_0 == eLoginState.vetifyUser)
        {
           
                req = JSON.UMIRequast(UMIData.hCandy[8].ToString());
                UMISystem.L0g(req.status);
            
            if (UMIData.hCandy[8] ==null)
            {
                if (Time.time < this.delay_0 + 2f)
                {
                    GUI.TextField(new Rect(0.5f * this.display_0 - 125f, 400f, 250f, 38f), "Server Down");
                    return;
                }
                this.delay_0 = Time.time;
                //this.eLoginState_0 = eLoginState.Login; 
                return;
            }
            else
            {
                if (req.status == "fail")
                {
                    if (Time.time < this.delay_0 + 2f)
                    {
                        return;
                    }
                    this.delay_0 = Time.time;
                    this.eLoginState_0 = eLoginState.LoginFail;
                    return;
                }else
                {
                    if (req.status == "none")
                    {
                        if (Time.time < this.delay_0 + 2f)
                        {
                            GUI.TextField(new Rect(0.5f * this.display_0 - 125f, 400f, 250f, 38f), "Not Data");
                            return;
                        }
                        
                        this.eLoginState_0 = eLoginState.Login;
                        this.delay_0 = Time.time;
                        return;
                    }
                }
            }  
        }
        if(this.eLoginState_0 == eLoginState.LoginFail)
        {
            GUI.TextField(new Rect(0.5f * this.display_0 - 125f, 400f, 250f, 38f), "Login Fail . . .");
        }
    }   

}
