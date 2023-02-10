using System.Collections;
using UnityEngine;
using UMI.Network.Client;
using UMI.Network.Server;
namespace UMI.Network
{
    public class UMINetworkManager : MonoBehaviour
    {
        public static UMINetworkManager star;
        // Load Data
        public static Hashtable hDac = new Hashtable();
        private void Awake()
        {
            star = this;
            
        }
        private void Start()
        {
            UMI.Log("UMI::LOG()->START");
            UMIClientManager.star.connectServer();
            
        }
    }
}
