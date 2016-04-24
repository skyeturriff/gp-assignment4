using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
    public float flySpeed;

	void Start () 
    {
	
	}
	
	void Update () 
    {
        transform.position += Vector3.forward * flySpeed * Time.deltaTime;
	}
}
