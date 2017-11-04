using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusManager : MonoBehaviour {

    public float maxHealth;
    public float maxInsanity;
    public float maxHunger;

    //[HideInInspector]
    public float currentHealth;
    public float currentInsanity;
    public float currentHunger;

	// Use this for initialization
	void Start ()
    {
        currentHealth = maxHealth;
        currentHunger = maxHunger;
        currentInsanity = maxInsanity;
	}
	
	// Update is called once per frame
	void Update ()
    {
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        currentInsanity = Mathf.Clamp(currentInsanity, 0, maxInsanity);
        currentHunger = Mathf.Clamp(currentHunger, 0, maxHunger);
    }
}
