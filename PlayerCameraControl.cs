using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UMI; 
public class PlayerCameraControl : MonoBehaviour
{
    public static PlayerCameraControl star;
    //GameObject
    private GameObject target_0;
    //Vector3
    private Vector3 offset_0;
    //float
    protected float smoothSpeed;
    protected float offest_1 = -10f; 
    private void Awake()
    {
        star = this;
        this.offset_0 = new Vector3(0f, 0f, offest_1);
        this.smoothSpeed = 0.018f;
    }
    public void updateOffset(float offset)
    {
        this.offest_1 = offset; 
    }
    // Update is called once per frame
    void LateUpdate()
    {
        this.offset_0 = new Vector3(0f, 0f, offest_1);
        try
        {
            if (CharacterControl.camera_0 == true)
            {
                UMISystem.L0g("camera condition");
                if (GameObject.Find("girlChar(Clone)") != null)
                {
                    UMISystem.L0g("true");
                    this.target_0 = GameObject.Find("girlChar(Clone)");
                    Vector3 playerPosition = this.target_0.transform.position + this.offset_0;
                    Vector3 smoothedPosition = Vector3.Lerp(transform.position, playerPosition, smoothSpeed);
                    this.transform.position = smoothedPosition;
                }else
                {
                    this.target_0 = GameObject.Find("boyChar(Clone)");
                    Vector3 playerPosition = this.target_0.transform.position + this.offset_0;
                    Vector3 smoothedPosition = Vector3.Lerp(transform.position, playerPosition, smoothSpeed);
                    this.transform.position = smoothedPosition;
                }
             
            }
        } catch
        {
            UMISystem.Log("UMI::ERRSEND()->NONE_OBJECT_(Player)");
            this.transform.position = this.transform.position;
        }
    }
}