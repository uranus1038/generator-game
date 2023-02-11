using System;
using UnityEngine;
namespace UMI.Network.Server
{
    class UMIServe : MonoBehaviour
    {
        public int maxPlayer ;
        public int portV; 
        public static UMIServe star;
        private void Awake()
        {
            star = this; 
        }
        public  void StartServe()
        {
            UMIServer.Start(maxPlayer, portV);
        }
        
    }
}
