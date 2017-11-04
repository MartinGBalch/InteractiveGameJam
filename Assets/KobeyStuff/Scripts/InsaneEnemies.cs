using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InsaneEnemies : MonoBehaviour {

    public GameObject target;
    NavMeshAgent agent;
    StatusManager manager;
    public float pursuitDistance;
    public float pursuitRange;
    public float attackRange;
    public float damage;
    SpriteRenderer sprite;
    private float attackDelay;
	// Use this for initialization
	void Start () {
        attackDelay = .5f;
        manager = FindObjectOfType<StatusManager>();
        sprite = GetComponent<SpriteRenderer>();
        target = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
	}
	
    void dealDamage()
    {
        attackDelay -= Time.deltaTime;
        if(attackDelay < 0)
        {
            manager.currentHealth -= damage;
            attackDelay = .5f;
        }
        
    }

	// Update is called once per frame
	void Update ()
    {
        agent.destination = target.transform.position + target.GetComponent<Rigidbody>().velocity * pursuitDistance;
        if(Vector3.Distance(transform.position,agent.destination) < pursuitRange)
        {
            agent.destination = target.transform.position;
        }

        if (Vector3.Distance(transform.position, target.transform.position) < attackRange)
        {
            //Debug.Log("Invoking");
            //Invoke("dealDamage",.5f);
            dealDamage();
        }
        else
        {
            attackDelay = .5f;
            //Debug.Log("Not --- Invoking");
            // CancelInvoke("dealDamage");
        }

        if (agent.velocity.x < 0)
        {
            sprite.flipX = false;
        }
        else { sprite.flipX = true; }
    }
}
