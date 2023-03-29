using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UMI.Manager.Period;
public class GameGui : MonoBehaviour
{
    private float delay_0;
    private float display_0;
    private float float_0;
    private float float_1;
    private eGameState eGameState;
    private SkillClass skillCharacter;
    private TimeManager cooldown;
    Texture texture_0;
    Texture texture_1;
    Texture texture_2;
    Texture texture_3;
    Texture texture_4;
    Texture texture_5;
    GUIStyle style_0;
    GUIStyle style_1;
    private void Awake()
    {
        this.Init();
        this.InitSkill();
    }
    private void Init()
    {
        this.skillCharacter = new SkillClass();
        this.style_0 = new GUIStyle();
        this.style_0.normal.background = (Texture2D)((Texture)Resources.Load("GUI/Game/Manual", typeof(Texture)));
        this.style_0.hover.background = (Texture2D)((Texture)Resources.Load("GUI/Game/Manual_h", typeof(Texture)));
        this.style_1 = new GUIStyle();
        this.style_1.font = (Font)Resources.Load("GUI/Fonts/Prompt-Bold", typeof(Font));
        this.style_1.normal.textColor = new Color(252f, 252f, 252f, 1f);
        this.style_1.fontSize = 22;
        this.style_1.alignment = TextAnchor.LowerLeft;
    }
    private void InitSkill()
    {
        this.texture_0 = (Texture)Resources.Load("GUI/Skill/Dash", typeof(Texture));
        this.texture_1 = (Texture)Resources.Load("GUI/Skill/Navigate", typeof(Texture));
        this.texture_2 = (Texture)Resources.Load("GUI/Skill/Spray", typeof(Texture));
        this.texture_3 = (Texture)Resources.Load("GUI/Skill/Runbar", typeof(Texture));
        this.texture_4 = (Texture)Resources.Load("GUI/Skill/PowerRun", typeof(Texture));
        this.texture_5 = (Texture)Resources.Load("GUI/Skill/CooldownSkill_b", typeof(Texture));

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
            if (this.eGameState == eGameState.GamePlay)
            {
                this.GameSkillControl();
                this.GameManual();
            }

        }

    }
    private void gameIntro()
    {
        if (this.eGameState == eGameState.Start)
        {
            Game.isMove_0 = true;
            this.skillCharacter.moveSpeedTimer = 180f; // cooldown 3 sec
            this.skillCharacter.delayMoveSpeedTimer = 300f; // cool down 5 sec
            this.skillCharacter.setValueDistance(418f);
            this.delay_0 = Time.time;
            this.eGameState = eGameState.fadeInGame;
            return;
        }
        if (this.eGameState == eGameState.fadeInGame)
        {
            // Skill
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
    private void GameManual()
    {
        if (GUI.Button(new Rect(0.5f * this.display_0 + 448f / 2f, 885f, 180f / 2.5f, 180f / 2.5f), string.Empty, this.style_0))
        {

        }
    }
    private void GameSkillControl()
    {
        if (Input.GetKeyDown("1") && Game.isSkill[1])
        {
            UMI.UMISystem.Log("IS SKILL");
        }
        if (Input.GetKeyDown("3") && Game.isSkill[2])
        {

        }

        GUI.DrawTexture(new Rect(0.5f * this.display_0 - 423f / 2f, 828f, 262f / 2f, 298f / 2f), this.texture_0);
        GUI.Box(new Rect(0.5f * this.display_0 - 383f / 2f, 828f, 262f / 2f, 260f / 2f), "1", this.style_1);
        if (!Game.isSkill[1])
        {
            GUI.DrawTexture(new Rect(0.5f * this.display_0 - 423f / 2f, 833f, 263f / 2f, 298f / 2f), this.texture_5);
        }

        GUI.DrawTexture(new Rect(0.5f * this.display_0 - 131f / 2f, 830f, 262f / 2f, 298f / 2f), this.texture_1);
        GUI.Box(new Rect(0.5f * this.display_0 - 91f / 2f, 830f, 262f / 2f, 260f / 2f), "2", this.style_1);

        GUI.DrawTexture(new Rect(0.5f * this.display_0 + 161f / 2f, 829f, 262f / 2f, 298f / 2f), this.texture_2);
        GUI.Box(new Rect(0.5f * this.display_0 + 201f / 2f, 829f, 262f / 2f, 260f / 2f), "3", this.style_1);
        if (!Game.isSkill[2])
        {
            GUI.DrawTexture(new Rect(0.5f * this.display_0 + 161f / 2f, 829f, 263f / 2f, 298f / 2f), this.texture_5);
        }


        GUI.DrawTexture(new Rect(0.5f * this.display_0 - 540f / 2f, 780f, 180f / 4f, 180f / 4f), this.texture_4);
        #region SkillRun
        if (Game.isMove_0)
        {
            if (!this.skillCharacter.isLoadBar)
            {
                GUI.DrawTexture(new Rect(0.5f * this.display_0 - 418f / 2f, 800f, 836f / 2f, 5f), this.texture_3);
            }
            if (Input.GetButtonDown("left shift"))
            {
                this.delay_0 = Time.time;
                this.skillCharacter.LoadBar = true;
            }
            else
            {
                if (this.skillCharacter.LoadBar)
                {
                    this.skillCharacter.isLoadBar = true;
                    GUI.DrawTexture(new Rect(0.5f * this.display_0 - 418f / 2f, 800f, this.float_0 = Mathf.Lerp(this.skillCharacter.Value, 0,
                        (Time.time - this.delay_0) / this.skillCharacter.moveSpeedTimer), 3.5f), this.texture_3);
                    this.skillCharacter.setValueDistance(this.float_0);
                }

            }
            if (Input.GetButtonUp("left shift"))
            {
                this.delay_0 = Time.time;
                this.skillCharacter.LoadBar = false;
            }
            else
            {
                if (!this.skillCharacter.LoadBar)
                {
                    GUI.DrawTexture(new Rect(0.5f * this.display_0 - 418f / 2f, 800f, this.float_1 = Mathf.Lerp(this.skillCharacter.Value, 418,
                        (Time.time - this.delay_0) / this.skillCharacter.delayMoveSpeedTimer), 3.5f), this.texture_3);
                    this.skillCharacter.setValueDistance(this.float_1);
                    this.float_0 = float_1;
                }
            }
            if (this.float_0 <= 8f)
            {
                Game.isRun = false;
            }
            else
            {
                Game.isRun = true;
            }
        }
        #endregion
    }
}
