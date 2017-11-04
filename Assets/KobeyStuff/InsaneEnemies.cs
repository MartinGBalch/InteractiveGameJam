using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InsaneEnemies : MonoBehaviour {

    public GameObject target;
    NavMeshAgent agent;
    public float pursuitDistance;
    public float pursuitRange;
    SpriteRenderer sprite;
	// Use this for initialization
	void Start () {
        sprite = GetComponent<SpriteRenderer>();
        target = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        agent.destination = target.GetComponent<Rigidbody>().velocity * pursuitDistance;
        if(Vector3.Distance(transform.position,agent.destination) < pursuitRange)
        {
            agent.destination = target.transform.position;
        }


        if (agent.velocity.x < 0)
        {
            sprite.flipX = false;
        }
        else { sprite.flipX = true; }
    }
}
