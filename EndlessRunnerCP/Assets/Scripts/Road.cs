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
}
