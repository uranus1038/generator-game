using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UMI.Network.Client; 
public class Room : MonoBehaviour
{
    public static Room star;
    protected float display_0; 
    private Texture texture_0;
    private Texture texture_1;
    private Texture texture_2;
    private Texture texture_3;
    // Resources
    List<string> playerObject_0 = new List<string>();
    List<string> playerObject_1 = new List<string>();
    private  Dictionary<int, bool> players = new Dictionary<int, bool>();

    private void Awake()
    {
        this.Init();
        if (star == null)
        {
            star = this;
        }
        else if (star != this)
        {
            Debug.Log($"UMI::DESTROY()->INSTANCE");
            Destroy(this);
        }
    }
    private void Init()
    {
        this.texture_0 = (Texture)Resources.Load("GUI/Lobby/Friend_box", typeof(Texture));
        this.texture_1 = (Texture)Resources.Load("GUI/Lobby/Friend_box_wait", typeof(Texture));
        this.texture_2 = (Texture)Resources.Load("GameAssets/Characters/2DCharacter/boyCharacter", typeof(Texture));
        this.texture_3 = (Texture)Resources.Load("GameAssets/Characters/2DCharacter/girlCharacter", typeof(Texture));
    }
    public void spawnLobby(int slot, string userName , string  gender)
    {
        try
        {
            UMI.UMISystem.Log(slot);
            this.playerObject_0.Add(gender);
            this.playerObject_1.Add(userName);    
            this.players.Add(slot, true);
        }catch
        {
            UMI.UMISystem.L0g("CALLBACK_SERVER");
            
        }
        
    }
    private void OnGUI()
    {
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3((float)Screen.height / 1024f, (float)Screen.height / 1024f, 1f));
        GUI.depth = 1;
        this.display_0 = (float)(1024 * Screen.width / Screen.height);
        try
        {
            if (players[1])
            {
                if (playerObject_0[0].ToString() == "male")
                {
                    GUI.DrawTexture(new Rect(0.5f * this.display_0 - 638f, 180f, 508f / 2f, 629f / 2f), this.texture_0);
                    GUI.DrawTexture(new Rect(0.5f * this.display_0 - 638f, 190f, 508f / 2f, 728f / 2f), this.texture_2);
                }
                else
                {
                    GUI.DrawTexture(new Rect(0.5f * this.display_0 - 638f, 180f, 508f / 2f, 629f / 2f), this.texture_0);
                    GUI.DrawTexture(new Rect(0.5f * this.display_0 - 638f, 190f, 508f / 2f, 728f / 2f), this.texture_3);
                }
            }
            else
            {
                GUI.DrawTexture(new Rect(0.5f * this.display_0 - 638f, 180f, 508f / 2f, 629f / 2f), this.texture_1);
            }
            if (players[2])
            {
                if (playerObject_0[1].ToString() == "male")
                {

                    GUI.DrawTexture(new Rect(0.5f * this.display_0 - 338f, 220f, 508f / 2f, 629f / 2f), this.texture_0);
                    GUI.DrawTexture(new Rect(0.5f * this.display_0 - 338f, 230f, 508f / 2f, 728f / 2f), this.texture_2);
                }
                else 
                {
                    GUI.DrawTexture(new Rect(0.5f * this.display_0 - 338f, 220f, 508f / 2f, 629f / 2f), this.texture_0);
                    GUI.DrawTexture(new Rect(0.5f * this.display_0 - 338f, 230f, 508f / 2f, 728f / 2f), this.texture_3);
                }
            }
            else
            {
                GUI.DrawTexture(new Rect(0.5f * this.display_0 - 338f, 220f, 508f / 2f, 629f / 2f), this.texture_1);
            }
            if (players[3])
            {
                if (playerObject_0[2].ToString() == "male")
                {
                    GUI.DrawTexture(new Rect(0.5f * this.display_0 + 88f, 180f, 508f / 2f, 629f / 2f), this.texture_0);
                    GUI.DrawTexture(new Rect(0.5f * this.display_0 + 88f, 190f, 508f / 2f, 728f / 2f), this.texture_2);
                }
                else 
                {
                    GUI.DrawTexture(new Rect(0.5f * this.display_0 + 88f, 180f, 508f / 2f, 629f / 2f), this.texture_0);
                    GUI.DrawTexture(new Rect(0.5f * this.display_0 + 88f, 190f, 508f / 2f, 728f / 2f), this.texture_3);
                }
            }
            else
            {
                GUI.DrawTexture(new Rect(0.5f * this.display_0 + 88f, 220f, 508f / 2f, 629f / 2f), this.texture_1);
            }
            if (players[4])
            {
                if (playerObject_0[3].ToString() == "male")
                {
                    GUI.DrawTexture(new Rect(0.5f * this.display_0 + 338f, 180f, 508f / 2f, 629f / 2f), this.texture_0);
                    GUI.DrawTexture(new Rect(0.5f * this.display_0 + 338f, 190f, 508f / 2f, 728f / 2f), this.texture_2);
                }
                else 
                {
                    GUI.DrawTexture(new Rect(0.5f * this.display_0 + 338f, 180f, 508f / 2f, 629f / 2f), this.texture_0);
                    GUI.DrawTexture(new Rect(0.5f * this.display_0 + 338f, 190f, 508f / 2f, 728f / 2f), this.texture_3);
                }
            }
            else
            {
                GUI.DrawTexture(new Rect(0.5f * this.display_0 + 388f, 180f, 508f / 2f, 629f / 2f), this.texture_1);
            }
        }catch

        {
            
        }
      

    }
}
