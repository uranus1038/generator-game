using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UMI.Manager
{
    public class UMIGame : MonoBehaviour
    {
        public static void LoadNextLevel(int num)
        {
            if (num == 1)
            {
                Application.LoadLevel("T00_GamePlay");
                return;
            }

        }
    }
}