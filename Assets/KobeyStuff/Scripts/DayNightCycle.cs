using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour {

    public Material[] skyBoxes;

    public float stateTime;
    private float currentTime;
    public int timeOfDay;
	// Use this for initialization
	void Start ()
    {
        timeOfDay = 0;
        currentTime = stateTime;
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
                RenderSettings.skybox = skyBoxes[timeOfDay];
                RenderSettings.ambientIntensity = 0;
            }
        }
        currentTime = stateTime;
    }

	// Update is called once per frame
	void Update ()
    {
        currentTime -= Time.deltaTime;
        if(currentTime < 0)
        {
            ChangeSkyBox();
        }
	}
}
