namespace Pokedex;

class PokedexManager
{
    public static void UserAddPokemon()
    {
        Console.Clear();
        Console.WriteLine("Add a new Pokemon\n");

        Console.Write("ID: ");
        string id = Console.ReadLine() ?? string.Empty;

        Console.Write("Name: ");
        string name = Console.ReadLine() ?? string.Empty;

        Console.Write("Type: ");
        string type = Console.ReadLine() ?? string.Empty;

        Console.Write("Strength Level: ");
        string strengthLevel = Console.ReadLine() ?? string.Empty;

        if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(type) || string.IsNullOrEmpty(strengthLevel))
        {
            Console.WriteLine("Please fill in all fields.");
            return;
        }

        Pokemon pokemon = new Pokemon(id, name, type, strengthLevel);

        try
        {
            AddPokemon(pokemon);
            Console.WriteLine("Pokemon added successfully.");
        }
        catch (Exception)
        {
            Console.WriteLine("Failed to add Pokemon.");
        }
    }

    public static void AddPokemon(Pokemon pokemon)
    {
        var pokemons = CSVManager.ReadCSV<Pokemon>("pokemons.csv");

        pokemons.Add(pokemon);

        CSVManager.WriteCSV("pokemons.csv", pokemons);
    }

    public static void UserDeletePokemon()
    {
        Console.Clear();
        Console.WriteLine("Delete a Pokemon\n");

        Console.Write("ID: ");
        int.TryParse(Console.ReadLine(), out int id);

        try
        {
            DeletePokemon(id);
            Console.WriteLine("Pokemon deleted successfully.");
        }
        catch (Exception)
        {
            Console.WriteLine("Failed to delete Pokemon.");
        }
    }

    public static void DeletePokemon(int id)
    {
        var pokemons = CSVManager.ReadCSV<Pokemon>("pokemons.csv");

        pokemons.RemoveAll(p => p.ID == id);

        CSVManager.WriteCSV("pokemons.csv", pokemons);
    }

    public static void DeletePokemon(string name)
    {
        var pokemons = CSVManager.ReadCSV<Pokemon>("pokemons.csv");

        pokemons.RemoveAll(p => p.Name == name);

        CSVManager.WriteCSV("pokemons.csv", pokemons);
    }

    public static void UserEditPokemon()
    {
        Console.Clear();

        Console.Write("Enter the ID of the Pokemon to edit: ");
        string sID = Console.ReadLine() ?? string.Empty;

        var pokemons = CSVManager.SearchCSV<Pokemon>("pokemons.csv", sID);

        if (pokemons.Count == 0)
        {
            Console.WriteLine("Pokemon not found.");
            return;
        }

        Console.Clear();
        Console.WriteLine("Edit a Pokemon\n");

        Console.Write("New ID: ");
        string id = Console.ReadLine() ?? string.Empty;

        Console.Write("New Name: ");
        string name = Console.ReadLine() ?? string.Empty;

        Console.Write("New Type: ");
        string type = Console.ReadLine() ?? string.Empty;

        Console.Write("New Strength Level: ");
        string strengthLevel = Console.ReadLine() ?? string.Empty;

        if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(type) || string.IsNullOrEmpty(strengthLevel))
        {
            Console.WriteLine("Please fill in all fields.");
            return;
        }

        Pokemon pokemon = new Pokemon(id, name, type, strengthLevel);

        try
        {
            int.TryParse(sID, out int eID);
            EditPokemon(eID, pokemon);
            Console.WriteLine("Pokemon edited successfully.");
        }
        catch (Exception)
        {
            Console.WriteLine("Failed to edit Pokemon.");
        }
    }

    public static void EditPokemon(int id, Pokemon pokemon)
    {
        var pokemons = CSVManager.ReadCSV<Pokemon>("pokemons.csv");

        var index = pokemons.FindIndex(p => p.ID == id);

        if (index != -1)
        {
            pokemons[index] = pokemon;
        }

        CSVManager.WriteCSV("pokemons.csv", pokemons);
    }

    public static void EditPokemon(string name, Pokemon pokemon)
    {
        var pokemons = CSVManager.ReadCSV<Pokemon>("pokemons.csv");

        var index = pokemons.FindIndex(p => p.Name == name);

        if (index != -1)
        {
            pokemons[index] = pokemon;
        }

        CSVManager.WriteCSV("pokemons.csv", pokemons);
    }
}