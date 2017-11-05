using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Herb : MonoBehaviour, IInteractable {

    StatusManager manager;
    
    public HerbSpawn spawn;
	// Use this for initialization
	void Start ()
    {
       
        manager = FindObjectOfType<StatusManager>();	
	}


    public void Interact(Object caller)
    {
        var t = (PlayerInteracter)caller;
        if (!t.inventory.isFull())
        {
            t.Heal.Play();
            t.inventory.PlaceItem(2, 1);
            spawn.currentHerbsInGame--;
            t.inventory.UpdateImages();
            gameObject.SetActive(false);
        }


        // manager.currentHealth += healAmount;
        //manager.currentHealth = Mathf.Clamp(manager.currentHealth, 0, manager.maxHealth);
       
    }
    public bool CanInteract(Object caller)
    {
        return true;   
    }

	// Update is called once per frame
	void Update () {
		
	}
}
