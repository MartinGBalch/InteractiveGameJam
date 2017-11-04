using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusManager : MonoBehaviour {

    public float maxHealth;
    public float maxInsanity;
    public float maxHunger;

    [HideInInspector]
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
		
	}
}
