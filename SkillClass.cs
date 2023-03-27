using UnityEngine;

public class SkillClass
{
    public float  moveSpeedTimer ;
    public float  delayMoveSpeedTimer ;
    public bool isLoadBar;
    public bool LoadBar;
    public float Value;

    public SkillClass()
    {
        this.moveSpeedTimer = 0F;
        this.Value = 0F;
        this.isLoadBar = false;
        this.LoadBar = false;
    
    }
    public void setValueDistance(float value)
    {
        this.Value = value; 
    }
 

}
