using UnityEngine;
using System.Collections;

public class PassCheckpoint : MonoBehaviour 
{
    public GameController gameController;
    AudioSource audiosource;

    void Start() {
        audiosource = GetComponent<AudioSource>();
    }

    // If player GameObject passes through checkpoint, they gain a point
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            gameController.AddPoint();
            audiosource.Play();
        }
    }
}
