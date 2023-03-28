using UnityEngine;
using UMI.Network.Client;
using UMI;
public class CharacterControl : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check Collision
        if (collision.gameObject.name == "boyCharPlayer(Clone)")
        {

        }
        else if (collision.gameObject.name == "girlCharPlayer(Clone)")
        {

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



        }
    }
}