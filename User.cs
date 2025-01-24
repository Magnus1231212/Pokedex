using System.Security.Cryptography;
using System.Text;

namespace Pokedex;

class User
{
    public string Username { get; set; }
    public string Password { get; set; }

    public User(string username, string password)
    {
        Username = username;
        Password = password;
    }

    public static void Login(string username, string password)
    {
        List<User> users = CSVManager.ReadCSV<User>("users.csv");
        var user = users.FirstOrDefault(u => u.Username == username && u.Password == password);

        if (user != null)
        {
            Program.LoggedIn = true;
            Program.Username = user.Username;
            Console.WriteLine($"Welcome, {user.Username}!");
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Invalid username or password.");
        }
    }

    public static void register(string username, string password)
    {
        List<User> users = CSVManager.ReadCSV<User>("users.csv");
        var user = users.FirstOrDefault(u => u.Username == username);

        if (user != null)
        {
            Console.WriteLine("Username already exists.");
            return;
        }

        users.Add(new User(username, HashPassword(password)));
        CSVManager.WriteCSV("users.csv", users);
        Console.WriteLine("User registered successfully.");
    }

    public static void Logout()
    {
        Program.LoggedIn = false;
        Program.Username = string.Empty;
    }

    public static bool isLoggedin()
    {
        if (!Program.LoggedIn)
        {
            Console.WriteLine("You must be logged in to access this feature.");
            Program.waitforinput();
            return false;
        }
        return true;
    }

    public static string HashPassword(string password)
    {
        using (var sha256 = SHA256.Create())
        {
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedBytes);
        }
    }
}