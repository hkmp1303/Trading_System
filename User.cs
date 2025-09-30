namespace App;

class User : IUser
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

    // retrieve user data from file
    public static Dictionary<string, IUser> importUsersFromFile(string fileName)
    {
        Dictionary<string, IUser> dicUsers = new Dictionary<string, IUser>();
        string[] lines = File.ReadAllLines(fileName);
        foreach (string userLine in lines)
        {
            string[] user = userLine.Split(':');
            if (user.Length == 3)
            {
                dicUsers.Add(user[0], new User(user[0], user[1], user[2]));
            }
        }
        return dicUsers;
    }
}