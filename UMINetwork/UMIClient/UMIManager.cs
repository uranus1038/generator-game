
using UnityEngine;

namespace UMI.Network.Client
{
    public class UMIManager : MonoBehaviour
    {
        public static UMIManager instance;
        public GameObject button;
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Debug.Log($"UMI::DESTROY()->INSTANCE");
                Destroy(this);
            }
        }

        public void Connect()
        {
            button.SetActive(false);
            UMIClient.hInst.connectServer();
        }

    }
}
