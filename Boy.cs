using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UMI.Network.Client;
using UMI;

public class Boy : MonoBehaviour 
{
    protected CharacterControl mChar; 
    private void Awake()
    {
        this.mChar = (CharacterControl)this.GetComponent(typeof(CharacterControl));
        this.mChar.rigidbody2d = (Rigidbody2D)this.GetComponent(typeof(Rigidbody2D));
        this.mChar.action = GetComponent<Animator>();
        this.mChar.anim_0 = GetComponent<AnimationControl>();
    }
    private void Start()
    {
        this.mChar.anim_0.setGenderAnimation("male");
        this.mChar.actorState = this.mChar.anim_0.getGenderAnimation();
    }
    private void Update()
    {
        this.AddAnimation();
    }
    void FixedUpdate()
    {
        this.PlayerControl();
        this.OnEffectMovementPlayer(this.mChar.offset_0, this.mChar.offset_1, this.mChar.speed_2);
    }
    private void PlayerControl()
    {
        #region Control
        if (Game.isMove_0)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            this.mChar.rigidbody2d.velocity = new Vector2(horizontalInput * this.mChar.speed_1, this.mChar.rigidbody2d.velocity.y);
            float VerticalInput = Input.GetAxis("Vertical");
            this.mChar.rigidbody2d.velocity = new Vector2(this.mChar.rigidbody2d.velocity.x, VerticalInput * this.mChar.speed_1);
        }
        #endregion
        this.mChar.position = this.transform.position;

