using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    // member global variables
    Rigidbody rigidBody;
    float rotationSpeed = 20;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        ProcessInput();
    }

    private void ProcessInput() {
        if (Input.GetKey(KeyCode.Space)) {
            rigidBody.AddRelativeForce(Vector3.up);
        }

        // rotate rocket left or right
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(rotationSpeed * (Vector3.forward * Time.deltaTime)); // Time.deltaTime is last frame time
        } 
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(rotationSpeed * (-Vector3.forward * Time.deltaTime));
        } 
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(rotationSpeed * (Vector3.right * Time.deltaTime));
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(rotationSpeed * (-Vector3.right * Time.deltaTime));
        }
    }
}
