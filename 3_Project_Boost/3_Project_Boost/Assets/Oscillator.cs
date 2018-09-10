using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent] // prevents multiple scripts for object
public class Oscillator : MonoBehaviour {

    [SerializeField] Vector3 movementVector = new Vector3(10f, 10f, 10f); // store a movement vector
    [SerializeField] float period = 2f;

    // todo remove from inspector later
    [Range(0,1)] [SerializeField] float movementFactor; // 0 for not moved, 1 for fully moved

    Vector3 startingPos; // must be stored for absolute movement

	// Use this for initialization
	void Start () {
        startingPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        // todo protect against period is zero

        // set movement factor
        float cycles = Time.time / period; // grows continually from 0

        const float tau = Mathf.PI * 2f; // about 6.28
        float rawSinWave = Mathf.Sin(cycles * tau); // goes from -1 to +1

        print(rawSinWave);

        movementFactor = rawSinWave / 2f + 0.5f;
        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPos + offset;
	}
}
