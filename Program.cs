using App;
using System.Collections.Generic;
using System.Runtime.Intrinsics.Arm;
/*
self registration, by user
log in
log out

upload info/description of items
browse other users items

request trade
accept trade requests
deny trade requests
browse completed requests

TODO state change switch case in main loop
counter offers?
value metrics?
multiple items per trade?
*/

// Instantiate dictionary of users
Dictionary<string, IUser> users = User.importUsersFromFile("users.csv");
if (users.Count == 0)
{
    users = new Dictionary<string, IUser>();
}

IUser? active_user = null;

bool running = true;
Program_State state = Program_State.LOGGING_IN;
// intialize member variables
string username = "invalid username";

Console.Clear();
while (running) // Main loop
{
    //Console.Clear();

    switch (state) // state design, object behavior depends on state
    {
        // login status, not logged in
        case Program_State.LOGGING_IN:
            //Console.Clear();
            Console.Write("Username: ");
            username = Console.ReadLine() ?? ""; // null coalesce, produces a string if null

            Console.Clear();

            if (users.TryGetValue(username, out active_user)) // check registration status
            {
                System.Console.Write("Password: ");
                string userPassword = Console.ReadLine() ?? "";
                if (active_user.TryLogin(userPassword)) // check registered users password
                {
                    state = Program_State.LOGGED_IN;  // state update, reflects correct username and password
                    break;
                }
                else
                {
                    System.Console.WriteLine("Invalid username and password combination.\nPress \"r\" to retry your credentials. Otherwise press any key to register a new account.");
                    string userInput = System.Console.ReadLine() ?? "";
                    Console.Clear();
                    if (userInput.ToLower() == "r")  // comparing user input, ToLower converts user input to lowercase
                    {
                        state = Program_State.LOGGING_IN; // state update, restart login
                    }
                    else
                    {
                        state = Program_State.REGISTERING_NewUser; // state update, register new user
                        active_user = null;
                    }
                }
            }
            else
            {
                state = Program_State.REGISTERING_NewUser;
            }
            break;
        case Program_State.REGISTERING_NewUser:
            Console.Clear();
            System.Console.WriteLine($"Welcome Trader!\nPress \"j\" to confirm {username} as your new username. Press any other key to enter a different username.");
            string selfRegistration = System.Console.ReadLine() ?? "";
            Console.Clear();
            if (selfRegistration == "j")
            {
                active_user = new User(username, User.getEmail(), User.getPassword()); // create new active user
                users.Add(username, active_user); // method call user to users.csv
                System.Console.WriteLine($"Welcome new Trader {username}! Your accont information is registered. Don't trade it with anyone!");// var userInputToLower = userInput.ToLower()
                state = Program_State.LOGGED_IN;
            }
            else
            {
                state = Program_State.LOGGING_IN; // loops back to login in state for new username
                Console.Clear();
            }
            break;
        case Program_State.LOGGED_IN:
            System.Console.WriteLine($"Welcome {username}!"); // string interpolation
            System.Console.WriteLine("What would you like to do?\nPress \"a\" to add items\nPress \"t\" to see the trade menu\nPress \"h\" to view your history"+
            "\nType \"logout\" to logout");
            string selection = Console.ReadLine() ?? "";
            switch (selection)
            {
                case "logout":
                    state = Program_State.LOGGING_OUT;
                    break;
            }
            break;
        case Program_State.LOGGING_OUT:
            Console.WriteLine("logged out\nType \"login\" to log back in or \"exit\" to leave the program");
            string input = Console.ReadLine() ?? ""; // null coalesce
            active_user = null;
            switch (input)
            {
                case "exit":
                    running = false;
                    Console.Clear();
                    System.Console.WriteLine("See you next trade!");
                    break;
                case "login":
                    Console.Clear();
                    state = Program_State.LOGGING_IN;
                    System.Console.WriteLine("Logging back in");
                    break;
            }
            break;
    }
}

// state list, constants
enum Program_State
{
    LOGGING_OUT,
    LOGGING_IN,
    LOGGED_IN,
    REGISTERING_NewUser,
    REGISTERING_NewTrade
}