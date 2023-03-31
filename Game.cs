using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static bool camera_0 = false; 
    public static bool camera_1 = false; 
    public static bool isMove_0 = false; 
    public static bool scene_0 = false; 
    public static bool GameOn = false; 

    //Skill
    public static bool isRun= false;
    //Game
    public static bool isCollider = false;
    //skill 
    public static bool[] isSkill = new bool[] { false,true,true };
    public static bool useSkill = false;
    public static bool useRun = false;

}
