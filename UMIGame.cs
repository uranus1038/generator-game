using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;
namespace UMI.Manager
{
    public class UMIGame : MonoBehaviour
    {
        public static bool isFull = true;
        public static bool Serve = true;
        public static bool Join = true;
        public static bool connectLobby = true;
        public static bool Connecting = true;
        public static bool Connected = true;
        public static bool Successed = true;
        public static bool Leave = true; 


        public static bool loginConnect = true;
        public static bool loginFail = true;
        public static void LoadNextLevel(int num)
        {

            switch (num)
            {
                case 1: Application.LoadLevel("T00_GamePlay"); break;
                case 2: Application.LoadLevel("A01_LobbyGui"); break;
                default: return;
            }


        }
    }
}