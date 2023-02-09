using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UMIAPIUser;
using UMI.Network.API;
using UMI.Manager; 
public class LoginGui : MonoBehaviour
{
    private float delay_0;
    private float display_0;
    public string userName_0;
    private string QUk8sYq_x ; 
    //Enum
    public eLoginState eLoginState_0;
    //Texture
    private Texture texture_0;
    private void Awake()
    {
        this.userName_0 = string.Empty;
        this.QUk8sYq_x = string.Empty; 
        this.Init();
        eLoginState_0 = eLoginState.Init;
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
        if (eLoginState_0 == eLoginState.Init)
        {
            
            this.delay_0 = Time.deltaTime;
            eLoginState_0 = eLoginState.login;
            return;
        }
        if (eLoginState_0 == eLoginState.login)
        {
            GUI.DrawTexture(new Rect(0.5f * this.display_0 - 960f, 0f, 1920f, 1024f), this.texture_0);
            // Text Input
            this.userName_0 = GUI.TextField(new Rect(0.5f * this.display_0 - 118f, 713f, 288f, 30f), this.userName_0, 15);
            // Password Input
            this.QUk8sYq_x = GUI.PasswordField(new Rect(0.5f * this.display_0 - 118f, 762f, 288f, 30f), this.QUk8sYq_x, "*"[0], 15);
            if (GUI.Button(new Rect(0.5f * this.display_0 - 156f, 804f, 108f, 37f), "Submit")) 
            {
                StartCoroutine(UMIAPI.hInst.UMIGetUser(this.userName_0));
                UMINetworkManager.hDac.Add(1,this.userName_0);
                UMIGame.LoadNextLevel(2);
            }
        }
    }

}
