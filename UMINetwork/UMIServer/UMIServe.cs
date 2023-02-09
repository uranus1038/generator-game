using System;
using System.Threading;
using UnityEngine;
namespace UMI.Network.Server
{
    class UMIServe : MonoBehaviour
    {
        public static UMIServe hInst;
        private void Awake()
        {
            hInst = this; 
        }
        private static bool isRunnig = false;
        public const int TICK_PER_SEC = 30;
        public const int MS_PER_TICK = 1000 / TICK_PER_SEC;
        public  void Startserve()
        {
            isRunnig = true;
            UMIServer.Start(100, 800);
            
            
            Thread mainThread = new Thread(new ThreadStart(UMIMain));
            mainThread.Start();
            
        }

        private static void UMIMain()
        {
            DateTime nextLoop = DateTime.Now;
            while (isRunnig)
            {
                while (nextLoop < DateTime.Now)
                {
                    UMIThreadManager.UMIMain();
                    nextLoop = nextLoop.AddMilliseconds(MS_PER_TICK);
                }
                if (nextLoop > DateTime.Now)
                {
                    Thread.Sleep(nextLoop - DateTime.Now);
                }
            }
        }


    }
}
