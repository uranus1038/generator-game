using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UMI; 
public class LoadingGui : MonoBehaviour
{
    protected float display_0;
    protected float delay_0;
    protected float float_0 = 0.5f;
    eLoadingState eLoadingState_0;
    private Texture texture_0;
    private Texture texture_1;
    private Texture texture_2;
    private Texture texture_3;
    private Texture texture_4;
    public LoadingGui()
    {
        this.float_0 = 0.5f;
        this.eLoadingState_0 = eLoadingState.fadeIn;
    }
    private void Awake()
    {

        this.InitCloudFade();
        texture_0 = (Texture)Resources.Load("GUI/Loading/White", typeof(Texture));
    }
    public void InitCloudFade()
    {
        this.texture_1 = (Texture)Resources.Load("GUI/Lobby/Cloud01", typeof(Texture));
        this.texture_2 = (Texture)Resources.Load("GUI/Lobby/Cloud02", typeof(Texture));
        this.texture_3 = (Texture)Resources.Load("GUI/Lobby/Cloud03", typeof(Texture));
        this.texture_4 = (Texture)Resources.Load("GUI/Lobby/Cloud04", typeof(Texture));
    }
    public virtual void fadeOut(float nFadeTime)
    {
        if (this.eLoadingState_0 != eLoadingState.fadeOut)
        {
            this.eLoadingState_0 = eLoadingState.fadeOut;
            this.delay_0 = Time.time;
            this.float_0 = nFadeTime;
            base.enabled = true; 
        }
    }
    public virtual void CloudFadeIn(float nFadeTime)
    {
        if (this.eLoadingState_0 != eLoadingState.cloudFadeIn)
        {
            this.eLoadingState_0 = eLoadingState.cloudFadeIn;
            this.delay_0 = Time.time;
            this.float_0 = nFadeTime;
            base.enabled = true;
        }
    }
    public void OnGUI()
    {
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3((float)Screen.height / 1024f, (float)Screen.height / 1024f, 1f));
        GUI.depth = 1;
        this.display_0 = (float)(1024 * Screen.width / Screen.height);
        switch (eLoadingState_0)
        {
            case eLoadingState.fadeOut:
                float a2 = Mathf.Lerp(0f, 1f, (Time.time - this.delay_0) / this.float_0);
                Color color2 = GUI.color;
                color2.a = a2;
                GUI.color = color2;
                GUI.DrawTexture(new Rect(0.5f * this.display_0 - 960f, 0f, 1920f, 1024f), this.texture_0);
                break;
            case eLoadingState.cloudFadeIn:
                GUI.DrawTexture(new Rect(Mathf.SmoothStep(0f, -1580f, (Time.time - this.delay_0) / this.float_0), 0f,
           1920f, 1024f), this.texture_1);
                GUI.DrawTexture(new Rect(0f, Mathf.SmoothStep(0f, -880f, (Time.time - this.delay_0) / this.float_0),
                1920f, 1024f), this.texture_2);
                GUI.DrawTexture(new Rect(0f, Mathf.SmoothStep(0f, 880f, (Time.time - this.delay_0) / this.float_0),
                1920f, 1024f), this.texture_3);
                GUI.DrawTexture(new Rect(Mathf.SmoothStep(0f, 1580f, (Time.time - this.delay_0) / this.float_0), 0f,
                1920f, 1024f), this.texture_4);
                break;
        }
    }
}
