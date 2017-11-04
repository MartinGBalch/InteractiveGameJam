using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backpack : MonoBehaviour {

    public int rawMeat;
    public int cookedMeat;
    public float rawHungerRefil; // status effect on Eat
    public float rawInsanityDrain;
    public float rawHealthDrain;
    public float cookedInsanityRefill;
    public float cookedHungerRefill;
    public
    StatusManager manager;
	// Use this for initialization
	void Start ()
    {
        manager = FindObjectOfType<StatusManager>();
        rawMeat = 0;
        cookedMeat = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetMouseButtonDown(0) && rawMeat > 0)
        {
            rawMeat--;
            manager.currentHunger += rawHungerRefil;
            manager.currentHealth -= rawHealthDrain;
            manager.currentInsanity -= rawHealthDrain;
        }
        if (Input.GetMouseButtonDown(1) && cookedMeat > 0)
        {
            cookedMeat--;
            manager.currentHunger += cookedHungerRefill;
            manager.currentInsanity += cookedInsanityRefill;
            
        }
    }
}
