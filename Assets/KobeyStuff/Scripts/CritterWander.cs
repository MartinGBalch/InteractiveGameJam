using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class CritterWander : MonoBehaviour {


    public float speed;
    public float radius;
    public float jitter;
    public float distance;
    public float evadeDistance;
    public float Timer;
    private float currentTimer;
    NavMeshAgent agent;
    public Vector2 Destination;
    SpriteRenderer sprite;
    public GameObject Predator;
    public int state;
    public void Wander()
    {
        Predator = null;
        Destination = Random.insideUnitCircle.normalized * radius;
        Destination = Destination + Random.insideUnitCircle * jitter;
        Destination = Destination.normalized * radius;
        Destination.x += transform.position.x;
        Destination.y += transform.position.z;
        
    }

    public void Evade()
    {
        if(Predator != null)
        {
            Vector3 target = Predator.transform.position + Predator.GetComponent<Rigidbody>().velocity;
            Vector3 dir = -(target - transform.position).normalized;
            Vector3 desiredVelocity = dir * speed;
            Destination = desiredVelocity - agent.velocity;
        }
      
    }

    public void CheckForPredator()
    {
        


        Collider[] hood = Physics.OverlapSphere(transform.position, radius);
        foreach(Collider t in hood)
        {
            if(t.GetComponent<Rigidbody>() != null)
            {
                Predator = t.gameObject;
            }
        }

        
    }

    float getAgentAngle()
    {
        float angle = Vector3.Angle(agent.velocity.normalized, this.transform.forward);
        if (agent.velocity.normalized.x < this.transform.forward.x)
        {
            angle *= -1;
        }
        angle = (angle + 180.0f) % 360.0f;
        return angle;

    }

	// Use this for initialization
	void Start ()
    {
        state = 0;
        sprite = GetComponent<SpriteRenderer>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //CheckForPredator();
        if (Predator != null)
        {
            state = 1;
            if (Vector3.Distance(transform.position, Predator.transform.position) > evadeDistance)
            {
                Predator = null;
                state = 0;
            }
        }
        else { state = 0; }

        switch(state)
        {
            case 0:
                currentTimer -= Time.deltaTime;
                if (currentTimer < 0)
                {
                    currentTimer = Timer;
                    Wander();
                }
                break;
            case 1:
                Evade();
                break;
        }

        
        if (agent.velocity.x < 0)
        {
            sprite.flipX = false;
        }
        else { sprite.flipX = true; }

        agent.destination = new Vector3(Destination.x,transform.position.y,Destination.y);
	}
}
