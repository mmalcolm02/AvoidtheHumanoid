using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    //script to begin timer and set the count down to end game.
    [SerializeField] float startTime;
    public float currentTime;
    public bool timerOn = false;
    public bool timeUp = false;
    [SerializeField] TMP_Text timerText;


    // begin the timer and specify the values on the timer
    void Start()
    {
        timerOn = true;
        currentTime = startTime;
        timerText.text = "Time: " + currentTime.ToString("f1") + "s";
    }

    // Update timer 
    void Update()
    {
        if (timerOn)
        {
                currentTime -= Time.deltaTime;
                
            if(currentTime <=0)
            {
                //Debug.Log("Time is Up");
                timerOn = false;
                timeUp = true;
                currentTime = 0;
            }

            timerText.text = "Time: " + currentTime.ToString("f1") +"s";
        }
    }

 
 
}
