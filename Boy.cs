using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boy : CharacterControl
{
    protected string[] anim;
    private void Awake()
    {
        this.anim = new string[]
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

    }
    void Update()
    {
        this.playerController(this.anim);
    }
}
