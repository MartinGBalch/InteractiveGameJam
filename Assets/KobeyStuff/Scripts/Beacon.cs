using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beacon : MonoBehaviour, IInteractable
{
    StatusManager manager;
    public bool Active;
    public float increment;
	// Use this for initialization
	void Start ()
    {
        Active = false;
        manager = FindObjectOfType<StatusManager>();
	}

    public void Interact(Object caller)
    {
        if(CanInteract(caller))
        {
            Active = true;
        }
    }

    public bool CanInteract(Object caller)
    {
        return !Active;
    }


    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player" && Active)
        {
            manager.currentInsanity += increment * Time.deltaTime;
            
            //manager.currentInsanity = Mathf.Lerp(manager.currentInsanity, manager.maxInsanity, 0.02f * Time.deltaTime);
        }
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}