        UMIClientSend.reqPlayerMoveMent(this.mChar.position);
    }
    protected void AddAnimation()
    {
        if (Game.isMove_0)
        {
            #region Input Animation
            #region Move
            // get W 
            if (Input.GetButton("w"))
            {
                //this.transform.position += new Vector3(0, mChar.speed_1 * Time.deltaTime, 0);
                if (Input.GetButtonDown("w"))
                {
                    this.mChar.action.Play(this.mChar.actorState[0], 0, 0f);
                    UMIClientSend.reqAnimation((int)eAction.isWalkBack);
                }
            }
            else if (Input.GetButtonUp("w"))
            {
                if (Input.GetButton("s") && Input.GetButtonUp("w"))
                {
                    this.mChar.action.Play(this.mChar.actorState[2], 0, 0f);
                    UMIClientSend.reqAnimation((int)eAction.isWalkForward);
                }
                else if (Input.GetButton("d") && Input.GetButtonUp("w"))
                {
                    this.mChar.action.Play(this.mChar.actorState[4], 0, 0f);
                    UMIClientSend.reqAnimation((int)eAction.isWalkRight);
                }
                else if (Input.GetButton("a") && Input.GetButtonUp("w"))
                {
                    this.mChar.action.Play(this.mChar.actorState[6], 0, 0f);
                    UMIClientSend.reqAnimation((int)eAction.isWalkLeft);
                }
                else
                {
                    this.mChar.action.Play(this.mChar.actorState[1], 0, 0f);
                    UMIClientSend.reqAnimation((int)eAction.isBack);
                }
            }
            // get S
            if (Input.GetButton("s"))
            {
                //this.transform.position += new Vector3(0, -mChar.speed_1 * Time.deltaTime, 0);

                if (Input.GetButtonDown("s"))
                {
                    this.mChar.action.Play(this.mChar.actorState[2], 0, 0f);
                    UMIClientSend.reqAnimation((int)eAction.isWalkForward);
                }
            }
            else if (Input.GetButtonUp("s"))
            {
                if (Input.GetButtonUp("s") && Input.GetButton("w"))
                {
                    this.mChar.action.Play(this.mChar.actorState[0], 0, 0f);
                    UMIClientSend.reqAnimation((int)eAction.isWalkBack);
                }
                else if (Input.GetButtonUp("s") && Input.GetButton("d"))
                {
                    this.mChar.action.Play(this.mChar.actorState[4], 0, 0f);
                    UMIClientSend.reqAnimation((int)eAction.isWalkRight);
                }
                else if (Input.GetButtonUp("s") && Input.GetButton("a"))
                {
                    this.mChar.action.Play(this.mChar.actorState[6], 0, 0f);
                    UMIClientSend.reqAnimation((int)eAction.isWalkLeft);
                }
                else
                {
                    this.mChar.action.Play(this.mChar.actorState[3], 0, 0f);
                    UMIClientSend.reqAnimation((int)eAction.isForward);
                }
            }
            // get D
            if (Input.GetButton("d"))
            {
                //this.transform.position += new Vector3(mChar.speed_1 * Time.deltaTime, 0, 0);
                if (Input.GetButton("d") != Input.GetButton("w") ||
                    Input.GetButton("d") != Input.GetButton("s"))
                {
                    if (Input.GetButtonDown("d"))
                    {
                        this.mChar.action.Play(this.mChar.actorState[4], 0, 0f);
                        UMIClientSend.reqAnimation((int)eAction.isWalkRight);
                    }
                }
            }
            else if (Input.GetButtonUp("d"))
            {
                if (Input.GetButton("a") && Input.GetButtonUp("d"))
                {
                    this.mChar.action.Play(this.mChar.actorState[6], 0, 0f);
                    UMIClientSend.reqAnimation((int)eAction.isWalkLeft);
                }
                else if (Input.GetButtonUp("d") && Input.GetButton("w"))
                {
                    this.mChar.action.Play(this.mChar.actorState[0], 0, 0f);
                    UMIClientSend.reqAnimation((int)eAction.isWalkBack);
                }
                else if (Input.GetButtonUp("d") && Input.GetButton("s"))
                {
                    this.mChar.action.Play(this.mChar.actorState[2], 0, 0f);
                    UMIClientSend.reqAnimation((int)eAction.isWalkForward);
                }
                else
                {
                    this.mChar.action.Play(this.mChar.actorState[5], 0, 0f);
                    UMIClientSend.reqAnimation((int)eAction.isRight);
                }
            }
            // get A
            if (Input.GetButton("a"))
            {
               // this.transform.position += new Vector3(-mChar.speed_1 * Time.deltaTime, 0, 0);
                if (Input.GetButton("a") != Input.GetButton("w") ||
                   Input.GetButton("a") != Input.GetButton("s"))
                {
                    if (Input.GetButtonDown("a"))
                    {
                        this.mChar.action.Play(this.mChar.actorState[6], 0, 0f);
                        UMIClientSend.reqAnimation((int)eAction.isWalkLeft);
                    }
                }
            }
            else if (Input.GetButtonUp("a"))
            {
                if (Input.GetButton("d") && Input.GetButtonUp("a"))
                {
                    this.mChar.action.Play(this.mChar.actorState[4], 0, 0f);
                    UMIClientSend.reqAnimation((int)eAction.isWalkRight);
                }
                else if (Input.GetButtonUp("a") && Input.GetButton("w"))
                {
                    UMISystem.L0g(" yes");
                    this.mChar.action.Play(this.mChar.actorState[0], 0, 0f);
                    UMIClientSend.reqAnimation((int)eAction.isWalkBack);
                }
                else if (Input.GetButtonUp("a") && Input.GetButton("s"))
                {
                    this.mChar.action.Play(this.mChar.actorState[2], 0, 0f);
                    UMIClientSend.reqAnimation((int)eAction.isWalkForward);
                }
                else
                {
                    UMISystem.L0g(" yes");
                    this.mChar.action.Play(this.mChar.actorState[7], 0, 0f);
                    UMIClientSend.reqAnimation((int)eAction.isLeft);
                }
            }
            #endregion
            #region Run
            // Get Run 

            //Key S
            if (Game.isRun)
            {
                this.mChar.isMove = true;
                if (Input.GetButton("left shift") && Input.GetButton("s"))
                {
                    if (Input.GetButtonDown("s"))
                    {
                        this.mChar.action.Play(this.mChar.actorState[8], 0, 0f);
                        UMIClientSend.reqAnimation((int)eAction.isRunForward);
                    }
                    else if (Input.GetButtonDown("left shift"))
                    {
                        this.mChar.action.Play(this.mChar.actorState[8], 0, 0f);
                        UMIClientSend.reqAnimation((int)eAction.isRunForward);
                    }
                }
                else if (Input.GetButton("left shift") && Input.GetButtonUp("s"))
                {
                    if (Input.GetButton("d"))
                    {
                        this.mChar.action.Play(this.mChar.actorState[10], 0, 0f);
                        UMIClientSend.reqAnimation((int)eAction.isRunRight);
                    }
                    if (Input.GetButton("w"))
                    {
                        this.mChar.action.Play(this.mChar.actorState[9], 0, 0f);
                        UMIClientSend.reqAnimation((int)eAction.isRunBack);
                    }
                    if (Input.GetButton("a"))
                    {
                        this.mChar.action.Play(this.mChar.actorState[11], 0, 0f);
                        UMIClientSend.reqAnimation((int)eAction.isRunLeft);
                    }
                }
                //Key W
                if (Input.GetButton("left shift") && Input.GetButton("w"))
                {
                    if (Input.GetButtonDown("w"))
                    {
                        this.mChar.action.Play(this.mChar.actorState[9], 0, 0f);
                        UMIClientSend.reqAnimation((int)eAction.isRunBack);
                    }
                    else if (Input.GetButtonDown("left shift"))
                    {
                        this.mChar.action.Play(this.mChar.actorState[9], 0, 0f);
                        UMIClientSend.reqAnimation((int)eAction.isRunBack);
                    }
                }
                else if (Input.GetButton("left shift") && Input.GetButtonUp("w"))
                {
                    if (Input.GetButton("d"))
                    {
                        this.mChar.action.Play(this.mChar.actorState[10], 0, 0f);
                        UMIClientSend.reqAnimation((int)eAction.isRunRight);
                    }
                    if (Input.GetButton("s"))
                    {
                        this.mChar.action.Play(this.mChar.actorState[8], 0, 0f);
                        UMIClientSend.reqAnimation((int)eAction.isRunForward);
                    }
                    if (Input.GetButton("a"))
                    {
                        this.mChar.action.Play(this.mChar.actorState[11], 0, 0f);
                        UMIClientSend.reqAnimation((int)eAction.isRunLeft);
                    }
                }
                //Key D
                if (Input.GetButton("left shift") && Input.GetButton("d"))
                {
                    if (Input.GetButtonDown("d"))
                    {
                        this.mChar.action.Play(this.mChar.actorState[10], 0, 0f);
                        UMIClientSend.reqAnimation((int)eAction.isRunRight);
                    }
                    else if (Input.GetButtonDown("left shift"))
                    {
                        this.mChar.action.Play(this.mChar.actorState[10], 0, 0f);
                        UMIClientSend.reqAnimation((int)eAction.isRunRight);
                    }
                }
                else if (Input.GetButton("left shift") && Input.GetButtonUp("d"))
                {
                    if (Input.GetButton("w"))
                    {
                        this.mChar.action.Play(this.mChar.actorState[9], 0, 0f);
                        UMIClientSend.reqAnimation((int)eAction.isRunBack);
                    }
                    else if (Input.GetButton("s"))
                    {
                        this.mChar.action.Play(this.mChar.actorState[8], 0, 0f);
                        UMIClientSend.reqAnimation((int)eAction.isRunForward);
                    }
                    else if (Input.GetButton("a"))
                    {
                        this.mChar.action.Play(this.mChar.actorState[11], 0, 0f);
                        UMIClientSend.reqAnimation((int)eAction.isRunLeft);
                    }
                }
                //Key A
                if (Input.GetButton("left shift") && Input.GetButton("a"))
                {
                    if (Input.GetButtonDown("a"))
                    {
                        this.mChar.action.Play(this.mChar.actorState[11], 0, 0f);
                        UMIClientSend.reqAnimation((int)eAction.isRunLeft);
                    }
                    else if (Input.GetButtonDown("left shift"))
                    {
                        this.mChar.action.Play(this.mChar.actorState[11], 0, 0f);
                        UMIClientSend.reqAnimation((int)eAction.isRunLeft);
                    }
                }
                else if (Input.GetButton("left shift") && Input.GetButtonUp("a"))
                {
                    if (Input.GetButton("w"))
                    {
                        this.mChar.action.Play(this.mChar.actorState[9], 0, 0f);
                        UMIClientSend.reqAnimation((int)eAction.isRunBack);
                    }
                    else if (Input.GetButton("s"))
                    {
                        this.mChar.action.Play(this.mChar.actorState[8], 0, 0f);
                        UMIClientSend.reqAnimation((int)eAction.isRunForward);
                    }
                    else if (Input.GetButton("d"))
                    {
                        this.mChar.action.Play(this.mChar.actorState[10], 0, 0f);
                        UMIClientSend.reqAnimation((int)eAction.isRunRight);
                    }
                }
                else if (Input.GetButtonUp("left shift"))
                {
                    if (Input.GetButton("s"))
                    {
                        this.mChar.action.Play(this.mChar.actorState[2], 0, 0f);
                        UMIClientSend.reqAnimation((int)eAction.isWalkForward);
                    }
                    else if (Input.GetButton("w"))
                    {
                        this.mChar.action.Play(this.mChar.actorState[0], 0, 0f);
                        UMIClientSend.reqAnimation((int)eAction.isWalkBack);
                    }
                    else if (Input.GetButton("d"))
                    {
                        this.mChar.action.Play(this.mChar.actorState[4], 0, 0f);
                        UMIClientSend.reqAnimation((int)eAction.isWalkRight);
                    }
                    else if (Input.GetButton("a"))
                    {
                        this.mChar.action.Play(this.mChar.actorState[6], 0, 0f);
                        UMIClientSend.reqAnimation((int)eAction.isWalkLeft);
                    }
                }
            }
            else
            {
                if (Input.GetButton("s") && this.mChar.isMove)
                {
                    this.mChar.action.Play(this.mChar.actorState[2], 0, 0f);
                    UMIClientSend.reqAnimation((int)eAction.isWalkForward);
                    this.mChar.isMove = false;
                }
                else if (Input.GetButton("w") && this.mChar.isMove)
                {
                    this.mChar.action.Play(this.mChar.actorState[0], 0, 0f);
                    UMIClientSend.reqAnimation((int)eAction.isWalkBack);
                    this.mChar.isMove = false;
                }
                else if (Input.GetButton("d") && this.mChar.isMove)
                {
                    this.mChar.action.Play(this.mChar.actorState[4], 0, 0f);
                    UMIClientSend.reqAnimation((int)eAction.isWalkRight);
                    this.mChar.isMove = false;
                }
                else if (Input.GetButton("a") && this.mChar.isMove)
                {

                    this.mChar.action.Play(this.mChar.actorState[6], 0, 0f);
                    UMIClientSend.reqAnimation((int)eAction.isWalkLeft);
                    this.mChar.isMove = false;
                }
            }

        }
        #endregion
        #endregion
    }
    protected void OnEffectMovementPlayer(float offset_0, float offset_1, float speed_1)
    {
        if (Game.isRun)
        {
            if (Input.GetButton("left shift") && Input.GetButton("a"))
            {
                PlayerCameraControl.star.updateOffset(offset_0);
                this.mChar.speed_1 = speed_1;
            }
            else if (Input.GetButton("left shift") && Input.GetButton("w"))
            {
                PlayerCameraControl.star.updateOffset(offset_0);
                this.mChar.speed_1 = speed_1;
            }
            else if (Input.GetButton("left shift") && Input.GetButton("d"))
            {
                PlayerCameraControl.star.updateOffset(offset_0);
                this.mChar.speed_1 = speed_1;
            }
            else if (Input.GetButton("left shift") && Input.GetButton("s"))
            {
                PlayerCameraControl.star.updateOffset(offset_0);
                this.mChar.speed_1 = speed_1;
            }
            else { PlayerCameraControl.star.updateOffset(offset_1); this.mChar.speed_1 = this.mChar.speed_3; }
        }
        else { PlayerCameraControl.star.updateOffset(offset_1); this.mChar.speed_1 = this.mChar.speed_3; }
    }
}
