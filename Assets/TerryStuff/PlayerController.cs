using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 moveWish;
    private Rigidbody rbody;
    private Collider col;

    [Header("Movement Attributes")]
    public float groundFriction = 15;
    public float groundAcceleration = 300;
    public float maxGroundVelocity = 5;

    private Vector3 groundPoint;

    private Vector3 targetVelocity;

    private bool grounded;
    private float hover = 0.05f;

    // Returns the final velocity of the player after accelerating in a certain direction.
    protected Vector3 Accelerate(Vector3 wishDir, Vector3 prevVelocity, float accelerate, float maxVelocity)
    {
        float projectVel = Vector3.Dot(prevVelocity, wishDir);
        float accelerationVel = accelerate * Time.fixedDeltaTime;  // match fixed time step

        // cap acceleration vector
        if (projectVel + accelerationVel > maxVelocity)
            accelerationVel = maxVelocity - projectVel;

        return prevVelocity + wishDir * accelerationVel;
    }

    // Returns the final velocity of the player after accelerating on the ground.
    protected Vector3 MoveGround(Vector3 wishDir, Vector3 prevVelocity)
    {
        // apply friction if was moving
        float speed = prevVelocity.magnitude;
        if (speed != 0) // To avoid divide by zero errors
        {
            // decelerate due to friction
            float drop = speed * groundFriction * Time.fixedDeltaTime;

            // scale the velocity based on friction.
            prevVelocity *= Mathf.Max(speed - drop, 0) / speed; // be careful to not drop below zero
            
        }

        return Accelerate(wishDir, prevVelocity, groundAcceleration, maxGroundVelocity);
    }

    void CheckGround()
    {
        var hits = Physics.RaycastAll(transform.position, Vector3.down, Mathf.Infinity);
        
        foreach(var hit in hits)
        {
            if(hit.collider == col)
            {
                continue;
            }
            groundPoint = hit.point;

            grounded = true;
            break;
        }
    }

    // Unity Event Loop

    void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        moveWish.x = Input.GetAxisRaw("Horizontal");
        moveWish.y = 0.0f;
        moveWish.z = Input.GetAxisRaw("Vertical");

        targetVelocity = MoveGround(moveWish, rbody.velocity);

       
    }

    void FixedUpdate()
    {
        grounded = false;
        CheckGround();
        rbody.velocity = targetVelocity;

        if(grounded)
        {
            Vector3 position = transform.position;
            position.y = groundPoint.y + hover;

            transform.position = position; 
        }
    }

  
}
