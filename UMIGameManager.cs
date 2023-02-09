using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UMI.Network.Client; 
public class UMIGameManager : MonoBehaviour
{
    public static UMIGameManager hInst;
    //float
    private float display_0; 
    //GameObject
    private GameObject gameObject_0;
  
    //Texture
    private Texture texture_0;
    private void Awake()
    {
        hInst = this; 
        this.Init();
  //      this.gameObject_0 = (GameObject)UnityEngine.Object.Instantiate((GameObject)Resources.Load("GameAssets/Characters/viewChar/boyChar", typeof(GameObject))
  //, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.Euler(0f, 0f, 0f));
    }
    void Start()
    {
       
    }
    void Init()
    {
        //Texture
       

    }
    private void OnGUI()
    {
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, new Vector3((float)Screen.height / 1024f, (float)Screen.height / 1024f, 1f));
        GUI.depth = 2;
        this.display_0 = (float)(1024 * Screen.width / Screen.height);
       
    }
}
