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
        var users = CSVManager.ReadCSV<User>("users.csv");
        var user = users.FirstOrDefault(u => u.Username == username && u.Password == password);

        if (user != null)
        {
            Program.LoggedIn = true;
            Program.Username = user.Username;
            Console.WriteLine($"Welcome, {user.Username}!");
        }
        else
        {
            Console.WriteLine("Invalid username or password.");
        }
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