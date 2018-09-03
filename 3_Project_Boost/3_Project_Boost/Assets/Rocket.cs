﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    Rigidbody rigidBody;

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

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rigidBody.AddRelativeForce(Vector3.left);
        } 
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidBody.AddRelativeForce(Vector3.right);
        } 
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            rigidBody.AddRelativeForce(Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            rigidBody.AddRelativeForce(Vector3.back);
        }
    }
}
