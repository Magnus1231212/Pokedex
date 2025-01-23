namespace Pokedex;

class SubMenus
{
    public static void Login()
    {
        Console.WriteLine("Enter your username:");
        string username = Console.ReadLine() ?? string.Empty;

        Console.WriteLine("Enter your password:");
        string password = Console.ReadLine() ?? string.Empty;

        User.Login(username, User.HashPassword(password));
    }
}