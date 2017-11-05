using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerInteracter : MonoBehaviour {
    public float interactionRadius = 2;
    public Canvas displayText;
    public Backpack inventory;
    public ParticleSystem kill;
    public ParticleSystem Drug;
    public ParticleSystem Heal;
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
               // displayText.GetComponent<RectTransform>().SetParent(null);
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
        var hits = Physics.OverlapSphere(transform.position, interactionRadius);
        foreach (var hit in hits)
        {
            var interactionTarget = hit.gameObject.GetComponent<IInteractable>();
            if (interactionTarget != null)
            {
               displayText.GetComponent<RectTransform>().SetParent(hit.transform, false);
                //interactionTarget.Interact(this);
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }
}
