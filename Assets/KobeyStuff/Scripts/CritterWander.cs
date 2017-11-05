using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class CritterWander : MonoBehaviour, IInteractable {


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
    public ParticleSystem[] part;
    
    public GameObject Predator;
    public int state;
    public float InsanityDrainOnKill;
    public CritterSpawner spawn;
    public void Interact(Object caller)
    {
        if(CanInteract(caller))
        {
            
            var t = (PlayerInteracter)caller;
            int idx = t.inventory.FindmatchingItemSlot(0);
            if(idx == -1)
            {
                if (!t.inventory.isFull())
                {
                    t.inventory.manager.currentInsanity -= InsanityDrainOnKill;
                    t.inventory.PlaceItem(0, 1);
                    spawn.currentCrittersInGame--;
                    t.inventory.UpdateImages();
                    t.kill.Play();
                    gameObject.SetActive(false);
                }
            }
            else
            {
                t.inventory.manager.currentInsanity -= InsanityDrainOnKill;
                t.inventory.PlaceItem(0, 1);
                spawn.currentCrittersInGame--;
                t.inventory.UpdateImages();
                t.kill.Play();
                gameObject.SetActive(false);
            }
           
           
        }
    }

    public bool CanInteract(Object caller)
    {
        return true;
    }

    void PlayerHeart()
    {
        part[0].Play();
    }

    public void Wander()
    {
        part[0].gameObject.transform.position = transform.position;
        Invoke("PlayerHeart", 1);
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
            if(!part[1].isPlaying)
                part[1].Play();
            Vector3 target = Predator.transform.position + Predator.GetComponent<Rigidbody>().velocity;
            Vector3 dir = -(target - transform.position).normalized;
            Vector3 desiredVelocity = dir * speed;
            Destination = desiredVelocity;
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
        part = GetComponentsInChildren<ParticleSystem>();
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
