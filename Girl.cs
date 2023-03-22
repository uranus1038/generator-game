using System.Collections;
using System.Collections.Generic;

public class Girl : GirlClass
{
    protected float offset_0 = -12f;
    protected float offset_1 = -10f;
    protected float speed_2 = 4.2f;
    void Update()
    {
        this.OnPlayerController();
        this.OnEffectMovementPlayer(this.offset_0, this.offset_1, this.speed_2);
       
    }
    private void Start()
    {
        this.GetGender("fm");
        camera_0 = true;
    }
}
