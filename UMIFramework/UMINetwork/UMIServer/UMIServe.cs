using System;
using UnityEngine;
namespace UMI.Network.Server
{
    class UMIServe : MonoBehaviour
    {
        [SerializeField] protected int maxPlayer ;
        [SerializeField] protected int portV;
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
