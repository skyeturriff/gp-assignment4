using UnityEngine;
using System.Collections;

/*
 * This script controls behaviour of bullets (projectiles). Causes bullets 
 * to be propelled forward in their current facing direction, and to "die" 
 * after lifespan seconds have passed since instantiation.
 */
public class BulletController : MonoBehaviour {

    Rigidbody rb;
    float movementSpeed;    // Speed at which the bullet travels
    float timeAlive;        // Time bullet was instantiated
    float lifespan;         // Length of time bullet can be active for

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        movementSpeed = 5.0f;
        lifespan = 0.5f;
        timeAlive = Time.time;
    }

    // Calculate how long bullet has been active for, and destroy
    // bullet if it is longer than the allowed lifespan
    void Update()
    {
        float timeSinceAlive = Time.time - timeAlive;

        if (timeSinceAlive >= lifespan)
            DestroyObject(gameObject);
    }

    // Propell bullet forward in its current direction
    void FixedUpdate()
    {
        rb.AddForce(-transform.forward * movementSpeed);
    }
}
