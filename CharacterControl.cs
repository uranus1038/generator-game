using UnityEngine;
using UMI.Network.Client;
using UMI;
using UMI.Manager.Period;
public class CharacterControl : MonoBehaviour
{
    private float delay_0;
    private float display_0;
    public float float_0;
    public float float_1;
    public float offset_0;
    public float offset_1;
    public float speed_2;
    public float time_0;
    //Animator control
    public Animator action;
    public AnimationControl anim_0;
    public SkillClass skill;
    //Speed
    public float speed_1;
    public float speed_3;
    // Rigibody
    public Rigidbody2D rigidbody2d;
    // Current position
    public Vector3 position;
    public Vector2 moveMent;
    public bool isMove;
    public bool isMine;
    public bool isTime;
    //Array string  
    public string[] actorState;
    public TimeManager cooldown;
    private eCharacter eCharacter_0;
    private eSkillTargetState eSkillTargetState_0; 
    Texture texture_0;
    Texture texture_1;
    Texture texture_2;
    Texture texture_3;
    Texture texture_4;
    Texture texture_5;
    GUIStyle style_0;
    GUIStyle style_1;
    GUIStyle style_2;
    public CharacterControl()
    {
        this.skill = new SkillClass();
    }
    private void Awake()
    {
        this.Init();
        this.cooldown = (TimeManager)this.GetComponent(typeof(TimeManager));
        this.eCharacter_0 = eCharacter.start;
    }
    private void Init()
    {
        this.texture_0 = (Texture)Resources.Load("GUI/Skill/Dash", typeof(Texture));
        this.texture_1 = (Texture)Resources.Load("GUI/Skill/Navigate", typeof(Texture));
        this.texture_2 = (Texture)Resources.Load("GUI/Skill/Spray", typeof(Texture));
        this.texture_3 = (Texture)Resources.Load("GUI/Skill/Runbar", typeof(Texture));
        this.texture_4 = (Texture)Resources.Load("GUI/Skill/PowerRun", typeof(Texture));
        this.texture_5 = (Texture)Resources.Load("GUI/Skill/CooldownSkill_b", typeof(Texture));

        this.style_0 = new GUIStyle();
        this.style_0.normal.background = (Texture2D)((Texture)Resources.Load("GUI/Game/Manual", typeof(Texture)));
        this.style_0.hover.background = (Texture2D)((Texture)Resources.Load("GUI/Game/Manual_h", typeof(Texture)));
        this.style_1 = new GUIStyle();
        this.style_1.font = (Font)Resources.Load("GUI/Fonts/Prompt-Bold", typeof(Font));
        this.style_1.normal.textColor = new Color(252f, 252f, 252f, 1f);
        this.style_1.fontSize = 22;
        this.style_1.alignment = TextAnchor.LowerLeft;
        this.style_2 = new GUIStyle();
        this.style_2.font = (Font)Resources.Load("GUI/Fonts/Prompt-Bold", typeof(Font));
        this.style_2.normal.textColor = new Color(252f, 252f, 252f, 1f);
        this.style_2.fontSize = 58;
        this.style_2.alignment = TextAnchor.MiddleCenter;
    }
    private void OnGUI()
    {

        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3((float)Screen.height / 1024f, (float)Screen.height / 1024f, 1f));
        GUI.depth = 2;
        this.display_0 = (float)(1024 * Screen.width / Screen.height);
        if (Game.useSkill)
        {
            if (this.eCharacter_0 == eCharacter.start)
            {
                //Run
                this.skill.moveSpeedTimer = 180f; // cooldown 3 sec
                this.skill.delayMoveSpeedTimer = 300f; // cool down 5 sec
                this.skill.setValueDistance(418f);
                this.delay_0 = Time.time;
                this.eCharacter_0 = eCharacter.gamePlay;
            }
            if (this.eCharacter_0 == eCharacter.gamePlay)
            {
                this.SkillManager();
                this.GameManual(); 
            }

        }


    }
    public void SkillManager()
    {
        #region Skill Cooldown
        GUI.DrawTexture(new Rect(0.5f * this.display_0 - 423f / 2f, 828f, 262f / 2f, 298f / 2f), this.texture_0);
        GUI.Box(new Rect(0.5f * this.display_0 - 383f / 2f, 828f, 262f / 2f, 260f / 2f), "1", this.style_1);
        if (!Game.isSkill[1])
        {
            GUI.DrawTexture(new Rect(0.5f * this.display_0 - 423f / 2f, 833f, 263f / 2f, 298f / 2f), this.texture_5);
            GUI.Box(new Rect(0.5f * this.display_0 - 423f / 2f, 828f, 262f / 2f, 298f / 2f), this.cooldown.getTime(1), this.style_2);
            if (this.cooldown.nextTime(1))
            {
                Game.isSkill[1] = true;
            }
        }

        GUI.DrawTexture(new Rect(0.5f * this.display_0 - 131f / 2f, 830f, 262f / 2f, 298f / 2f), this.texture_1);
        GUI.Box(new Rect(0.5f * this.display_0 - 91f / 2f, 830f, 262f / 2f, 260f / 2f), "2", this.style_1);

        GUI.DrawTexture(new Rect(0.5f * this.display_0 + 161f / 2f, 829f, 262f / 2f, 298f / 2f), this.texture_2);
        GUI.Box(new Rect(0.5f * this.display_0 + 201f / 2f, 829f, 262f / 2f, 260f / 2f), "3", this.style_1);
        if (!Game.isSkill[2])
        {
            GUI.DrawTexture(new Rect(0.5f * this.display_0 + 161f / 2f, 829f, 263f / 2f, 298f / 2f), this.texture_5);
            GUI.Box(new Rect(0.5f * this.display_0 + 161f / 2f, 829f, 263f / 2f, 298f / 2f), this.cooldown.getTime(2), this.style_2);
            if (this.cooldown.nextTime(2))
            {
                Game.isSkill[2] = true;
            }
        }
        #endregion

        GUI.DrawTexture(new Rect(0.5f * this.display_0 - 540f / 2f, 780f, 180f / 4f, 180f / 4f), this.texture_4);

        #region SkillRun
        if (Game.isMove_0)
        {
            if (!this.skill.isLoadBar)
            {
                GUI.DrawTexture(new Rect(0.5f * this.display_0 - 418f / 2f, 800f, 836f / 2f, 5f), this.texture_3);
            }
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                this.delay_0 = Time.time;
                this.skill.LoadBar = true;
            }
            else
            {
                if (this.skill.LoadBar)
                {
                    this.skill.isLoadBar = true;
                    GUI.DrawTexture(new Rect(0.5f * this.display_0 - 418f / 2f, 800f, this.float_0 = Mathf.Lerp(this.skill.Value, 0,
                        (Time.time - this.delay_0) / this.skill.moveSpeedTimer), 3.5f), this.texture_3);
                    this.skill.setValueDistance(this.float_0);
                }

            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                this.delay_0 = Time.time;
                this.skill.LoadBar = false;
            }
            else
            {
                if (!this.skill.LoadBar)
                {
                    GUI.DrawTexture(new Rect(0.5f * this.display_0 - 418f / 2f, 800f, this.float_1 = Mathf.Lerp(this.skill.Value, 418,
                        (Time.time - this.delay_0) / this.skill.delayMoveSpeedTimer), 3.5f), this.texture_3);
                    this.skill.setValueDistance(this.float_1);
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
    private void GameManual()
    {
        if (GUI.Button(new Rect(0.5f * this.display_0 + 448f / 2f, 885f, 180f / 2.5f, 180f / 2.5f), string.Empty, this.style_0))
        {

        }
    }
    public void AddSkill(SkillClass skill)
    {
        this.speed_1 = skill.speed;
        this.cooldown.getSkillCD(skill.skill, skill.CD);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check Collision
        if (collision.gameObject.name == "swapQuestion")
        {
            UMI.UMISystem.L0g("enter");
        }
        else if (collision.gameObject.name == "femaleCharPlayer(Clone)")
        {

        }
    }
}