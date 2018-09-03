using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    // member global variables
    Rigidbody rigidBody;
    float rotationSpeed = 20;

    AudioSource audioSource;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        Thrust();
        Rotate();
    }

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddRelativeForce(Vector3.up);
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }
    }

    private void Rotate()
    {
        rigidBody.freezeRotation = true; // take manual control of rotation

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(rotationSpeed * (Vector3.forward * Time.deltaTime)); // Time.deltaTime is last frame time
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(rotationSpeed * (-Vector3.forward * Time.deltaTime));
        }

        rigidBody.freezeRotation = false; // resume physics control of rotation
   }
}
