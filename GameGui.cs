using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGui : MonoBehaviour
{
    private float delay_0;
    private float display_0;
    private eGameState eGameState;

    Texture texture_0;
    Texture texture_1;
    Texture texture_2;
    private void Awake()
    {
        this.Init();
    }
    private void Init()
    {
        this.texture_0 = (Texture)Resources.Load("GUI/Skill/Dash", typeof(Texture));
        this.texture_1= (Texture)Resources.Load("GUI/Skill/Navigate", typeof(Texture));
        this.texture_2 = (Texture)Resources.Load("GUI/Skill/Spray", typeof(Texture));
    }
    private void Start()
    {
        this.eGameState = eGameState.Start; 
    }
    private void OnGUI()
    {
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3((float)Screen.height / 1024f, (float)Screen.height / 1024f, 1f));
        GUI.depth = 2;
        this.display_0 = (float)(1024 * Screen.width / Screen.height);
        if(Game.GameOn)
        {
            Game.isMove_0 = true; 
            if(this.eGameState == eGameState.Start)
            {
                this.eGameState = eGameState.fadeInGame;
                this.delay_0 = Time.time; 
            }
            if (this.eGameState == eGameState.fadeInGame)  
            {
                GUI.DrawTexture(new Rect(0.5f * this.display_0 - 423/2f, Mathf.SmoothStep(1000, 828f, Time.time - this.delay_0), 262f / 2f, 298f / 2f), this.texture_0);
                GUI.DrawTexture(new Rect(0.5f * this.display_0 - 131/2f, Mathf.SmoothStep(1000, 830f, Time.time - this.delay_0), 262f / 2f, 298f / 2f), this.texture_1);
                GUI.DrawTexture(new Rect(0.5f * this.display_0 + 161/2f, Mathf.SmoothStep(1000, 829f, Time.time - this.delay_0), 262f / 2f, 298f / 2f), this.texture_2);
            }
        }
    }
}
