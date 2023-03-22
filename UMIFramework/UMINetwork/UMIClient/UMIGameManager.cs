using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UMI.Network.Client
{
    public class UMIGameManager : MonoBehaviour
    {
        public static Dictionary<int, UMIPlayerManager> players = new Dictionary<int, UMIPlayerManager>();
    }
}