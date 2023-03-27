using UnityEngine;

public class SkillClass
{
    public int moveMnet ; 
    SkillClass()
    {
        this.moveMnet = 0; 
    }

    public void setMoveTimer(int time)
    {
        this.moveMnet = time; 
    }
}
