using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInteractable : MonoBehaviour, IInteractable
{
    public bool CanInteract(Object caller)
    {
        return true;
    }

    public void Interact(Object caller)
    {
        Debug.Log("Interaction initiated on " + gameObject.name + " by " + ((Component)caller).gameObject.name);
    }
}
