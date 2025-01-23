namespace Pokedex;

class Program
{
    public static bool Exit = false;
    public static bool LoggedIn = false;
    public static string dataPath = Path.Combine(Directory.GetCurrentDirectory(), "data/");
    public static string Username { get; set; }

    static void Main(string[] args)
    {
        // Initialize the menu
        Menu.Initialize("Pokedex", true, 7, 7);

        // Main menu
        do
        {
            Console.Clear();
            if (LoggedIn)
            {
                Console.WriteLine($"Hey, {Username}! Welcome to the Pokedex!\n");
            }
            else
            {
                Console.WriteLine("Welcome to the Pokedex!\n");
            }

            // Name of the project
            string Title = "Main Menu";

            // Array of options to be displayed
            string[] options = {
                    LoggedIn ? "Logout" : "Login",
                    "See all Pokemons",
                    "Search Pokemon",
                    "Edit Pokedex",
                };

            // Array of actions to be called
            Action[] cases = {
                    () => { if(LoggedIn) User.Logout(); else SubMenus.Login(); },
                    () => { SubMenus.SeeAllPokemons(); },
                    () => { SubMenus.SearchPokemon(); },
                    () => { SubMenus.EditPokedex(); }
                };

            // Build main menu
            Menu.buildMain(options, cases, Title);

        } while (!Exit);

    }

    public static void waitforinput()
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
}