using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.XR.Interaction.Toolkit.AffordanceSystem.Receiver.Primitives;

public class Timer : MonoBehaviour

{
    public float Timeleft;
    public bool TimerOn = false;

   // public Text TimerText;
     void Start()
    {
        TimerOn= true;
    }

    private void Update()
    {
        if(TimerOn)
        {
            if(Timeleft> 0)
            {
                Timeleft -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Over");
                Timeleft= 0;
                TimerOn = false;
            }
        }
    }

    void updateTimer (float currentTime)
    {
        currentTime += 1;
        float minute = Mathf.FloorToInt(currentTime/60);
        float seconds = Mathf.FloorToInt(currentTime%60);
    }






}