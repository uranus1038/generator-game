using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UMI.Network.Client;
using UMI;

public class Boy : MonoBehaviour 
{
    protected float offset_0 = -12f;
    protected float offset_1 = -10f;
    protected float speed_2 = 4.2f;
    //Animator control
    protected Animator action;
    protected AnimationControl anim_0; 
    //Speed
    protected float speed_0 = 3f;
    protected float speed_1 = 3f;
    // Rigibody
    private Rigidbody2D rigidbody2d;
    // Current position
    public Vector3 position;
    //Smooth movement
    protected bool isMove = true;
    //Array string  
    private string[] actorState;
    private void Awake()
    {
        this.action = GetComponent<Animator>();
        this.anim_0 = GetComponent<AnimationControl>();
    }
    private void Start()
    {
        this.anim_0.setGenderAnimation("male");
        this.actorState = this.anim_0.getGenderAnimation();
    }
    void Update()
    {
        this.PlayerControl();
        this.OnEffectMovementPlayer(this.offset_0, this.offset_1, this.speed_2);
    }
    protected void PlayerControl()
    {
        if (Game.isMove_0)
        {
            #region Input Movement & Animation
            #region Move
            // get W 
            if (Input.GetButton("w"))
            {
                this.transform.position += new Vector3(0, speed_1 * Time.deltaTime, 0);
                if (Input.GetButtonDown("w"))
                {
                    this.action.Play(this.actorState[0], 0, 0f);
                    UMIClientSend.reqAnimation((int)eAction.isWalkBack);
                }
            }
            else if (Input.GetButtonUp("w"))
            {
                if (Input.GetButton("s") && Input.GetButtonUp("w"))
                {
                    this.action.Play(this.actorState[2], 0, 0f);
                    UMIClientSend.reqAnimation((int)eAction.isWalkForward);
                }
                else if (Input.GetButton("d") && Input.GetButtonUp("w"))
                {
                    this.action.Play(this.actorState[4], 0, 0f);
                    UMIClientSend.reqAnimation((int)eAction.isWalkRight);
                }
                else if (Input.GetButton("a") && Input.GetButtonUp("w"))
                {
                    this.action.Play(this.actorState[6], 0, 0f);
                    UMIClientSend.reqAnimation((int)eAction.isWalkLeft);
                }
                else
                {
                    this.action.Play(this.actorState[1], 0, 0f);
                    UMIClientSend.reqAnimation((int)eAction.isBack);
                }
            }
            // get S
            if (Input.GetButton("s"))
            {
                this.transform.position += new Vector3(0, -speed_1 * Time.deltaTime, 0);

                if (Input.GetButtonDown("s"))
                {
                    this.action.Play(this.actorState[2], 0, 0f);
                    UMIClientSend.reqAnimation((int)eAction.isWalkForward);
                }
            }
            else if (Input.GetButtonUp("s"))
            {
                if (Input.GetButtonUp("s") && Input.GetButton("w"))
                {
                    this.action.Play(this.actorState[0], 0, 0f);
                    UMIClientSend.reqAnimation((int)eAction.isWalkBack);
                }
                else if (Input.GetButtonUp("s") && Input.GetButton("d"))
                {
                    this.action.Play(this.actorState[4], 0, 0f);
                    UMIClientSend.reqAnimation((int)eAction.isWalkRight);
                }
                else if (Input.GetButtonUp("s") && Input.GetButton("a"))
                {
                    this.action.Play(this.actorState[6], 0, 0f);
                    UMIClientSend.reqAnimation((int)eAction.isWalkLeft);
                }
                else
                {
                    this.action.Play(this.actorState[3], 0, 0f);
                    UMIClientSend.reqAnimation((int)eAction.isForward);
                }
            }
            // get D
            if (Input.GetButton("d"))
            {
                this.transform.position += new Vector3(speed_1 * Time.deltaTime, 0, 0);
                if (Input.GetButton("d") != Input.GetButton("w") ||
                    Input.GetButton("d") != Input.GetButton("s"))
                {
                    if (Input.GetButtonDown("d"))
                    {
                        this.action.Play(this.actorState[4], 0, 0f);
                        UMIClientSend.reqAnimation((int)eAction.isWalkRight);
                    }
                }
            }
            else if (Input.GetButtonUp("d"))
            {
                if (Input.GetButton("a") && Input.GetButtonUp("d"))
                {
                    this.action.Play(this.actorState[6], 0, 0f);
                    UMIClientSend.reqAnimation((int)eAction.isWalkLeft);
                }
                else if (Input.GetButtonUp("d") && Input.GetButton("w"))
                {
                    this.action.Play(this.actorState[0], 0, 0f);
                    UMIClientSend.reqAnimation((int)eAction.isWalkBack);
                }
                else if (Input.GetButtonUp("d") && Input.GetButton("s"))
                {
                    this.action.Play(this.actorState[2], 0, 0f);
                    UMIClientSend.reqAnimation((int)eAction.isWalkForward);
                }
                else
                {
                    this.action.Play(this.actorState[5], 0, 0f);
                    UMIClientSend.reqAnimation((int)eAction.isRight);
                }
            }
            // get A
            if (Input.GetButton("a"))
            {
                this.transform.position += new Vector3(-speed_1 * Time.deltaTime, 0, 0);
                if (Input.GetButton("a") != Input.GetButton("w") ||
                   Input.GetButton("a") != Input.GetButton("s"))
                {
                    if (Input.GetButtonDown("a"))
                    {
                        this.action.Play(this.actorState[6], 0, 0f);
                        UMIClientSend.reqAnimation((int)eAction.isWalkLeft);
                    }
                }
            }
            else if (Input.GetButtonUp("a"))
            {
                if (Input.GetButton("d") && Input.GetButtonUp("a"))
                {
                    this.action.Play(this.actorState[4], 0, 0f);
                    UMIClientSend.reqAnimation((int)eAction.isWalkRight);
                }
                else if (Input.GetButtonUp("a") && Input.GetButton("w"))
                {
                    UMISystem.L0g(" yes");
                    this.action.Play(this.actorState[0], 0, 0f);
                    UMIClientSend.reqAnimation((int)eAction.isWalkBack);
                }
                else if (Input.GetButtonUp("a") && Input.GetButton("s"))
                {
                    this.action.Play(this.actorState[2], 0, 0f);
                    UMIClientSend.reqAnimation((int)eAction.isWalkForward);
                }
                else
                {
                    UMISystem.L0g(" yes");
                    this.action.Play(this.actorState[7], 0, 0f);
                    UMIClientSend.reqAnimation((int)eAction.isLeft);
                }
            }
            #endregion
            #region Run
            // Get Run 

            //Key S
            if (Game.isRun)
            {
                this.isMove = true;
                if (Input.GetButton("left shift") && Input.GetButton("s"))
                {
                    if (Input.GetButtonDown("s"))
                    {
                        this.action.Play(this.actorState[8], 0, 0f);
                        UMIClientSend.reqAnimation((int)eAction.isRunForward);
                    }
                    else if (Input.GetButtonDown("left shift"))
                    {
                        this.action.Play(this.actorState[8], 0, 0f);
                        UMIClientSend.reqAnimation((int)eAction.isRunForward);
                    }
                }
                else if (Input.GetButton("left shift") && Input.GetButtonUp("s"))
                {
                    if (Input.GetButton("d"))
                    {
                        this.action.Play(this.actorState[10], 0, 0f);
                        UMIClientSend.reqAnimation((int)eAction.isRunRight);
                    }
                    if (Input.GetButton("w"))
                    {
                        this.action.Play(this.actorState[9], 0, 0f);
                        UMIClientSend.reqAnimation((int)eAction.isRunBack);
                    }
                    if (Input.GetButton("a"))
                    {
                        this.action.Play(this.actorState[11], 0, 0f);
                        UMIClientSend.reqAnimation((int)eAction.isRunLeft);
                    }
                }
                //Key W
                if (Input.GetButton("left shift") && Input.GetButton("w"))
                {
                    if (Input.GetButtonDown("w"))
                    {
                        this.action.Play(this.actorState[9], 0, 0f);
                        UMIClientSend.reqAnimation((int)eAction.isRunBack);
                    }
                    else if (Input.GetButtonDown("left shift"))
                    {
                        this.action.Play(this.actorState[9], 0, 0f);
                        UMIClientSend.reqAnimation((int)eAction.isRunBack);
                    }
                }
                else if (Input.GetButton("left shift") && Input.GetButtonUp("w"))
                {
                    if (Input.GetButton("d"))
                    {
                        this.action.Play(this.actorState[10], 0, 0f);
                        UMIClientSend.reqAnimation((int)eAction.isRunRight);
                    }
                    if (Input.GetButton("s"))
                    {
                        this.action.Play(this.actorState[8], 0, 0f);
                        UMIClientSend.reqAnimation((int)eAction.isRunForward);
                    }
                    if (Input.GetButton("a"))
                    {
                        this.action.Play(this.actorState[11], 0, 0f);
                        UMIClientSend.reqAnimation((int)eAction.isRunLeft);
                    }
                }
                //Key D
                if (Input.GetButton("left shift") && Input.GetButton("d"))
                {
                    if (Input.GetButtonDown("d"))
                    {
                        this.action.Play(this.actorState[10], 0, 0f);
                        UMIClientSend.reqAnimation((int)eAction.isRunRight);
                    }
                    else if (Input.GetButtonDown("left shift"))
                    {
                        this.action.Play(this.actorState[10], 0, 0f);
                        UMIClientSend.reqAnimation((int)eAction.isRunRight);
                    }
                }
                else if (Input.GetButton("left shift") && Input.GetButtonUp("d"))
                {
                    if (Input.GetButton("w"))
                    {
                        this.action.Play(this.actorState[9], 0, 0f);
                        UMIClientSend.reqAnimation((int)eAction.isRunBack);
                    }
                    else if (Input.GetButton("s"))
                    {
                        this.action.Play(this.actorState[8], 0, 0f);
                        UMIClientSend.reqAnimation((int)eAction.isRunForward);
                    }
                    else if (Input.GetButton("a"))
                    {
                        this.action.Play(this.actorState[11], 0, 0f);
                        UMIClientSend.reqAnimation((int)eAction.isRunLeft);
                    }
                }
                //Key A
                if (Input.GetButton("left shift") && Input.GetButton("a"))
                {
                    if (Input.GetButtonDown("a"))
                    {
                        this.action.Play(this.actorState[11], 0, 0f);
                        UMIClientSend.reqAnimation((int)eAction.isRunLeft);
                    }
                    else if (Input.GetButtonDown("left shift"))
                    {
                        this.action.Play(this.actorState[11], 0, 0f);
                        UMIClientSend.reqAnimation((int)eAction.isRunLeft);
                    }
                }
                else if (Input.GetButton("left shift") && Input.GetButtonUp("a"))
                {
                    if (Input.GetButton("w"))
                    {
                        this.action.Play(this.actorState[9], 0, 0f);
                        UMIClientSend.reqAnimation((int)eAction.isRunBack);
                    }
                    else if (Input.GetButton("s"))
                    {
                        this.action.Play(this.actorState[8], 0, 0f);
                        UMIClientSend.reqAnimation((int)eAction.isRunForward);
                    }
                    else if (Input.GetButton("d"))
                    {
                        this.action.Play(this.actorState[10], 0, 0f);
                        UMIClientSend.reqAnimation((int)eAction.isRunRight);
                    }
                }
                else if (Input.GetButtonUp("left shift"))
                {
                    if (Input.GetButton("s"))
                    {
                        this.action.Play(this.actorState[2], 0, 0f);
                        UMIClientSend.reqAnimation((int)eAction.isWalkForward);
                    }
                    else if (Input.GetButton("w"))
                    {
                        this.action.Play(this.actorState[0], 0, 0f);
                        UMIClientSend.reqAnimation((int)eAction.isWalkBack);
                    }
                    else if (Input.GetButton("d"))
                    {
                        this.action.Play(this.actorState[4], 0, 0f);
                        UMIClientSend.reqAnimation((int)eAction.isWalkRight);
                    }
                    else if (Input.GetButton("a"))
                    {
                        this.action.Play(this.actorState[6], 0, 0f);
                        UMIClientSend.reqAnimation((int)eAction.isWalkLeft);
                    }
                }
            }
            else
            {
                if (Input.GetButton("s") && this.isMove)
                {
                    this.action.Play(this.actorState[2], 0, 0f);
                    UMIClientSend.reqAnimation((int)eAction.isWalkForward);
                    this.isMove = false;
                }
                else if (Input.GetButton("w") && this.isMove)
                {
                    this.action.Play(this.actorState[0], 0, 0f);
                    UMIClientSend.reqAnimation((int)eAction.isWalkBack);
                    this.isMove = false;
                }
                else if (Input.GetButton("d") && this.isMove)
                {
                    this.action.Play(this.actorState[4], 0, 0f);
                    UMIClientSend.reqAnimation((int)eAction.isWalkRight);
                    this.isMove = false;
                }
                else if (Input.GetButton("a") && this.isMove)
                {

                    this.action.Play(this.actorState[6], 0, 0f);
                    UMIClientSend.reqAnimation((int)eAction.isWalkLeft);
                    this.isMove = false;
                }
            }

        }
        #endregion
        // # end
        #endregion

        #region Smoot Collison
        //else
        //{
        //    float horizontalInput = Input.GetAxis("Horizontal");
        //    this.rigidbody2d.velocity = new Vector2(horizontalInput * this.speed_0, this.rigidbody2d.velocity.y);
        //    float VerticalInput = Input.GetAxis("Vertical");
        //    this.rigidbody2d.velocity = new Vector2(this.rigidbody2d.velocity.x, VerticalInput * this.speed_0);
        #endregion
        this.position = this.transform.position;

        UMIClientSend.reqPlayerMoveMent(this.position);
    }
    protected void OnEffectMovementPlayer(float offset_0, float offset_1, float speed_1)
    {
        if (Game.isRun)
        {
            if (Input.GetButton("left shift") && Input.GetButton("a"))
            {
                PlayerCameraControl.star.updateOffset(offset_0);
                this.speed_1 = speed_1;
            }
            else if (Input.GetButton("left shift") && Input.GetButton("w"))
            {
                PlayerCameraControl.star.updateOffset(offset_0);
                this.speed_1 = speed_1;
            }
            else if (Input.GetButton("left shift") && Input.GetButton("d"))
            {
                PlayerCameraControl.star.updateOffset(offset_0);
                this.speed_1 = speed_1;
            }
            else if (Input.GetButton("left shift") && Input.GetButton("s"))
            {
                PlayerCameraControl.star.updateOffset(offset_0);
                this.speed_1 = speed_1;
            }
            else { PlayerCameraControl.star.updateOffset(offset_1); this.speed_1 = 3f; }
        }
        else { PlayerCameraControl.star.updateOffset(offset_1); this.speed_1 = 3f; }
    }
}
