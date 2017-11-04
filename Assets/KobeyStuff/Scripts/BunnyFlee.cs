using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyFlee : MonoBehaviour {

    public float radius;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Collider[] hood = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider t in hood)
        {
            if (t.GetComponent<CritterWander>() != null)
            {
                t.GetComponent<CritterWander>().Predator = this.gameObject;
            }
        }
    }
}
