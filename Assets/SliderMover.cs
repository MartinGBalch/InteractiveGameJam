using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SliderMover : MonoBehaviour {

    Image slider;
    public Image[] pos;
    DayNightCycle cycle;
    RectTransform myT;
    bool doOver = true;
    Vector3 startPos;
	// Use this for initialization
	void Start ()
    {
        
        myT = GetComponent<RectTransform>();
        slider = GetComponent<Image>();
        cycle = FindObjectOfType<DayNightCycle>();
        startPos = myT.transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 lerpPos;
        switch (cycle.timeOfDay)
        {
             
            case 0:
                if(doOver)
                {
                    myT.transform.position = startPos;
                    doOver = false;
                }
                lerpPos = pos[0].rectTransform.position;
                lerpPos.y = myT.position.y;
                myT.position = Vector3.Lerp(myT.position, lerpPos, cycle.stateTime * Time.deltaTime /50);
                break;
            case 1:
                lerpPos = pos[1].rectTransform.position;
                lerpPos.y = myT.position.y;
                myT.position = Vector3.Lerp(myT.position, lerpPos, cycle.stateTime * Time.deltaTime / 50);
                break;
            case 2:
                lerpPos = pos[2].rectTransform.position;
                lerpPos.y = myT.position.y;
                myT.position = Vector3.Lerp(myT.position, lerpPos, cycle.stateTime * Time.deltaTime / 50);
                break;
            case 3:
                lerpPos = pos[3].rectTransform.position;
                lerpPos.y = myT.position.y;
                myT.position = Vector3.Lerp(myT.position, lerpPos, cycle.stateTime * Time.deltaTime / 50);
                break;
            case 4:
                doOver = true;
                lerpPos = pos[4].rectTransform.position;
                lerpPos.y = myT.position.y;
                myT.position = Vector3.Lerp(myT.position, lerpPos, cycle.stateTime * Time.deltaTime / 50);
                break;
        }
	}
}
