using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashingButton : MonoBehaviour
{
    public Text enter;
    public RawImage stroke;
    bool On = false;
    public Color Blink;
    public Color noBlink;
    public Color Blink2;
    public Color noBlink2;
    public float startTime;
    private float currentTime;

    // Use this for initialization
    void Start () {}

	void OnOff()
    {
        if(On)
        {
            enter.color = Blink;
            stroke.color = Blink2;
            On = false;
        }
        else
        {
            enter.color = noBlink;
            stroke.color = noBlink2;
            On = true;
        }
    }
	// Update is called once per frame
	void Update ()
    {
        currentTime -= Time.deltaTime;
        if(currentTime < 0)
        {
            OnOff();
            currentTime = startTime;
        }		
	}
}
