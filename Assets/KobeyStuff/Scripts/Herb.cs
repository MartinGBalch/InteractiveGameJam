using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Herb : MonoBehaviour, IInteractable {

    StatusManager manager;
    public float healAmount;
    public HerbSpawn spawn;
	// Use this for initialization
	void Start ()
    {
       
        manager = FindObjectOfType<StatusManager>();	
	}


    public void Interact(Object caller)
    {
        manager.currentHealth += healAmount;
        manager.currentHealth = Mathf.Clamp(manager.currentHealth, 0, manager.maxHealth);
        spawn.currentHerbsInGame--;
        gameObject.SetActive(false);
    }
    public bool CanInteract(Object caller)
    {
        return true;   
    }

	// Update is called once per frame
	void Update () {
		
	}
}
