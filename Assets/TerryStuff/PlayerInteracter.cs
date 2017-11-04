using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteracter : MonoBehaviour {
    public float interactionRadius = 2;
    public Backpack inventory;
    // Use this for initialization
    void Start ()
    {
        inventory = GetComponent<Backpack>();
	}
    private void AttemptInteraction()
    {
        var hits = Physics.OverlapSphere(transform.position, interactionRadius);

        foreach (var hit in hits)
        {
            var interactionTarget = hit.gameObject.GetComponent<IInteractable>();
            if (interactionTarget != null)
            {
                interactionTarget.Interact(this);
            }
        }
    }
    // Update is called once per frame
    void Update ()
    {
        bool interactWish = Input.GetButtonDown("Interact");

        if (interactWish)
        {
            AttemptInteraction();
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }
}
