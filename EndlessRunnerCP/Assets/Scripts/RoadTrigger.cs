using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadTrigger : MonoBehaviour
{
    // road controller scriptinden methodu alabilmek için tanımlama.
    public RoadController roadController;

    // Yeni basılcak roadların basılacağı noktayı ayarlamak için tanımlama.
    public GameObject spawnLocationObject;

    //herhangi bir obje değilde sadece karakter objesi icinden gectiğinde çalışacak.
    //roadcontrollerdan methodu alıp buradan tetkilnemesi için buraya basıcak.
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.name.Equals("Character"))
        {
            roadController.SpawnNextRoad(spawnLocationObject.transform.position);
        }
        
    }
}
