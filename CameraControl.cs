using System.Collections;
using System.Collections.Generic;
using UnityEngine;  
public class CameraControl : MonoBehaviour
{
    public static CameraControl star;
    //GameObject
    private GameObject target_0;
    //Vector3
    private Vector3 offset_0;
    //float
    protected float smoothSpeed;
    public float offest_1 = -10f; 
    private void Awake()
    {
        this.offset_0 = new Vector3(0f, 0f, offest_1);
        this.smoothSpeed = 0.018f;
        star = this;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        this.offset_0 = new Vector3(0f, 0f, offest_1);
        try
        {
            if (CharacterControl.camera_0 == true)
            {

                this.target_0 = GameObject.Find("girlChar(Clone)");
                Vector3 playerPosition = this.target_0.transform.position + this.offset_0;
                Vector3 smoothedPosition = Vector3.Lerp(transform.position, playerPosition, smoothSpeed);
                this.transform.position = smoothedPosition;
            }
        } catch
        {
            UMI.UMI.Log("UMI::ERRSEND()->NONE_OBJECT_(boyChar)");
            this.transform.position = this.transform.position;
        }
    }
}