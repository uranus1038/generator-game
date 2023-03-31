using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    protected Animator action;
    private string[] actorState;
    public AnimationControl()
    {
    }
    public void setGenderAnimation(string gender)
    {
        if (gender == "male")
        {
            this.actorState = new string[]
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
        else
        {
            this.actorState = new string[]
           {
              /*0*/  "girlWalkBack",
              /*1*/  "girlIdel-back",
              /*2*/  "girlWalkForward",
              /*3*/  "girlIdel" ,
              /*4*/  "girlWalkRight" ,
              /*5*/  "girlIdel-right",
              /*6*/  "girlWalkLeft",
              /*7*/  "girlIdel-left" , 
              /*8*/  "girlRunForward" ,
              /*9*/  "girlRunBack" , 
              /*10*/ "girlRunRight" , 
              /*11*/ "girlRunLeft" ,

           };
        }
    }
    public string[] getGenderAnimation()
    {
        return this.actorState; 
    }
    private void Awake()
    {
        this.action = GetComponent<Animator>();
    }
    public void OnAnimationPlayerController(int actorState)
    {
        if (actorState == (int)eAction.isWalkForward)
            this.action.Play(this.actorState[2], 0, 0);
        else if (actorState == (int)eAction.isForward)
            this.action.Play(this.actorState[3], 0, 0);
        else if (actorState == (int)eAction.isWalkBack)
            this.action.Play(this.actorState[0], 0, 0);
        else if (actorState == (int)eAction.isBack)
            this.action.Play(this.actorState[1], 0, 0);
        else if (actorState == (int)eAction.isWalkRight)
            this.action.Play(this.actorState[4], 0, 0);
        else if (actorState == (int)eAction.isRight)
            this.action.Play(this.actorState[5], 0, 0);
        else if (actorState == (int)eAction.isWalkLeft)
            this.action.Play(this.actorState[6], 0, 0);
        else if (actorState == (int)eAction.isLeft)
            this.action.Play(this.actorState[7], 0, 0);
        else if (actorState == (int)eAction.isRunForward)
            this.action.Play(this.actorState[8], 0, 0);
        else if (actorState == (int)eAction.isRunBack)
            this.action.Play(this.actorState[9], 0, 0);
        else if (actorState == (int)eAction.isRunRight)
            this.action.Play(this.actorState[10], 0, 0);
        else if (actorState == (int)eAction.isRunLeft)
            this.action.Play(this.actorState[11], 0, 0);

    }
}
