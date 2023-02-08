using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
            this.transform.Translate(0, 3 * Time.deltaTime, 0);
        if (Input.GetKey("s"))
            this.transform.Translate(0, -3 * Time.deltaTime, 0);
        if (Input.GetKey("a"))
            this.transform.Translate(-3 * Time.deltaTime, 0,0);
        if (Input.GetKey("d"))
            this.transform.Translate(3 * Time.deltaTime, 0,0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "ob")
        {
            print("Enter");
        }
    }
}
