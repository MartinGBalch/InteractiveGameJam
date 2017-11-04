using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    void Interact(Object caller);
    bool CanInteract(Object caller);
}

public interface ICorruptable
{
    void UpdateSprite(int idx);
}