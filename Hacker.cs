using UnityEngine;

public class Hacker : MonoBehaviour
{
    //Game configuration data
    const string menuHint = "You may type menu at anytime.";
    string[] level1Passwords = { "books", "aisle", "shelf", "password", "font", "borrow" };
    string[] level2Passwords = { "handcuffs", "arrest", "bobby", "constable", "sergeant" };
    string[] level3Passwords = { "alwayswatchingyou", "snoopingandspying", "supersecretagent", "octopussy"};

    //Game State
    string username;
    int level;
    string password;
    enum Screen { UserName, MainMenu, Password, Win };
    Screen currentScreen;

    // Start is called before the first frame update
    void Start()
    {
        UserName();
    }
        
    void UserName()
    {
        currentScreen = Screen.UserName;
        Terminal.WriteLine("...");
        Terminal.WriteLine("Hacker scripts loaded.");
        Terminal.WriteLine("Please enter username:");
    }
    
    
    
    void ShowMainMenu(string greeting)
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine(greeting);
        Terminal.WriteLine("");
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("");
        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for the police station");
        Terminal.WriteLine("Press 3 for the NSA");
        Terminal.WriteLine("");
        Terminal.WriteLine("Enter your selection:");
    }

    

    void OnUserInput(string input)
    {
       if(input == "menu" & currentScreen != Screen.UserName) 
        {
            ShowMainMenu("Hello " + username);

        } else if(currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);

        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);

        }
        else if (currentScreen == Screen.UserName)
        {
            username = input;
            ShowMainMenu("Hello " + username);
        }
    }

    
    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();


        } else
        {
            Terminal.WriteLine("");
            Terminal.WriteLine("Haha clever cloggs please choose a level...");
            Terminal.WriteLine(menuHint);
        }
    }

    void CheckPassword(string input)
    {
        if(input== password) {
            WinGame();
        }  else
        {
            AskForPassword();
        }
    }


    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        Terminal.WriteLine("You have chosen level " + level);
        Terminal.WriteLine(menuHint);
        SetRandomPassword();
        Terminal.WriteLine("");
        Terminal.WriteLine("Enter password, hint:" + password.Anagram());


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
            case 3:

                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid Level Number");
                break;
        }
    }

    void WinGame()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menuHint);
    }

    void ShowLevelReward() 
    { 
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Yaaaaay! You have completed level " + level + ".    Have a book..." );
                Terminal.WriteLine(@"
    __________
   /         //
  /         //
 /_________//
(_________(/
");
                break;
            case 2:
                Terminal.WriteLine("Yaaaaay! You have completed level " + level + ".    Have a key...");
                Terminal.WriteLine(@"
 ___
/O  `____________   
`___/-=' = ' -=-'
");
                break;
            case 3:
                Terminal.WriteLine("Yaaaaay! You have completed level " + level + ".    Have a file...");
                Terminal.WriteLine(@"
     ________
    /       /_______________
   /  Area 51 File         /
  /                       /
 /                       /
/_______________________/
");
                break;
            default:
                Debug.LogError("Invalid level reached");
                break;
        }
    }
}
