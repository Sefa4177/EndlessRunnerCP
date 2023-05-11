using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Clock : MonoBehaviour
{
    #region Definitions
    private int hour_ = 0;
    private int minute_ = 0;
    private int seconds_ = 0;
    public Text textClock;
    private float delta_time;
    private bool stop_clock_ = false;
    public int score;
    public static Clock instance;
    #endregion

    //bu script sadece oyundaki sürenin ilerlemesi ve gerektiğinde kullanılması için.
    private void Awake() 
    {
        if(instance)
        {Destroy(instance);}

        instance = this; 

        textClock = GetComponent<Text>(); 

        delta_time = 0;

        if (textClock == null) {
        Debug.LogError("textClock is not assigned in the inspector!");
    }
    }

    private void Start() 
    {
        stop_clock_ = false;
    }

    private void Update() 
    {
        if(stop_clock_ == false)
        {
            delta_time += Time.deltaTime;
            TimeSpan span = TimeSpan.FromSeconds(delta_time);

            string hour = LeadingZero(span.Hours);
            string minute = LeadingZero(span.Minutes);
            string seconds = LeadingZero(span.Seconds);
            score = span.Seconds;

            textClock.text = hour + ":" + minute + ":" + seconds;
            
        }  
            
    }

    string LeadingZero(int n)
    {
        return n.ToString().PadLeft(2, '0');
    }

}
