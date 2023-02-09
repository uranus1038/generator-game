using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets; 
namespace UMI.Network.API
{
    public class UMINetworkManager : MonoBehaviour
    {
        public static UMINetworkManager hInst; 
        public int ID;
        // Load Data
        public static Hashtable hDac = new Hashtable(); 
        private void Awake()
        {
            hInst = this;
        }
        private void Start()
        {
           
        }
       
        
    }
}