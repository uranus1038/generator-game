using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGui : MonoBehaviour
{
    private float delay_0;
    private float display_0;
    private eGameState eGameState;

    Texture texture_0;
    Texture texture_1;
    Texture texture_2;
    Texture texture_3;
    private void Awake()
    {
        this.Init();
        this.InitSkill();
    }
    private void Init()
    {
    }
    private void InitSkill()
    {
        this.texture_0 = (Texture)Resources.Load("GUI/Skill/Dash", typeof(Texture));
        this.texture_1 = (Texture)Resources.Load("GUI/Skill/Navigate", typeof(Texture));
        this.texture_2 = (Texture)Resources.Load("GUI/Skill/Spray", typeof(Texture));
        this.texture_3 = (Texture)Resources.Load("GUI/Skill/Runbar", typeof(Texture));

    }
    private void Start()
    {
        this.eGameState = eGameState.Start;
    }
    private void OnGUI()
    {
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3((float)Screen.height / 1024f, (float)Screen.height / 1024f, 1f));
        GUI.depth = 2;
        this.display_0 = (float)(1024 * Screen.width / Screen.height);
        if (Game.GameOn)
        {
            this.gameIntro();
            this.GameSkill();
        }

    }
    private void gameIntro()
    {
        Game.isMove_0 = true;
        if (this.eGameState == eGameState.Start)
        {
            this.delay_0 = Time.time;
            this.eGameState = eGameState.fadeInGame;
            return; 
        }
        if (this.eGameState == eGameState.fadeInGame)
        {
            if (Time.time < this.delay_0 + 2f)
            {
                GUI.DrawTexture(new Rect(0.5f * this.display_0 - 423f / 2f, Mathf.SmoothStep(1000, 828f, Time.time - this.delay_0), 262f / 2f, 298f / 2f), this.texture_0);
                GUI.DrawTexture(new Rect(0.5f * this.display_0 - 131f / 2f, Mathf.SmoothStep(1000, 830f, Time.time - this.delay_0), 262f / 2f, 298f / 2f), this.texture_1);
                GUI.DrawTexture(new Rect(0.5f * this.display_0 + 161f / 2f, Mathf.SmoothStep(1000, 829f, Time.time - this.delay_0), 262f / 2f, 298f / 2f), this.texture_2);
                return; 
            }
            this.delay_0 = Time.time;
            this.eGameState = eGameState.GamePlay;
            return; 
        }
    }
    private void GameSkill()
    {
        if (this.eGameState == eGameState.GamePlay)
        {
            GUI.DrawTexture(new Rect(0.5f * this.display_0 - 423f / 2f, 828f, 262f / 2f, 298f / 2f), this.texture_0);
            GUI.DrawTexture(new Rect(0.5f * this.display_0 - 131f / 2f,830f, 262f / 2f, 298f / 2f), this.texture_1);
            GUI.DrawTexture(new Rect(0.5f * this.display_0 + 161f / 2f, 829f, 262f / 2f, 298f / 2f), this.texture_2);

            GUI.DrawTexture(new Rect(0.5f * this.display_0 - 418f / 2f, 800f, 836f/2f, 5f), this.texture_3);
        }
    }
}
