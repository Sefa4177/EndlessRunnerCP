using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Obstacle : MonoBehaviour
{
    
    private void OnBecameInvisible() 
    {
        //arkada kalan ve görünmeyen yolların destroy edilip yükün azaltılması sağlanır.
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other) //herhangi bir obje değilde sadece karakter objesi icinden gectiğinde çalışacak.
    {
        
        GameButtons.Instance.gameOver = true;
    }
    
    

}
