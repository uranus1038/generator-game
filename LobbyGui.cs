using UnityEngine;
using UMI.Network; 
public class LobbyGui : MonoBehaviour
{
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
        if(this.eLobbyState_0 == eLobbyState.Init)
        {
            if (GUI.Button(new Rect(0.5f * this.display_0 - 125f, 350f, 250f, 38f), "Play"))
            {
                this.eLobbyState_0 = eLobbyState.createRoom; 
            }
            if (GUI.Button(new Rect(0.5f * this.display_0 - 125f, 400f, 250f, 38f), "Option"))
            {

            }
            if (GUI.Button(new Rect(0.5f * this.display_0 - 125f, 450f, 250f, 38f), "Quit"))
            {
                UMIClient.UMIConnect();
            }
        }
        else if (this.eLobbyState_0 == eLobbyState.createRoom)
        {
            if (GUI.Button(new Rect(0.5f * this.display_0 - 125f, 400f, 250f, 38f), "CreateRoom"))
            {
                UMIHost.UMISartHost(4, 8000);
            }
        }


    }
    
}
