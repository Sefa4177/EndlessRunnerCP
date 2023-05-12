using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Obstacle : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) 
    {   
        //herhangi bir obje değilde sadece karakter objesi çarptığında çalışacak.
        if(other.gameObject.name.Equals("Character"))
        {
            GameButtons.Instance.gameOver = true;
        }
    } 

}
