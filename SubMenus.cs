namespace Pokedex;

class SubMenus
{
    public static void Login()
    {
        Console.Clear();
        Console.WriteLine("Enter your username:");
        string username = Console.ReadLine() ?? string.Empty;

        Console.WriteLine("Enter your password:");
        string password = Console.ReadLine() ?? string.Empty;

        User.Login(username, User.HashPassword(password));

        Program.waitforinput();
    }

    public static void SeeAllPokemons()
    {
        var pokemons = CSVManager.ReadCSV<Pokemon>("pokemons.csv");

        // Name of submenu
        string name = "Actions 1";

        // Options to be displayed
        string[] options = pokemons.Select(p => $"Name: {p.Name} ").ToArray();

        // Array of actions to be called
        Action[] cases = { };

        // Build submenu
        Menu.buildSub(name, options, cases, false);
    }

    public static void SearchPokemon()
    {
        Console.WriteLine("Enter the name of the Pokemon you want to search:");
        string pokename = Console.ReadLine() ?? string.Empty;

        var pokemons = CSVManager.SearchCSV<Pokemon>("pokemons.csv", pokename);

        // Name of submenu
        string name = "Search Pokemon";

        // Options to be displayed
        string[] options = pokemons.Select(p => $"Name: {p.Name} ").ToArray();

        // Array of actions to be called
        Action[] cases = { };

        // Build submenu
        Menu.buildSub(name, options, cases, false);
    }

    public static void EditPokedex()
    {
        if (!User.isLoggedin())
            return;

        Console.WriteLine("Enter the name of the Pokemon you want to edit:");
        string pokename = Console.ReadLine() ?? string.Empty;

        var pokemons = CSVManager.SearchCSV<Pokemon>("pokemons.csv", pokename);

        if (pokemons.Count == 0)
        {
            Console.WriteLine("Pokemon not found.");
            return;
        }

        Console.WriteLine("Enter the new name of the Pokemon:");
        string newname = Console.ReadLine() ?? string.Empty;

        Console.WriteLine("Enter the new type of the Pokemon:");
        string newtype = Console.ReadLine() ?? string.Empty;

        var pokemon = pokemons.First();
        pokemon.Name = newname;
        pokemon.Type = newtype;

        CSVManager.WriteCSV("pokemons.csv", pokemons);
    }
}