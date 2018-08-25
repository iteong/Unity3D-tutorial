using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

	// Use this for initialization
	void Start () {
        print("Console initialised!");
        Terminal.WriteLine("Welcome to Ivan's World!");
        Terminal.WriteLine("Where do you want to hack into?");
        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for the police station");
        Terminal.WriteLine("Enter your selection:");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
