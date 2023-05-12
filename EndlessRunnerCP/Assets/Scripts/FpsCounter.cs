using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsCounter : MonoBehaviour
{
    // bu script fps değerini ekrana bastırır bunu kullandım çünkü telefonda oynarken fps düşüyor mu görmek istedim.
    private float count;
    
    private IEnumerator Start()
    {
        GUI.depth = 2;
        while (true)
        {
            count = 1f / Time.unscaledDeltaTime;
            yield return new WaitForSeconds(0.1f);
        }
    }
    
    private void OnGUI()
    {
        
        GUI.Label(new Rect(1750, 70, 100, 25), "FPS: " + Mathf.Round(count));
    }
}
