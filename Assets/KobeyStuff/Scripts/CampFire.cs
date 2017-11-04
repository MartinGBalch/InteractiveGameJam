using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampFire : MonoBehaviour , IInteractable{
    StatusManager manager;
    public bool Lit;
    public float interactTimer;
    private float currentTimer;
    // Use this for initialization
    void Start () {
        Lit = false;
        manager = FindObjectOfType<StatusManager>();
    }


    public void Interact(Object caller)
    {
        if(CanInteract(caller))
        {
            if(currentTimer < 0)
            {
                var t = (PlayerInteracter)caller;
                if(t.inventory.rawMeat > 0)
                {
                    t.inventory.cookedMeat++;
                    t.inventory.rawMeat--;
                }
               
                currentTimer = interactTimer;
            }
           
        }
        else
        {
            Lit = true;
        }
    }
    public bool CanInteract(Object caller)
    {
        return Lit;
    }

    // Update is called once per frame
    void Update ()
    {
        if(Lit)
        {
            currentTimer -= Time.deltaTime;
        }
        
	}
}
