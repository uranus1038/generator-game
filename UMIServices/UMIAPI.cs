using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace UMI.Network.API
{
    public class UMIAPI : MonoBehaviour
    {
        public static UMIAPI hInst;
        private string UMIReqUser = "http://localhost:8000/api/login/submit";
        void Awake()
        {
            hInst = this;
        }
        public IEnumerator UMIGetUser(string UID)
        {
            WWWForm UMIReq = new WWWForm();
            UMIReq.AddField("userName", UID);
            using (UnityWebRequest www = UnityWebRequest.Post(this.UMIReqUser, UMIReq))
            {
                yield return www.SendWebRequest();

                if (www.result != UnityWebRequest.Result.Success)
                {
                    Debug.Log(www.error);
                }
                else
                {
                    Debug.Log(www.downloadHandler.text);
                }

            }

        }

    }
}