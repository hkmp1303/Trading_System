namespace App;

using System.Net.Mail;

class User : IUser // TODO abstract
{
    // class members
    public string Username;
    public string Email;
    string _password; // private field

    // constructor, manual registration
    public User(string username, string email, string password)
    {
        // perserving constructor parameters
        Username = username;
        Email = email;
        _password = password;
    }

    // checking supplied password against registered users
    public bool TryLogin(string password)
    {
        return _password == password;
    }

    // returns dictionary collection from file
    public static Dictionary<string, IUser> importUsersFromFile(string fileName)
    {
        string[] lines = File.ReadAllLines(fileName);   // get lines from file
        Dictionary<string, IUser> dicUsers = new Dictionary<string, IUser>(lines.Length); // creating target dictionary
        foreach (string userLine in lines)              // loop through lines
        {
            string[] user = userLine.Split(':');        // seperate lines based on :
            if (user.Length == 3)                       // excludes invalid lines, vaild users split into three segments
            {
                dicUsers.Add(user[0], new User(user[0], user[1], user[2]));     // add new user to dictionary
            }
        }
        return dicUsers;
    }

    // Adds new users to the file
    public static void exportUsersToFile(Dictionary<string, IUser> dicUsers, string fileName)
    {
        string[] lines = new string[dicUsers.Count]; // initalize new string array
        // TODO loop through lines
        File.WriteAllLines(fileName, lines);
    }

    // retrieve vaild email address from new user
    public static string getEmail()
    {
        while (true)
        {
            System.Console.Write("Enter your email: ");
            string email = System.Console.ReadLine() ?? "";
            email = email.Trim(); // remove blank spaces from user input
            // new MailAddress will fail if invaild email
            try
            {
                MailAddress mail = new MailAddress(email);
                return mail.Address;
            }
            catch
            {
                System.Console.WriteLine("Please enter a vaild email address.");
            }
        }
    }

    // retrieve password from new user
    public static string getPassword()
    {
        while (true)
        {
            System.Console.Write("Enter your password: ");
            string password = System.Console.ReadLine() ?? "";
            System.Console.Write("Confirm your password: ");
            string confrimPassword = System.Console.ReadLine() ?? "";
            // Trim() removes blank space from user input
            password = password.Trim();
            confrimPassword = confrimPassword.Trim();
            if (password != "" && password == confrimPassword)
            {
                return password;
            }
            System.Console.WriteLine("Passwords don't match. Trade them for matching passwords!");
        }
    }
}