using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampFire : MonoBehaviour , IInteractable{
    StatusManager manager;
    public bool Lit;
    // Use this for initialization
    void Start () {
        Lit = false;
        manager = FindObjectOfType<StatusManager>();
    }


    public void Interact(Object caller)
    {
        if(CanInteract(caller))
        {
            // Cook Food
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
    void Update () {
		
	}
}
