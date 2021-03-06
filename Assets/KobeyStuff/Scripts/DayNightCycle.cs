﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayNightCycle : MonoBehaviour {

    public Material[] skyBoxes;
    StatusManager manager;
    public float stateTime;
    private float currentTime;
    public int timeOfDay;
    public float Desiredintensity;
    public float currentInensity;
    public float InsanityDrain;
    public int Day;
    public Text dayText;
    public int winDay;
	// Use this for initialization
	void Start ()
    {
        manager = FindObjectOfType<StatusManager>();
        Day = 1;
        dayText.text = "Day " + Day.ToString();
        Desiredintensity = 2.5f;
        currentInensity = 2.5f;
        timeOfDay = 0;
        currentTime = stateTime;
	}
	
    public bool didYouWin()
    {
        if (Day == winDay + 1 && timeOfDay == 0)
        {
            Debug.Log("Dale is a sick boy");
            return true;
        }
        else
            return false;
    }

    void ChangeSkyBox()
    {
        timeOfDay++;
        if(timeOfDay > skyBoxes.Length)
        {
            timeOfDay = 0;
        }

       for(int i =0;i < skyBoxes.Length; i++)
        {
            if(i == timeOfDay)
            {
                if(i == 0)
                {
                    Desiredintensity = 2.5f;
                }
                RenderSettings.skybox = skyBoxes[timeOfDay];
                if(i == skyBoxes.Length -1)
                {
                    Day++;
                    dayText.text = "Day " + Day.ToString();
                }
                //RenderSettings.ambientIntensity = 0;
            }
        }
        currentTime = stateTime;
    }

	// Update is called once per frame
	void Update ()
    {

        didYouWin();
        currentInensity = Mathf.Lerp(currentInensity, Desiredintensity, Desiredintensity * Time.deltaTime);
        RenderSettings.ambientIntensity = currentInensity;
        currentTime -= Time.deltaTime;
        if(currentTime < 0)
        {
            Desiredintensity -= .4f;
            ChangeSkyBox();
        }
        if(timeOfDay > 3)
        {
            manager.currentInsanity -= InsanityDrain * Time.deltaTime;
        }
	}
}
