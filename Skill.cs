using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Skill : MonoBehaviour
{
    public static SkillClass getSkill(string nameSkill)
    {
        SkillClass setSkill = new SkillClass();
        switch (nameSkill)
        {
            case "c_nDash":
                setSkill.speed = 150f;
                setSkill.skill = 1;
                setSkill.CD = 4;
                setSkill.eSkillTargetState = eSkillTargetState.self; 
                break;
            case "c_nSpray":
                setSkill.skill = 2;
                setSkill.CD = 30;
                setSkill.eSkillTargetState = eSkillTargetState.self;
                break;
        }
        return setSkill;
    }
}
