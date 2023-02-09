using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UMI.Manager
{
    public class UMIGame : MonoBehaviour
    {
        public static void LoadNextLevel(int num)
        {
            switch(num)
            {
                case 1: Application.LoadLevel("T00_GamePlay");  break;
                case 2: Application.LoadLevel("A01_LobbyGui");  break;
                default: return; 
            }
         

        }
    }
}