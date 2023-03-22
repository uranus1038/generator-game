using System.Collections;
using System.Collections.Generic;

public class BoyClass : CharacterControl
{
    public static string[] anim = new string[]
            {
              /*0*/  "boyWalkBack",
              /*1*/  "boyIdel-back",
              /*2*/  "boyWalkForward",
              /*3*/  "boyIdel" ,
              /*4*/  "boyWalkRight" ,
              /*5*/  "boyIdel-right",
              /*6*/  "boyWalkLeft",
              /*7*/  "boyIdel-left" , 
              /*8*/  "boyRunForward" ,
              /*9*/  "boyRunBack" , /*10*/  "boyRunRight" , /*11*/  "boyRunLeft" ,

            };
    private void Start()
    {
        this.GetGender("m");
    }

}
