using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour 
{
    Rigidbody rb;               // To apply physics actions to GameObject
    float flySpeed;             // Magnitude of force applied to GameObject
    float lastAttack;           // Time of last shooting
    float attackInterval;       // Length between attacks
    //int attackSize;             // Number of time to shoot
    public GameObject bullet;   // Bullet prefab used in attack

	void Start () 
    {
        flySpeed = 750.0f;
        attackInterval = 5.0f;
        //attackSize = 3;
        Attack();
        lastAttack = Time.time;
        rb = GetComponent<Rigidbody>();

        // Set enemy in motion
        rb.AddForce(-Vector3.forward * flySpeed);
	}
	
    // Shoot bullets at itervals to attack
	void Update () 
    {
        float timeSinceLastAttack = Time.time - lastAttack;
        if (timeSinceLastAttack > attackInterval)
        {
            Attack();
            lastAttack = Time.time;
        }
	}

    // Shoot bullets
    void Attack()
    {
        //for (int i = 0; i < attackSize; i++) {
        //    GameObject spawnedBullet = GameObject.Instantiate(bullet);
        //    spawnedBullet.transform.position = new Vector3(
        //        transform.position.x, transform.position.y, transform.position.z + 1.0f);
        //    spawnedBullet.transform.rotation = transform.rotation;
        //}       
    }

    // When enemy GameObject collides with game environment, they are destroyed
    void OnCollisionEnter()
    {
        Destroy(this.gameObject);
    }
}
