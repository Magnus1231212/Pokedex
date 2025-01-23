namespace Pokedex;

class Program
{
    public static string dataPath = Path.Combine(Directory.GetCurrentDirectory(), "data");
    public static string Username { get; set; }

    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}

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
        // Check if username and password are correct
    }
}

class Pokemon
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public int StrengthLevel { get; set; }

    public Pokemon(int id, string name, string type, int strengthLevel)
    {
        ID = id;
        Name = name;
        Type = type;
        StrengthLevel = strengthLevel;
    }
}

class PokedexManager
{

}

class CSVManager
{
    public static void WriteCSV<T>(string file, List<T> data)
    {
        using (var writer = new StreamWriter(Path.Combine(Program.dataPath + file)))
        {
            foreach (var obj in data)
            {
                writer.WriteLine(ParseToCSV(obj));
            }
        }
    }

    public static List<T> ReadCSV<T>(string file)
    {
        List<T> data = new List<T>();

        using (var reader = new StreamReader(Path.Combine(Program.dataPath + file)))
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                var obj = Activator.CreateInstance(typeof(T), values);
                data.Add((T)obj);
            }
        }

        return data;
    }

    public static string ParseToCSV<T>(T obj)
    {
        var properties = typeof(T).GetProperties();
        var values = properties.Select(p => p.GetValue(obj)?.ToString());
        return string.Join(",", values);
    }

    public static List<T> SearchCSV<T>(string file, string query)
    {
        List<T> results = new List<T>();

        using (var reader = new StreamReader(Path.Combine(Program.dataPath + file)))
        {
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                if (values.Contains(query))
                {
                    var obj = Activator.CreateInstance(typeof(T), values);
                    results.Add((T)obj);
                }
            }
        }
        return results;
    }
}