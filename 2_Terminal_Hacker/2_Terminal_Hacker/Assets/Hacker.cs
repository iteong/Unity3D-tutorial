using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {

    // GAME CONFIGURATION DATA
    string[] level1Passwords = { "books", "borrow", "librarian"};
    string[] level2Passwords = { "crime", "gun", "baton" };

    // GAME STATES (member variables available everywhere to store states)
    int level;

    enum Screen {MainMenu, Password, WinScreen} // new variable type to store state using enum type (Finite state machines)
    Screen currentScreen;

    string password;

    // Use this for initialization
    void Start () {
        print("Console initialised!");

        var greeting = "Welcome to Ivan's World!";
        ShowMainMenu(greeting);
    }

    void ShowMainMenu (string greeting) {
        currentScreen = Screen.MainMenu; // set screen to main menu so won't think it is on other screens
        level = 0;
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

    void RunMainMenu(string input) // execute main menu functionality
    {
        if (input == "1")
        {
            level = 1;
            password = level1Passwords[2]; // TODO make random later
            StartGame(level);

        }
        else if (input == "2")
        {
            level = 2;
            password = level1Passwords[0];
            StartGame(level);
        }
        else
        {
            level = 0;
            Terminal.WriteLine("Please choose a valid level!");
        }
    }

    void StartGame(int level) // execute password functionaltiy
    {
        Terminal.WriteLine("You have chosen level " + level);
        currentScreen = Screen.Password; // password screen after correct level chosen
        Terminal.WriteLine("Please enter your password: ");
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            WinGame();
        } else {
            Terminal.WriteLine("Wrong password! Try again: ");
        }
    }

    void WinGame() // execute password functionaltiy
    {
        currentScreen = Screen.WinScreen;
        Terminal.WriteLine("You hacked successfully!");
        Terminal.WriteLine("Reset game by typing menu");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
