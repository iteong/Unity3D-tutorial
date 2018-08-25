using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

    // Game states
    int level; // member variable available everywhere to store state

    // Use this for initialization
    void Start () {
        print("Console initialised!");

        var greeting = "Welcome to Ivan's World!";
        ShowMainMenu(greeting);
    }

    void ShowMainMenu (string greeting) {
        Terminal.ClearScreen();
        Terminal.WriteLine(greeting);
        Terminal.WriteLine("Where do you want to hack into?");
        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for the police station");
        Terminal.WriteLine("Enter your selection:");
        
    }

    void OnUserInput(string input) {
        Terminal.WriteLine("The user typed " + input);

        print(input == "1"); // print true when this evaluation is true

        if (input == "menu") {
            ShowMainMenu("Welcomed again!"); // user logins again

        } else if (input == "1") {
            level = 1;
            StartGame(level);

        } else if (input == "2") {
            level = 2;
            StartGame(level);
        } else {
            Terminal.WriteLine("Please choose a valid level!");
        }
    }

    private void StartGame(int level)
    {
        Terminal.WriteLine("You have chosen level " + level);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
