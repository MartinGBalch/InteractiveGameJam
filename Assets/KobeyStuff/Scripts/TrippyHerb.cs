using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrippyHerb : MonoBehaviour, IInteractable
{
    public HerbSpawn spawn;
    StatusManager manager;
    public float InsanityDrain;
    // Use this for initialization
    void Start()
    {
        manager = FindObjectOfType<StatusManager>();
    }

    public void Interact(Object caller)
    {
        manager.currentInsanity -= InsanityDrain;
        spawn.currentHerbsInGame--;
        gameObject.SetActive(false);
      //  manager.currentHealth = Mathf.Clamp(manager.currentHealth, 0, manager.maxHealth);

    }

    public bool CanInteract(Object caller)
    {
        return true;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
