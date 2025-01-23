namespace Pokedex;

class Program
{
    public static bool Exit = false;
    public static bool LoggedIn = false;
    public static string dataPath = Path.Combine(Directory.GetCurrentDirectory(), "data");
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
                    "Login",
                    "See all Pokemons",
                    "Search Pokemon",
                    "Edit Pokedex",
                };

            // Array of actions to be called
            Action[] cases = {
                    () => { Console.WriteLine("Option 1"); },
                    () => { Console.WriteLine("Option 2"); },
                };

            // Build main menu
            Menu.buildMain(options, cases, Title);

        } while (!Exit);

    }
}