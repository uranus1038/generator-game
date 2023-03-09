using System.Collections;
using UnityEngine;
using UMI.Network.Client;
using UMI.Network.Server;
namespace UMI.Network
{
    public class UMINetworkManager : MonoBehaviour
    {
        public static UMINetworkManager star;
        private void Awake()
        {
            star = this;
        }
        private void Start()
        {
            UMISystem.Log("UMI::LOG()->START_LOBBY");
            UMIClientManager.star.connectServer("127.0.0.1");
        }
    }
}
