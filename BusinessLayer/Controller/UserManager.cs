using BusinessLayer.Models;
using static BusinessLayer.Models.User;
using System.Collections.Generic;
using System.Linq;

public static class UserManager
{
    private static List<User> _users = new List<User>();

    public static bool Register(string username, string password)
    {
        if (_users.Any(u => u.Username == username))
        {
            return false;
        }

        _users.Add(new User(username, password));
        return true;
    }

    public static User? Login(string username, string password)
    {
        return _users.FirstOrDefault(u => u.Username == username && u.Password == password);
    }
}
