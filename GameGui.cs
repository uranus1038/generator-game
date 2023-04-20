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
    private void Awake()
    {
        this.InitSkill();
    }
    private void InitSkill()
    {
        this.texture_0 = (Texture)Resources.Load("GUI/Skill/Dash", typeof(Texture));
        this.texture_1 = (Texture)Resources.Load("GUI/Skill/Navigate", typeof(Texture));
        this.texture_2 = (Texture)Resources.Load("GUI/Skill/Spray", typeof(Texture));
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
            this.fadeGame();
            if (this.eGameState == eGameState.GamePlay)
            {
                this.getSkill();
            }

        }
    }
    private void fadeGame()
    {
        if (this.eGameState == eGameState.Start)
        {
            Game.isMove_0 = true;
            this.delay_0 = Time.time;
            this.eGameState = eGameState.fadeInGame;
            return;
        }
        if (this.eGameState == eGameState.fadeInGame)
        {
            // Skill
            if (Time.time < this.delay_0 + 2f)
            {
                GUI.DrawTexture(new Rect(0.5f * this.display_0 - 363f / 2f, Mathf.SmoothStep(1000, 868f, Time.time - this.delay_0), 262f / 3f, 298f / 3f), this.texture_0);
                GUI.DrawTexture(new Rect(0.5f * this.display_0 - 131f / 2f, Mathf.SmoothStep(1000, 870f, Time.time - this.delay_0), 262f / 3f, 298f / 3f), this.texture_1);
                GUI.DrawTexture(new Rect(0.5f * this.display_0 + 101f / 2f, Mathf.SmoothStep(1000, 869f, Time.time - this.delay_0), 262f / 3f, 298f / 3f), this.texture_2);
                return;
            }
            this.delay_0 = Time.time;
            this.eGameState = eGameState.GamePlay;
            return;
        }
    }
    private void getSkill()
    {
        Game.useSkill = true; 
    }
}
