using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject followObject;
    
    private void FixedUpdate() 
    {
        transform.position = followObject.transform.position - (Vector3.forward * 3) + (Vector3.up * 2);
    }

    
}
