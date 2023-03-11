using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using UMI.Manager; 

namespace UMI.Network.API
{
    public class UMIAPI : MonoBehaviour
    {
        private UMIData data = new UMIData(); 
        public static Hashtable hdac = new Hashtable();
        public static UMIAPI star;
        //public delegate void getUserCallback(string e);
        void Awake()
        {
            star = this;
        }
        public IEnumerator UMIGetUser(string UID , string QUk8sYq_x , Action<String> callback  )
        {
            WWWForm UMIReq = new WWWForm();
            UMIReq.AddField("userName", UID);
            UMIReq.AddField("QUk8sYq_x", QUk8sYq_x);
            using (UnityWebRequest www = UnityWebRequest.Post(this.data.UMIURL(0), UMIReq))
            {
                yield return www.SendWebRequest();

                if (www.result != UnityWebRequest.Result.Success)
                {
                    UMIData.Clear();
                    UMIGame.loginFail = false; 
                }
                else
                {
                    callback(www.downloadHandler.text);
                }

            }

        }

    }
}