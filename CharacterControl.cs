using UnityEngine;
using UMI.Network.Client;
using UMI;
public class CharacterControl : MonoBehaviour
{
    public float offset_0 ;
    public float offset_1 ;
    public float speed_2 ;
    public float time_0 ;
    //Animator control
    public Animator action;
    public AnimationControl anim_0;
    //Speed
    public float speed_1 ;
    public float speed_3;
    // Rigibody
    public Rigidbody2D rigidbody2d;
    // Current position
    public Vector3 position;
    public bool isMove ;
    //Array string  
    public string[] actorState;
    public CharacterControl()
    {
        this.offset_0 = -12f;
        this.offset_1 = -10f;
        this.speed_1 = 3f;
        this.speed_2 = 4.2f;
        this.speed_3 = 3f;
        this.position = Vector3.zero;
        this.isMove = true;
    }
    private void FixedUpdate()
    {
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check Collision
        if (collision.gameObject.name == "maleCharPlayer(Clone)")
        {
            UMI.UMISystem.L0g("Enter");
           
        }
        else if (collision.gameObject.name == "femaleCharPlayer(Clone)")
        {
            this.time_0 = Time.time;
        }
    }
}