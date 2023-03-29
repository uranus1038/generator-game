using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Skill : MonoBehaviour
{
    private static SkillClass setSkill; 
    public static SkillClass getSkill(string nSkill)
    {
        setSkill = new SkillClass();
        switch (nSkill)
        {
            case "c_nDash":
                setSkill.nSkill[1] = true; 
                break;
            case "c_nSpray":
                setSkill.nSkill[2] = true;
                break;
        }
        return setSkill; 
    }

}
