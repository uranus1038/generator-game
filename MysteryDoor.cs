using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysteryDoor : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "femaleChar(Clone)")
        {
            UMI.UMISystem.L0g("enter");
        }
    }
}
