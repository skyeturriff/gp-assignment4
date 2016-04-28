using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
    public GameController controller;   // Reference to Gamecontroller object in this scene   
    Rigidbody rb;                       // Allow physics actions to be applied to player
    public GameObject bullet;           // Reference to bullet prefab player will fire

    public float flySpeed;              // Controls magnitude of force applied to player in beginning
    public float rollSpeed;             // Speed to complete aileron loop
    private Vector3 rotation;           // Stores player GameObject's rotation
    private Vector3 rollDirection;      // Direction to perform aileron loop in

	void Start () 
    {
        // Apply initial force to propel GameObject forward continuously
        rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.forward * flySpeed);

        // Get start positioning of player GameObject
        rotation = transform.rotation.eulerAngles;
        rollDirection = rotation;
	}
	
	void Update () 
    {
        // Check for fire
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject spawnedBullet = GameObject.Instantiate(bullet);
            spawnedBullet.transform.position = new Vector3(
                transform.position.x, transform.position.y, transform.position.z + 1.0f);
            spawnedBullet.transform.rotation = transform.rotation;
        }

        // Check for horizontal movement (aileron roll)
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rollDirection.z += 360.0f;
        }

        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            rollDirection.z -= 360.0f;
        }

        // Perform aileron roll using change in rotation per second
        rotation = Vector3.Lerp(rotation, rollDirection, rollSpeed * Time.deltaTime);
        transform.eulerAngles = rotation;      
	}

    void FixedUpdate()
    {
        // Check for change in elevation of player (inverted)
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(Vector3.down);
        }

        else if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(Vector3.up);
        }

        // Apply sideways thrust to aileron roll
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(Vector3.left, ForceMode.Impulse);
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(Vector3.right, ForceMode.Impulse);
        }
    }
}
