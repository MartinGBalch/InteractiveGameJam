using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour {

    public Material[] skyBoxes;
    StatusManager manager;
    public float stateTime;
    private float currentTime;
    public int timeOfDay;
    public float intensity;
    public float InsanityDrain;
	// Use this for initialization
	void Start ()
    {
        manager = FindObjectOfType<StatusManager>();
        intensity = 1;
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
                if(i == 0)
                {
                    intensity = 1;
                }
                RenderSettings.skybox = skyBoxes[timeOfDay];
                RenderSettings.ambientIntensity = intensity;
                //RenderSettings.ambientIntensity = 0;
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
            intensity -= .2f;
            ChangeSkyBox();
        }
        if(timeOfDay > 3)
        {
            manager.currentInsanity -= InsanityDrain * Time.deltaTime;
        }
	}
}
