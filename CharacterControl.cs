using UnityEngine;
using UMI.Network.Client;
public class CharacterControl : MonoBehaviour
{
    public static CharacterControl star;
    //Animator control
    protected Animator action;
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
    //Array string  
    private string[] actorState;
    //Constructor
    public CharacterControl()
    {

    }
    private void Awake()
    {
        star = this;
        this.rigidbody2d = GetComponent<Rigidbody2D>();
        this.action = GetComponent<Animator>();
        this.GetGender("fm");
    }
    private void Start()
    {
        camera_0 = true;
        if (this.action == null)
        {
            this.action = GetComponent<Animator>();
        }
        if (this.rigidbody2d == null)
        {
            this.rigidbody2d = GetComponent<Rigidbody2D>();
        }
    }
    public void GetGender(string gender)
    {
        switch (gender)
        {
            case "m": this.actorState = BoyClass.anim; break;
            case "fm": this.actorState = GirlClass.anim; break;
        }
    }
    protected void OnPlayerController()
    {
        if (this.isMove)
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
                    this.action.Play(this.actorState[7], 0, 0f);
                     UMIClientSend.reqAnimation((int)eAction.isLeft);
                }
            }
            #endregion
            #region Run
            // Get Run 

            //Key S
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
        #endregion
        // # end
        #endregion

        #region Smoot Collison
        else
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            this.rigidbody2d.velocity = new Vector2(horizontalInput * this.speed_0, this.rigidbody2d.velocity.y);
            float VerticalInput = Input.GetAxis("Vertical");
            this.rigidbody2d.velocity = new Vector2(this.rigidbody2d.velocity.x, VerticalInput * this.speed_0);
            #region Animation
            // get W
            if (Input.GetButton("w"))
            {
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
                    this.action.Play(this.actorState[7], 0, 0f);
                }
                UMIClientSend.reqAnimation((int)eAction.isLeft);
            }

            // Get Run 

            //Key S
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
        #endregion
        this.position = this.transform.position;

        UMIClientSend.reqPlayerMoveMent(this.position);
    }
    #endregion

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
    protected void OnEffectMovementPlayer(float offset_0, float speed_1)
    {
        if (Input.GetButton("left shift") && Input.GetButton("a"))
        {
            CameraControl.star.offest_1 = offset_0;
            this.speed_1 = speed_1;
        }
        else if (Input.GetButton("left shift") && Input.GetButton("w"))
        {
            CameraControl.star.offest_1 = offset_0;
            this.speed_1 = speed_1;
        }
        else if (Input.GetButton("left shift") && Input.GetButton("d"))
        {
            CameraControl.star.offest_1 = offset_0;
            this.speed_1 = speed_1;
        }
        else if (Input.GetButton("left shift") && Input.GetButton("s"))
        {
            CameraControl.star.offest_1 = offset_0;
            this.speed_1 = speed_1;
        }
        else { CameraControl.star.offest_1 = -10f; this.speed_1 = 3f; }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check Collision
        if (collision.gameObject.name == "boyCharPlayer(Clone)")
        {
            this.isMove = false;
            UMI.UMI.Log("Enter");
        }
        else if (collision.gameObject.name == "girlCharPlayer(Clone)")
        {
            this.isMove = false;
            UMI.UMI.Log("Enter");
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        // Check Collision
        if (collision.gameObject.name == "boyCharPlayer(Clone)")
        {


        }
        else if (collision.gameObject.name == "girlCharPlayer(Clone)")
        {
           
            this.isMove = true;
            UMI.UMI.Log("Leave");

        }
    }
}