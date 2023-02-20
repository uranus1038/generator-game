using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UMI.Network.Client;

public class CharacterControl : MonoBehaviour
{
    public static CharacterControl star;
    public static bool camera_0 = false;
    //Speed
    protected float speed_0 = 3f;
    protected float speed_1 = 3f;
    // Rigibody
    private Rigidbody2D rigidbody2d;
    // Current position
    public Vector3 position;
    //Smooth movement
    protected bool isMove = true;
    //Animator control
    protected Animator action;
    //enum
    private eAction eAction_0;
    //Array string  
    private string[] actorState;
    //Constructor
    public CharacterControl()
    {
        this.eAction_0 = eAction.Idel;
    }
    private void Awake()
    {

        star = this;
        // set Animation
        this.rigidbody2d = GetComponent<Rigidbody2D>();
        this.action = GetComponent<Animator>();

    }
    private void Start()
    {
        camera_0 = true;
        if (this.action == null)
        {
            this.action = GetComponent<Animator>();
        }
    }

    protected void playerController(string[] actorState)
    {
        this.actorState = actorState; 
        if (this.isMove)
        {
            if (Input.GetButton("w"))
            {
                this.transform.position += new Vector3(0, speed_1 * Time.deltaTime, 0);
                if (Input.GetButtonDown("w"))
                {
                    this.action.Play(this.actorState[0], 0, 0f);
                }
                UMIClientSend.reqAnimation((int)eAction.isWalkBack);
            }
            if (Input.GetButtonUp("w"))
            {
                if (Input.GetButton("d") && Input.GetButtonUp("w"))
                {
                    this.action.Play(this.actorState[4], 0, 0f);
                }
                else
                {
                    this.action.Play(this.actorState[1], 0, 0f);
                }
                UMIClientSend.reqAnimation((int)eAction.isBack);
            }
            if (Input.GetButton("s"))
            {
                this.transform.position += new Vector3(0, -speed_1 * Time.deltaTime, 0);
                if (Input.GetButtonDown("s"))
                {
                    this.action.Play(this.actorState[2], 0, 0f);
                }
                UMIClientSend.reqAnimation((int)eAction.isWalkForward);
            }
            if (Input.GetButtonUp("s"))
            {
                if (Input.GetButtonUp("s") && Input.GetButton("d"))
                {
                    this.action.Play(this.actorState[4], 0, 0f);
                }
                else
                {
                    this.action.Play(this.actorState[3], 0, 0f);
                }
                UMIClientSend.reqAnimation((int)eAction.isForward);
            }
            if (Input.GetButton("d"))
            {
                this.transform.position += new Vector3(speed_1 * Time.deltaTime, 0, 0);
                if (Input.GetButton("d") != Input.GetButton("w") ||
                    Input.GetButton("d") != Input.GetButton("s"))
                {
                    if (Input.GetButtonDown("d"))
                        this.action.Play(this.actorState[4], 0, 0f);
                }
                UMIClientSend.reqAnimation((int)eAction.isWalkRight);
            }
            if (Input.GetButtonUp("d"))
            {
                if (Input.GetButtonUp("d") && Input.GetButton("w"))
                {
                    this.action.Play(this.actorState[0], 0, 0f);
                }
                else if (Input.GetButtonUp("d") && Input.GetButton("s"))
                {
                    this.action.Play(this.actorState[2], 0, 0f);
                }
                else
                {
                    this.action.Play(this.actorState[5], 0, 0f);
                }
                UMIClientSend.reqAnimation((int)eAction.isRight);
            }
            if (Input.GetButton("a"))
            {
                this.transform.position += new Vector3(-speed_1 * Time.deltaTime, 0, 0);
                if (Input.GetButtonDown("a"))
                {
                    this.action.Play(this.actorState[6], 0, 0f);
                }
                UMIClientSend.reqAnimation((int)eAction.isWalkRight);
            }
            if (Input.GetButtonUp("a"))
            {
                this.action.Play(this.actorState[7], 0, 0f);
                UMIClientSend.reqAnimation((int)eAction.isRight);
            }


        }
        else
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            this.rigidbody2d.velocity = new Vector2(horizontalInput * this.speed_0, this.rigidbody2d.velocity.y);
            float VerticalInput = Input.GetAxis("Vertical");
            this.rigidbody2d.velocity = new Vector2(this.rigidbody2d.velocity.x, VerticalInput * this.speed_0);
            if (Input.GetButton("w"))
            {
                UMIClientSend.reqAnimation((int)eAction.isWalkBack);
                this.action.SetBool(this.actorState[1], true);
            }
            else if (Input.GetButtonUp("w"))
            {
                UMIClientSend.reqAnimation((int)eAction.isBack);
                this.action.SetBool(this.actorState[1], false);
            }
            if (Input.GetButton("s"))
            {
                UMIClientSend.reqAnimation((int)eAction.isWalkForward);
                this.action.SetBool(this.actorState[0], true);
            }
            else if (Input.GetButtonUp("s"))
            {
                UMIClientSend.reqAnimation((int)eAction.isForward);
                this.action.SetBool(this.actorState[0], false);
            }
            else if (Input.GetButton("d"))
            {
                UMIClientSend.reqAnimation((int)eAction.isWalkRight);
                this.action.SetBool(this.actorState[2], true);
            }
            else if (Input.GetButtonUp("d"))
            {
                UMIClientSend.reqAnimation((int)eAction.isRight);
                this.action.SetBool(this.actorState[2], false);
            }
        }
        this.position = this.transform.position;

        UMIClientSend.reqPlayerMoveMent(this.position);
    }

    public void animationPlayerController(int actorState)
    {
        if (actorState == (int)eAction.isWalkForward)
            this.action.SetBool(this.actorState[0], true);
        else if (actorState == (int)eAction.isForward)
            this.action.SetBool(this.actorState[0], false);
        else if (actorState == (int)eAction.isWalkBack)
            this.action.SetBool(this.actorState[1], true);
        else if (actorState == (int)eAction.isBack)
            this.action.SetBool(this.actorState[1], false);
        else if (actorState == (int)eAction.isWalkRight)
            this.action.SetBool(this.actorState[2], true);
        else if (actorState == (int)eAction.isRight)
            this.action.SetBool(this.actorState[2], false);

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check Collision
        if (collision.gameObject.name == "boyCharPlayer(Clone)")
        {
            this.isMove = false;
            print("Enter");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Check Collision
        if (collision.gameObject.name == "boyCharPlayer(Clone)")
        {
            this.isMove = true;
            print("Leave");
        }
    }
}
