namespace App;

class User : IUser
{
    // class members
    public string Username;
    public string Email;
    string _password; // private field

    // constructor
    public User(string username, string email, string password) 
    {
        // perserving constructor parameters
        Username = username;
        Email = email;
        _password = password;

    }
}