using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] float startTime;
    public float currentTime;
    public bool timerOn = false;
    public bool timeUp = false;
    [SerializeField] TMP_Text timerText;


    // Start is called before the first frame update
    void Start()
    {
        timerOn = true;
        currentTime = startTime;
        timerText.text = "Time: " + currentTime.ToString("f1") + "s";
    }

    // Update is called once per frame
    void Update()
    {
        if (timerOn)
        {
                currentTime -= Time.deltaTime;
                
            if(currentTime <=0)
            {
                Debug.Log("Time is Up");
                timerOn = false;
                timeUp = true;
                currentTime = 0;
            }

            timerText.text = "Time: " + currentTime.ToString("f1") +"s";
        }
    }

 
 
}
