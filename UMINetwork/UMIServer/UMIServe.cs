using System;
using System.Threading;
using UnityEngine;
namespace UMI.Network.Server
{
    class UMIServe : MonoBehaviour
    {
        public static UMIServe star;
        private void Awake()
        {
            star = this; 
        }
     
        public  void StartServe()
        {
            UMIServer.Start(4, 8080);
            
        }
        public void StartServeX()
        {
            UMIServer.Start(4, 8180);

        }




    }
}
