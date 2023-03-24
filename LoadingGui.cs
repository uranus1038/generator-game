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
    private Texture texture_5;
    private GUIStyle style_0;
    public LoadingGui()
    {
        this.float_0 = 0.5f;
        this.eLoadingState_0 = eLoadingState.Init;
    }
    private void Awake()
    {
        this.InitCloudFade();
        this.Init();
    }
    private void Init()
    {
        texture_0 = (Texture)Resources.Load("GUI/Loading/White", typeof(Texture));
        texture_5 = (Texture)Resources.Load("GUI/Loading/Black", typeof(Texture));
        this.style_0 = new GUIStyle();
        this.style_0.font = (Font)Resources.Load("GUI/Fonts/Prompt-Bold", typeof(Font));
        this.style_0.fontSize = 78;
        this.style_0.normal.textColor = new Color(0f, 0.1f, 0.2f, 0.8f);
        this.style_0.alignment = TextAnchor.MiddleCenter; 
    }
    private void InitCloudFade()
    {
        this.texture_1 = (Texture)Resources.Load("GUI/Loading/Cloud01", typeof(Texture));
        this.texture_2 = (Texture)Resources.Load("GUI/Loading/Cloud02", typeof(Texture));
        this.texture_3 = (Texture)Resources.Load("GUI/Loading/Cloud03", typeof(Texture));
        this.texture_4 = (Texture)Resources.Load("GUI/Loading/Cloud04", typeof(Texture));
    }
    public virtual void fadeShiro()
    {
        if (this.eLoadingState_0 != eLoadingState.Shiro)
        {
            this.eLoadingState_0 = eLoadingState.Shiro;
            this.delay_0 = Time.time;
            this.float_0 = 0.5f;
            base.enabled = true;
        }
    }
    public virtual void fadeShiroTimer(float nFadeTime)
    {
        if (this.eLoadingState_0 != eLoadingState.shiroTimer)
        {
            this.eLoadingState_0 = eLoadingState.shiroTimer;
            this.delay_0 = Time.time;
            this.float_0 = nFadeTime;
            base.enabled = true;
        }
    }
    public virtual void fadeKuro()
    {
        if (this.eLoadingState_0 != eLoadingState.Kuro)
        {   
            this.eLoadingState_0 = eLoadingState.Kuro;
            this.delay_0 = Time.time;
            base.enabled = true;
        }
    }
    public virtual void fadeOut()
    {
        if (this.eLoadingState_0 != eLoadingState.fadeOut)
        {
            this.eLoadingState_0 = eLoadingState.fadeOut;
            this.delay_0 = Time.time;
            this.float_0 = 0.5f;
            base.enabled = true;
        }
    }
    public virtual void fadeOutTimer(float nFadeTime)
    {
        if (this.eLoadingState_0 != eLoadingState.fadeOut)
        {
            this.eLoadingState_0 = eLoadingState.fadeOut;
            this.delay_0 = Time.time;
            this.float_0 = nFadeTime;
            base.enabled = true;
        }
    }
    public virtual void fadeIn()
    {
        if (this.eLoadingState_0 != eLoadingState.fadeIn)
        {
            this.eLoadingState_0 = eLoadingState.fadeIn;
            this.delay_0 = Time.time;
            this.float_0 = 0.5f;
            base.enabled = true;
        }
    }
    public virtual void fadeInTimer(float nFadeTime)
    {
        if (this.eLoadingState_0 != eLoadingState.fadeIn)
        {
            this.eLoadingState_0 = eLoadingState.fadeIn;
            this.delay_0 = Time.time;
            this.float_0 = nFadeTime;
            base.enabled = true;
        }
    }
    public virtual void CloudFadeIn()
    {
        if (this.eLoadingState_0 != eLoadingState.cloudFadeIn)
        {
            this.eLoadingState_0 = eLoadingState.cloudFadeIn;
            this.delay_0 = Time.time;
            this.float_0 = 0.5f;
            base.enabled = true;
        }
    }
    public virtual void CloudFadeInTimer(float nFadeTime)
    {
        if (this.eLoadingState_0 != eLoadingState.cloudFadeIn)
        {
            this.eLoadingState_0 = eLoadingState.cloudFadeIn;
            this.delay_0 = Time.time;
            this.float_0 = nFadeTime;
            base.enabled = true;
        }
    }
    public virtual void startGame()
    {
        if (this.eLoadingState_0 != eLoadingState.startGame)
        {
            this.eLoadingState_0 = eLoadingState.startGame;
            this.delay_0 = Time.time;
            this.float_0 = 2.5f;
            base.enabled = true;
        }
    }
    public void setState(int num)
    {
        switch(num)
        {
            case 100:
                this.eLoadingState_0 = eLoadingState.Init;
                break; 
        }
    }
    public void setStateDefault()
    {
        this.eLoadingState_0 = eLoadingState.Init;
    }
    public void OnGUI()
    {
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3((float)Screen.height / 1024f, (float)Screen.height / 1024f, 1f));
        GUI.depth = 1;
        float num = (float)Screen.height / 768f;
        this.display_0 = (float)(1024 * Screen.width / Screen.height);
        switch (eLoadingState_0)
        {
            case eLoadingState.fadeOut:
                float a = Mathf.Lerp(0f, 1f, (Time.time - this.delay_0) / this.float_0);
                Color color = GUI.color;
                color.a = a;
                GUI.color = color;
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
            case eLoadingState.fadeIn:
                a = Mathf.Lerp(1f, 0f, (Time.time - this.delay_0) / this.float_0);
                color = GUI.color;
                color.a = a;
                GUI.color = color;
                GUI.DrawTexture(new Rect(0.5f * this.display_0 - 960f, 0f, 1920f, 1024f), this.texture_0);
                break;
            case eLoadingState.Shiro :
                a = 2f * (this.delay_0 + this.float_0 - Time.time);
                color = GUI.color;
                color.a = a;
                GUI.color = color;
                GUI.DrawTexture(new Rect(0.5f * this.display_0 - 960f, 0f, 1920f, 1024f), this.texture_0);
                Color color2 = GUI.color;
                color2.a = 1f;
                GUI.color = color2;
                break;
            case eLoadingState.shiroTimer :
                a = 2f * (this.delay_0 + this.float_0 - Time.time);
                color = GUI.color;
                color.a = a;
                GUI.color = color;
                GUI.DrawTexture(new Rect(0.5f * this.display_0 - 960f, 0f, 1920f, 1024f), this.texture_0);
                color2 = GUI.color;
                color2.a = 1f;
                GUI.color = color2;
                break;
            case eLoadingState.Kuro:
                a = 2f * (this.delay_0 + 0.5f - Time.time);
                color = GUI.color;
                color.a = a;
                GUI.color = color;
                GUI.DrawTexture(new Rect(0.5f * this.display_0 - 960f, 0f, 1920f, 1024f), this.texture_5);
                color2 = GUI.color;
                color2.a = 1f;
                GUI.color = color2;
                break;
            case eLoadingState.startGame:
                a = Mathf.Lerp(0f, 1f, (Time.time - this.delay_0) / this.float_0);
                color = GUI.color;
                color.a = a;
                GUI.color = color;
                GUI.Box(new Rect(0.5f * this.display_0 -400f, 312f, 800f, 300f), "START MISSION !",this.style_0);
                break;
        }
    }
}

