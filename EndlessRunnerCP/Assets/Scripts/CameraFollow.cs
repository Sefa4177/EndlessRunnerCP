using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //takip edilecek objenin tanımlanması.
    public GameObject followObject;
    
    
    private void FixedUpdate() 
    {
        followCamera();
    }

    //kameranın objeyi biraz arkadan ve biraz üstten takip etmesi için gerekli kod.
    void followCamera()
    {
        transform.position = followObject.transform.position - (Vector3.forward * 3) + (Vector3.up * 2);
    }

    
}
