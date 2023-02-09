using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UMI.Network
{
    public class UMINetworkManager : UMIHost
    {
        private void Awake()
        {
            hInst = this;
        }
        private void Start()
        {
            this.UMIReceive();
        }
        protected override void UMIReceive()
        {
            UMI.Log(userName);
        }
        
    }
}