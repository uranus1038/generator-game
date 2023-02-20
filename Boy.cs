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
                "boyWalkBack",
                "boyIdel-back",
                "boyWalkForward",
                "boyIdel" ,
                "boyWalkRight" ,
                "boyIdel-right",
                "boyWalkLeft",
                "boyIdel-left" , 
            };

    }
    void Update()
    {
        this.playerController(this.anim);
    }
}
