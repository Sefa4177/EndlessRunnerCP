using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadController : MonoBehaviour
{
    //oluşturmak istediğimiz road objesine ait prefab.
    [SerializeField] private GameObject roadPrefab;
    public void SpawnNextRoad(Vector3 roadSpawnPosition)
    {
        //methoda verilen noktada verilen prefabdaki road objesini oluşturur.
        Instantiate(roadPrefab, roadSpawnPosition +Vector3.forward * 50, Quaternion.identity);
    }
}
