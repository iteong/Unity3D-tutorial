﻿using UnityEngine;

public class Hacker : MonoBehaviour {

    // GAME CONFIGURATION DATA
    const string menuHint = "Type menu at any time";
    string[] level1Passwords = { "books", "borrow", "librarian", "self", "aisle"};
    string[] level2Passwords = { "crime", "gun", "baton", "handcuffs", "holster", "arrest" };

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
        bool isValidLevelNumber = (input == "1" || input == "2"); // boolean to check if level number is valid
        if (isValidLevelNumber) {
            level = int.Parse(input);
            AskForPassword();
        } else {
            level = 0;
            Terminal.WriteLine("Please choose a valid level!");
        }
    }

    void AskForPassword() // execute password functionaltiy
    {
        currentScreen = Screen.Password; // password screen after correct level chosen
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Please enter your password, hint: " + password.Anagram());
        Terminal.WriteLine(menuHint);
    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid level number!"); // should never get here with isValidLevelNumber
                break;
        }
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
        Terminal.ClearScreen();
        Terminal.WriteLine(menuHint);
        ShowLevelReward();
    }

    void ShowLevelReward()
    {
        switch(level) {
            case 1:
                Terminal.WriteLine("You won a book!");
                Terminal.WriteLine(@"
    ________
   /      //
  /      //
 /______//
(______(/                
");
                break;
            case 2:
                Terminal.WriteLine("You won a gun!");
                Terminal.WriteLine(@"
    ____________
   /       /____//
  / ___________//
 / //-/
(_//               
");
                break;
            default:
                Debug.LogError("Invalid level reached");
                break;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
