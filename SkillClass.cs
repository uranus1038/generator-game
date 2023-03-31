public class SkillClass
{
    public float moveSpeedTimer;
    public float delayMoveSpeedTimer;
    public bool[] isTime;
    public bool isLoadBar;
    public bool LoadBar;
    public float[] time;
    public float Value;
    public float minValue;
    public float maxValue;
    public string nType;
    public bool[] nSkill; 
    public eSkillTargetState eSkillTargetState;

    public float speed;
    public int skill;
    public int CD;

    public SkillClass()
    {
        this.moveSpeedTimer = 0F;
        this.Value = 0F;
        this.minValue = 0F;
        this.maxValue = 0F;
        this.CD = 0;
        this.isLoadBar = false;
        this.LoadBar = false;
        this.eSkillTargetState = eSkillTargetState.self; 
    }
    public void setValueDistance(float value)
    {
        this.Value = value;
    }
    public void setValueDistance(float min, float max)
    {
        this.minValue = min;
        this.maxValue = max;
    }
}
