using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent] // prevents multiple scripts for object
public class Oscillator : MonoBehaviour {

    [SerializeField] Vector3 movementVector = new Vector3(10f, 10f, 10f); // store a movement vector
    [SerializeField] float period = 2f;

    float movementFactor; // 0 for not moved, 1 for fully moved
    Vector3 startingPos; // must be stored for absolute movement

	// Use this for initialization
	void Start () {
        startingPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (period <= Mathf.Epsilon) { return; } // protect against NaN for floats 
        // set movement factor
        float cycles = Time.time / period; // grows continually from 0

        const float tau = Mathf.PI * 2f; // about 6.28
        float rawSinWave = Mathf.Sin(cycles * tau); // goes from -1 to +1

        movementFactor = rawSinWave / 2f + 0.5f; // goes from -0.5 to 0.5 to 0 to 1
        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPos + offset;
	}
}
