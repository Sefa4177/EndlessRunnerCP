using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    
    private void OnBecameInvisible() 
    {
        //arkada kalan ve görünmeyen yolların destroy edilip yükün azaltılması sağlanır.
        Destroy(gameObject);
    }

    private void Start() 
    {
        Time.timeScale = 1;// oyun yeniden başlatıldığında sahne yüklenirken önce oyunun sonundan kalan oyunu durdurma işlemi var ise bu onu düzeltiyor.
    }

}
   