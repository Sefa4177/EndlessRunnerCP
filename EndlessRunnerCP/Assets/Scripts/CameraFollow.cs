using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject followObject;//takip edilecek objenin tanımlanması.
    
    private void Start() 
    {
        Time.timeScale = 1;// oyun yeniden başlatıldığında sahne yüklenirken önce oyunun sonundan kalan oyunu durdurma işlemi var ise bu onu düzeltiyor.
    }
    private void FixedUpdate() 
    {
        followCamera();
    }

    //kameranın objeyi biraz arkadan ve biraz üstten takip etmesi için gerekli kod.
    void followCamera()
    {
        transform.position = followObject.transform.position - (Vector3.forward * 3) + (Vector3.up * 1.5f);
    }

    
}
