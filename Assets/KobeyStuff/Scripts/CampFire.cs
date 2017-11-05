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
        Lit = true;
        manager = FindObjectOfType<StatusManager>();
    }


    public void Interact(Object caller)
    {
        
            if(currentTimer < 0)
            {
                var t = (PlayerInteracter)caller;
                
                    int idx = t.inventory.inventorySearch(0);
                    if(idx != -1)
                    {
                        if(t.inventory.PlaceItem(1, 1))
                        {
                            t.inventory.items[idx].InventoryCount--;
                            t.inventory.isEmpty(idx);
                            t.inventory.UpdateImages();
                        }
                        else
                        {
                            Debug.Log("No Space Left");
                        }
                        

                    }
                    else
                    {
                        Debug.Log("You need Raw Meat");
                    }
                    //t.inventory.cookedMeat++;
                   // t.inventory.rawMeat--;
                
               
                currentTimer = interactTimer;
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
