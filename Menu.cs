namespace Pokedex;

internal class Menu
{
    private static string ProjectTitle = "";
    private static int MaxOptions;
    private static int MaxSubOptions;
    private static int Page = 1;
    private static bool LoopToFirstPage = false;

    // Menu Builder Initializer
    public static void Initialize(string title, bool _LoopToFirstPage, int _MaxOptions = 7, int _MaxSubOptions = 7)
    {
        ProjectTitle = title;
        MaxOptions = _MaxOptions;
        MaxSubOptions = _MaxSubOptions;
        LoopToFirstPage = _LoopToFirstPage;
    }

    // Main Menu Builder
    public static void buildMain(string[] Options, Action[] Cases, string Title)
    {
        int choice = -1;
        do
        {
            Console.Title = $"{ProjectTitle} - {Title}";

            Console.WriteLine("Please select an option: \n");

            int index = 0;
            foreach (string Option in GetPage(Options, Page, 0))
            {
                index++;
                Console.WriteLine($"\t{index}. {Option}");
            }

            if (Options.Length > MaxOptions)
            {
                Console.WriteLine($"\n\t{MaxOptions + 1}. Next Page");
            }

            if (Page > 1)
            {
                Console.WriteLine($"\t{MaxOptions + 2}. Previous Page");
            }

            Console.WriteLine("\n\t0. Exit");

            Console.Write("\nChoice: ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                choice = -1;
            }

            if (choice >= 1 && choice <= MaxOptions && choice <= Options.Length)
            {
                try
                {
                    ResetPage();
                    Console.Clear();
                    Cases[choice - 1]();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                break;
            }
            else if (choice == (MaxOptions + 1))
            {
                if (Options.Length > MaxOptions * Page)
                {
                    Page++;
                }
                else if (LoopToFirstPage)
                {
                    ResetPage();
                }
            }
            else if (choice == (MaxOptions + 2))
            {
                if (Page > 1)
                {
                    Page--;
                }
            }
            else if (choice == 0)
            {
                Program.Exit = true;
                break;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Please enter a valid number!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }

        } while (choice != 0);
    }

    // Sub Menu Builder
    public static void buildSub(string Title, string[] Options, Action[] Cases, bool enableSelection = true)
    {
        int choice = -1;
        do
        {
            Console.Title = $"{ProjectTitle} - {Title}";

            Console.Clear();

            if (enableSelection)
                Console.WriteLine("Please select an option: \n");

            int index = 0;
            foreach (string Option in GetPage(Options, Page, 1))
            {
                index++;
                Console.WriteLine($"\t{index}. {Option}");
            }

            if (Options.Length > MaxSubOptions)
            {
                Console.WriteLine($"\n\t{MaxSubOptions + 1}. Next Page");
            }

            if (Page > 1)
            {
                Console.WriteLine($"\t{MaxSubOptions + 2}. Previous Page");
            }

            Console.WriteLine("\n\t0. Go Back");

            Console.Write("\nChoice: ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                choice = -1;
            }

            if (choice >= 1 && choice <= MaxSubOptions && choice <= Options.Length && enableSelection)
            {
                Console.Clear();
                try
                {
                    ResetPage();
                    Console.Clear();
                    Cases[choice - 1]();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
            else if (choice == (MaxSubOptions + 1))
            {
                if (Options.Length > MaxSubOptions * Page)
                {
                    Page++;
                }
                else if (LoopToFirstPage)
                {
                    ResetPage();
                }
            }
            else if (choice == (MaxSubOptions + 2))
            {
                if (Page > 1)
                {
                    Page--;
                }
            }
            else if (choice == 0)
            {
                break;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Please enter a valid number!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }

        } while (choice != 0);
    }

    // Get Page | 0 = Main Menu, 1 = Sub Menu
    public static Array GetPage<T>(T[] list, int page, int type)
    {
        if (type == 0)
            return list.Skip((page - 1) * MaxOptions).Take(MaxOptions).ToArray();
        else
            return list.Skip((page - 1) * MaxSubOptions).Take(MaxSubOptions).ToArray();
    }

    public static void ResetPage()
    {
        Page = 1;
    }
}