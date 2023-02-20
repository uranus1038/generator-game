using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UMI.Network.Client;

public class CharacterControl : MonoBehaviour
{
    public static CharacterControl star;
    public static bool camera_0 = false; 
    //Speed
    protected float speed_0 =3f ;
    protected float speed_1 =3f;
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
        this.actorState = new string[]
        {
            "isWalkForward",
            "isWalkBack",
            "isWalkRight"
        };
        this.rigidbody2d = GetComponent<Rigidbody2D>();
        this.action = GetComponent<Animator>();

    }
    private void Start()
    {
        camera_0 = true;
       
    }

    protected void playerController ()
    {
        if (this.isMove)
        {
            if (Input.GetKey(KeyCode.W))
            {
                UMIClientSend.reqAnimation((int)eAction.isWalkBack);
                action.Play("boyWalkForwrad", 1, 0f);
                action.SetBool("isWalking", true);
                this.transform.position += new Vector3(0, speed_1 * Time.deltaTime, 0);
            }
            else if (Input.GetKeyUp(KeyCode.W))
            {
                UMIClientSend.reqAnimation((int)eAction.isBack);
                this.action.SetBool(this.actorState[1], false);
            }
            if (Input.GetKey(KeyCode.S))
            {
                UMIClientSend.reqAnimation((int)eAction.isWalkForward);
                this.action.SetBool(this.actorState[0], true);
                this.transform.position += new Vector3(0, -speed_1 * Time.deltaTime, 0);
            }
            else if (Input.GetKeyUp(KeyCode.S))
            {
                UMIClientSend.reqAnimation((int)eAction.isForward);
                this.action.SetBool(this.actorState[0], false);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                UMIClientSend.reqAnimation((int)eAction.isWalkRight);
                this.action.SetBool(this.actorState[2], true);
                this.transform.position += new Vector3(speed_1 * Time.deltaTime, 0, 0);
            } else if (Input.GetKeyUp(KeyCode.D))
            {
                UMIClientSend.reqAnimation((int)eAction.isRight);
                this.action.SetBool(this.actorState[2], false);
            }
            if (Input.GetKey(KeyCode.A))
                this.transform.position += new Vector3(-speed_1 * Time.deltaTime, 0, 0);
        }
        else
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            this.rigidbody2d.velocity = new Vector2(horizontalInput * this.speed_0, this.rigidbody2d.velocity.y);
            float VerticalInput = Input.GetAxis("Vertical");
            this.rigidbody2d.velocity = new Vector2(this.rigidbody2d.velocity.x, VerticalInput * this.speed_0);
            if (Input.GetKey(KeyCode.W))
            {
                UMIClientSend.reqAnimation((int)eAction.isWalkBack);
                this.action.SetBool(this.actorState[1], true);
            }
            else if (Input.GetKeyUp(KeyCode.W))
            {
                UMIClientSend.reqAnimation((int)eAction.isBack);
                this.action.SetBool(this.actorState[1], false);
            }
            if (Input.GetKey(KeyCode.S))
            {
                UMIClientSend.reqAnimation((int)eAction.isWalkForward);
                this.action.SetBool(this.actorState[0], true);
            }
            else if (Input.GetKeyUp(KeyCode.S))
            {
                UMIClientSend.reqAnimation((int)eAction.isForward);
                this.action.SetBool(this.actorState[0], false);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                UMIClientSend.reqAnimation((int)eAction.isWalkRight);
                this.action.SetBool(this.actorState[2], true);
            }
            else if (Input.GetKeyUp(KeyCode.D))
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
        if(actorState == (int)eAction.isWalkForward)
            this.action.SetBool(this.actorState[0], true);
        else if (actorState == (int)eAction.isForward)
            this.action.SetBool(this.actorState[0], false);
        else if(actorState == (int)eAction.isWalkBack)
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
