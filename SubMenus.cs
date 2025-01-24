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
        try
        {
            var pokemons = CSVManager.ReadCSV<Pokemon>("pokemons.csv");
            string[] customText = new string[1];

            if (pokemons.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("No Pokemons found.");
                Program.waitforinput();
                return;
            }

            Console.Clear();
            customText[0] = "All Pokemons:\n";

            // Name of submenu
            string name = "See all Pokemons";

            // Options to be displayed
            string[] options = pokemons.Select(p => $"Name: {p.Name} Type: {p.Type} Strength: {p.StrengthLevel}").ToArray();

            // Array of actions to be called
            Action[] cases = { };

            // Build submenu
            Menu.buildSub(name, options, cases, false, customText);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Console.ReadKey();
        }
    }

    public static void SearchPokemon()
    {
        try
        {
            Console.WriteLine("Enter the name of the Pokemon you want to search:");
            string pokename = Console.ReadLine() ?? string.Empty;

            var pokemons = CSVManager.SearchCSV<Pokemon>("pokemons.csv", pokename);
            string[] customText = new string[1];

            if (pokemons.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("No Pokemon found.");
                Program.waitforinput();
                return;
            }

            Console.Clear();
            customText[0] = "Pokemon found:\n";

            // Name of submenu
            string name = "Search Pokemon";

            // Options to be displayed
            string[] options = pokemons.Select(p => $"Name: {p.Name} Type: {p.Type} Strength: {p.StrengthLevel}").ToArray();

            // Array of actions to be called
            Action[] cases = { };

            // Build submenu
            Menu.buildSub(name, options, cases, false, customText);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Console.ReadKey();
        }
    }

    public static void EditPokedex()
    {
        if (!User.isLoggedin())
            return;

        // Name of submenu
        string name = "Edit Pokedex";

        // Options to be displayed
        string[] options = {
                "Add Pokemon",
                "Edit Pokemon",
                "Delete Pokemon",
            };

        // Array of actions to be called
        Action[] cases = {
                () => { PokedexManager.UserAddPokemon(); },
                () => { PokedexManager.UserEditPokemon(); },
                () => { PokedexManager.UserDeletePokemon(); }
            };

        // Build submenu
        Menu.buildSub(name, options, cases);
    }
}