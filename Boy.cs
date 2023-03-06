using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boy : BoyClass
{
    protected float offset_0 = -16f;
    protected float speed_2 = 4.2f;
    void Update()
    {
        this.OnPlayerController();
        this.OnEffectMovementPlayer(this.offset_0,this.speed_2);
    }
}
