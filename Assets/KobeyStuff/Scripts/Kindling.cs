﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kindling : MonoBehaviour, IInteractable {

	// Use this for initialization

	void Start () {
		
	}

    public void Interact(Object caller)
    {
        var t = (PlayerInteracter)caller;
        if(!t.inventory.isFull())
        {
            t.inventory.PlaceItem(3, 1);
            t.inventory.UpdateImages();
            gameObject.SetActive(false);
        }
    }

    public bool CanInteract(Object caller)
    {
        return true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
