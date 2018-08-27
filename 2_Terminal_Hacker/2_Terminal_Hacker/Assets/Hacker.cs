﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

    // Game states
    int level; // member variable available everywhere to store state

    enum Screen {MainMenu, Password, WinScreen} // new variable type to store state using enum type (Finite state machines)
    Screen currentScreen;

    // Use this for initialization
    void Start () {
        print("Console initialised!");

        var greeting = "Welcome to Ivan's World!";
        ShowMainMenu(greeting);
    }

    void ShowMainMenu (string greeting) {
        currentScreen = Screen.MainMenu; // set screen to main menu so won't think it is on other screens
        Terminal.ClearScreen();
        Terminal.WriteLine(greeting);
        Terminal.WriteLine("Where do you want to hack into?");
        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for the police station");
        Terminal.WriteLine("Enter your selection: ");
        
    }

    void OnUserInput(string input) { // method only for handling input, not actually execute menu
        Terminal.WriteLine("The user typed " + input);

        print(input == "menu"); // print true when this evaluation is true

        if (input == "menu") { // we can always go direct to main menu
            ShowMainMenu("Welcomed again!"); // user logins again

        } else if (currentScreen == Screen.MainMenu) { // if user is already on main menu
            RunMainMenu(input);
        } else if (currentScreen == Screen.Password) {
            CheckPassword(input);
        } else { // if on win screen
            Terminal.WriteLine("Congrats on hacking successfully!");
        }
    }

    void CheckPassword(string input)
    {
        if (level == 1 && input == "books")
        {
            WinGame(level);
        }
        else if (level == 2 && input == "crime")
        {
            WinGame(level);
        }
        else
        {
            Terminal.WriteLine("Wrong password! Try again: ");
        }
    }

    void RunMainMenu(string input) // execute main menu functionality
    {
        if (input == "1")
        {
            level = 1;
            StartGame(level);

        }
        else if (input == "2")
        {
            level = 2;
            StartGame(level);
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level!");
        }
    }

    void StartGame(int level) // execute password functionaltiy
    {
        Terminal.WriteLine("You have chosen level " + level);
        currentScreen = Screen.Password; // password screen after correct level chosen
        Terminal.WriteLine("Please enter your password: ");
    }

    void WinGame(int level) // execute password functionaltiy
    {
        currentScreen = Screen.WinScreen;
        Terminal.WriteLine("You hacked successfully into level " + level + "!");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
