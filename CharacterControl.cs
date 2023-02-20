using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UMI.Network.Client;

public class CharacterControl : MonoBehaviour
{
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
    //animator control
    protected Animator action; 
    private void Start()
    {
        camera_0 = true;
        this.rigidbody2d = GetComponent<Rigidbody2D>();
        this.action = GetComponent<Animator>();
    }

    protected void playerController ()
    {
        if (this.isMove)
        {
            if (Input.GetKey(KeyCode.W))
            {
                this.action.SetBool("isWalkForward",true);
                this.transform.position += new Vector3(0, speed_1 * Time.deltaTime, 0);
            }else if(Input.GetKeyUp(KeyCode.W))
            {
                this.action.SetBool("isWalkForward", false);
            }
            if (Input.GetKey(KeyCode.S))
                this.transform.position += new Vector3(0, -speed_1 * Time.deltaTime, 0);
            if (Input.GetKey(KeyCode.A))
                this.transform.position += new Vector3(-speed_1 * Time.deltaTime, 0, 0);
            if (Input.GetKey(KeyCode.D))
                this.transform.position += new Vector3(speed_1 * Time.deltaTime, 0, 0);
        }
        else
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            this.rigidbody2d.velocity = new Vector2(horizontalInput * this.speed_0, this.rigidbody2d.velocity.y);
            float VerticalInput = Input.GetAxis("Vertical");
            this.rigidbody2d.velocity = new Vector2(this.rigidbody2d.velocity.x, VerticalInput * this.speed_0);
        }
        this.position = this.transform.position;

        UMIClientSend.reqPlayerMoveMent(this.position);
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
