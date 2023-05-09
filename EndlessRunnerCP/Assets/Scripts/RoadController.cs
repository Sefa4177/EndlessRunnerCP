using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadController : MonoBehaviour
{
    //oluşturmak istediğimiz road objesine ait prefab.
    public GameObject roadPrefab;
    public void SpawnNextRoad(Vector3 roadSpawnPosition)
    {
        //methoda verilen noktada verilen prefabdaki road objesini oluşturur.
        Instantiate(roadPrefab, roadSpawnPosition, Quaternion.identity);
    }
}
