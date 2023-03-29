public class SkillClass
{
    public float  moveSpeedTimer ;
    public float  delayMoveSpeedTimer ;
    public bool isLoadBar;
    public bool LoadBar;
    public float Value;
    public float minValue;
    public float maxValue;
    public float coolDown; 

    public SkillClass()
    {
        this.moveSpeedTimer = 0F;
        this.Value = 0F;
        this.minValue = 0F;
        this.maxValue = 0F;
        this.coolDown = 0F;
        this.isLoadBar = false;
        this.LoadBar = false;
    
    }
    public void setValueDistance(float value)
    {
        this.Value = value; 
    }
    public void setValueDistance(float min , float max)
    {
        this.minValue = min;
        this.maxValue = max;
    }


}
