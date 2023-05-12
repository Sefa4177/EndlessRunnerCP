using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadAndObtaclesController : MonoBehaviour
{
    [SerializeField] private GameObject spawnLocationObject;// Taşıncak roadların Taşınacağı noktayı ayarlamak için tanımlama.
    [SerializeField] private GameObject MovedRoad;//taşınacak road.
    [SerializeField] private List<GameObject> obstaclePoints; // randomda kullanılcak engel noktaları.
    [SerializeField] private List<GameObject> ObstaclesList; // yol üstündeki bütün engellerin tanımlandığı liste.
    public List<GameObject> selectedPoints = new List<GameObject>(); // random Seçilen noktaların tutulacağı liste.

    private void OnTriggerEnter(Collider other) //herhangi bir obje değilde sadece karakter objesi icinden gectiğinde çalışacak.
    {
        if(other.gameObject.name.Equals("Character"))
        {
            MovedRoad.transform.position = spawnLocationObject.transform.position + Vector3.forward * 150;
            selectedRandomPoint();
            reLocateObstacles(selectedPoints);
        }
        
    }

    public void selectedRandomPoint() //engeller için rastgele noktalar seçer
    {   
        selectedPoints.Clear();//her yeni kullanımda listeyi temizleyerek başla.
        int pointCount = obstaclePoints.Count;
        if (pointCount == 0) return; // Eğer nokta yoksa işlemi durdur.

        for (int i = 0; i < ObstaclesList.Count; i++)
        {
            GameObject selectedPoint = obstaclePoints[Random.Range(0, pointCount)]; // Rastgele bir nokta seç.
            while (selectedPoints.Contains(selectedPoint))
            {
                // Daha önce seçilmiş bir nokta seçildiğinde farklı bir nokta seç.
                selectedPoint = obstaclePoints[Random.Range(0, pointCount)];
            }
            selectedPoints.Add(selectedPoint); //Seçilen noktayı listeye ekle.
        }
    }

    public void reLocateObstacles(List<GameObject>selectedPoints) //engelleri verilen noktalarda oluşturur
    {

        for(int i = 0 ; i < selectedPoints.Count ; i++)
        {
            ObstaclesList[i].transform.position = selectedPoints[i].transform.position;
        }
    }   
}
