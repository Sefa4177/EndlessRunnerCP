using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadTrigger : MonoBehaviour
{
    public RoadController roadController;// road controller scriptinden methodu alabilmek için tanımlama.
    [SerializeField] private GameObject spawnLocationObject;// Yeni basılcak roadların basılacağı noktayı ayarlamak için tanımlama.

    private void OnTriggerEnter(Collider other) //herhangi bir obje değilde sadece karakter objesi icinden gectiğinde çalışacak.
    {
        if(other.gameObject.name.Equals("Character"))
        {
            roadController.SpawnNextRoad(spawnLocationObject.transform.position);
        }
        
    }
}
