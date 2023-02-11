using UnityEngine;
using UMI.Network.Server;
using UMI.Network.Client;
using UMI.Network;
using UMI.Manager;

public class LobbyGui : MonoBehaviour
{
    //flot 
    private float delay_0;
    private float display_0;
    //enum
    eLobbyState eLobbyState_0;
    private void Awake()
    {
        this.eLobbyState_0 = eLobbyState.Init;
    }
    private void OnGUI()
    {
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3((float)Screen.height / 1024f, (float)Screen.height / 1024f, 1f));
        GUI.depth = 2;
        this.display_0 = (float)(1024 * Screen.width / Screen.height);
        if (this.eLobbyState_0 == eLobbyState.Init)
        {
            this.delay_0 = Time.time;
            if (GUI.Button(new Rect(0.5f * this.display_0 - 125f, 350f, 250f, 38f), "Play"))
            {
                this.eLobbyState_0 = eLobbyState.createRoom;
            }
            if (GUI.Button(new Rect(0.5f * this.display_0 - 125f, 400f, 250f, 38f), UMINetworkManager.hDac[1].ToString()))
            {
                UMIGame.LoadNextLevel(1);
            }
            if (GUI.Button(new Rect(0.5f * this.display_0 - 125f, 450f, 250f, 38f), "Quit"))
            {
             
            }
        }
        else if (this.eLobbyState_0 == eLobbyState.createRoom)
        {
            if (GUI.Button(new Rect(0.5f * this.display_0 - 125f, 400f, 250f, 38f), "CreateRoom"))
            {
                UMIServe.star.StartServe();
                this.eLobbyState_0 = eLobbyState.notice;
            }
        }
        else if (this.eLobbyState_0 == eLobbyState.notice)
        {
            if (Time.time < this.delay_0 + 2f)
            {
                // # Notice
                GUI.TextField(new Rect(0.5f * this.display_0 - 125f, 400f, 250f, 38f), "Notice");
                return;
            }
            this.delay_0 = Time.time;
            this.eLobbyState_0 = eLobbyState.renderRoom;
            return;
        }
        else if (this.eLobbyState_0 == eLobbyState.renderRoom)
        {
            if (GUI.Button(new Rect(0.5f * this.display_0 - 125f, 400f, 250f, 38f), "Start"))
            {
               
                UMIGame.LoadNextLevel(1);
            }
        }

    }
}
