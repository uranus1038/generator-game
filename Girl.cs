using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girl : GirlClass
{
    public float offset_0;
    public float speed_2;
    void Update()
    {
        this.OnPlayerController();
        this.OnEffectMovementPlayer(this.offset_0, this.speed_2);
    }
}
