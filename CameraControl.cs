using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public static CameraControl hInst;
    //GameObject
    private GameObject target_0;
    //Vector3
    protected Vector3 offset_0;
    //float
    protected float smoothSpeed;
   
    private void Awake()
    {
        this.offset_0 = new Vector3(0f, 0f, -10f);
        this.smoothSpeed = 0.018f;
        hInst = this;
       
    }
    private void Start()    
    {
        this.target_0 = GameObject.Find("boyChar(Clone)");
        if (target_0)
        {
            Debug.Log("success");
        }
    }
   

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = this.target_0.transform.position + this.offset_0;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, playerPosition, smoothSpeed);
        this.transform.position = smoothedPosition;
        
    }
}
