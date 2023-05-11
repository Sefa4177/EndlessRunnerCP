using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObstaclesCreate : MonoBehaviour
{
    [SerializeField] private List<GameObject> obtaclePoints; // engel noktaları.
    [SerializeField] private int numberOfObstacles; // engel sayısı.
    private List<GameObject> selectedPoints = new List<GameObject>(); // Seçilen noktaların tutulacağı liste.
    [SerializeField] private GameObject obstaclePrefab;
    
   
    private void Awake() 
    {
        selectedRandomPoint();
        createObstacles(selectedPoints);
    }

    #region Methods
    private void selectedRandomPoint() //engeller için rastgele noktalar seçer
    {   
        int pointCount = obtaclePoints.Count;
        if (pointCount == 0) return; // Eğer nokta yoksa işlemi durdur.

        for (int i = 0; i < numberOfObstacles; i++)
        {
            GameObject selectedPoint = obtaclePoints[Random.Range(0, pointCount)]; // Rastgele bir nokta seç.
            while (selectedPoints.Contains(selectedPoint))
            {
                // Daha önce seçilmiş bir nokta seçildiğinde farklı bir nokta seç.
                selectedPoint = obtaclePoints[Random.Range(0, pointCount)];
            }
            selectedPoints.Add(selectedPoint); // Seçilen noktayı listeye ekle.
        }
    }

    private void createObstacles(List<GameObject>selectedPoints) //engelleri verilen noktalarda oluşturur
    {
        foreach (GameObject point in selectedPoints)
        {   Debug.Log("create fonksiyonu");
            Instantiate(obstaclePrefab, point.transform.position, Quaternion.identity);
        }
    }
    
    #endregion
    
}
