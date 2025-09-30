using App;
using System.Collections.Generic;

// self registration, by user
// log in 
// log out
// upload info/description of items
// browse other users items
// request trade
// accept trade requests
// deny trade requests
// browse completed requests

// TODO state change switch case in main loop

// counter offers?
// value metrics?
// multiple items per trade?

// Instantiate dictionary of users
Dictionary<string, IUser> users = User.importUsersFromFile("users.csv");
if (users.Count == 0)
{
    users = new Dictionary<string, IUser>();
}

IUser? active_user = null;

bool running = true;

while (running) // Main loop
{
    Console.Clear();

    if (active_user == null) // login status, not logged in
    {
        Console.Clear();
        Console.WriteLine("Username: ");
        string username = Console.ReadLine();

        Console.Clear();

        if (users.ContainsKey(username)) // check registration status
        {
            System.Console.WriteLine($"Welcome back {username}!"); // string interpolation
            string userPassword = Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Do you want to create a new account with this user name?");
            System.Console.ReadLine();
        }
            Console.Clear();
    }
    else
    {


    }

    Console.WriteLine("logout");
    string input = Console.ReadLine();
    switch(input)
    {
        case "logout":
            active_user = null;
            break;
    }
}