using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public float speed = 0.01f;
    private Rigidbody2D rigidbody2d;
    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        rigidbody2d.velocity = new Vector2(horizontalInput * speed, rigidbody2d.velocity.y);
        float VerticalInput = Input.GetAxis("Vertical");
        rigidbody2d.velocity= new Vector2(rigidbody2d.velocity.x, VerticalInput * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "ob")
        {
            print("Enter");
        }
    }
}
