namespace Pokedex;

class CSVManager
{
    public static void WriteCSV<T>(string file, List<T> data)
    {
        try
        {
            using (var writer = new StreamWriter(Path.Combine(Program.dataPath + file)))
            {
                foreach (var obj in data)
                {
                    writer.WriteLine(ParseToCSV(obj));
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found.");
        }
    }

    public static List<T> ReadCSV<T>(string file)
    {
        List<T> data = new List<T>();
        try
        {
            using (var reader = new StreamReader(Path.Combine(Program.dataPath + file)))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    for (int i = 0; i < values.Length; i++)
                    {
                        values[i] = values[i].Trim();
                    }

                    var obj = Activator.CreateInstance(typeof(T), values);
                    data.Add((T)obj);
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found.");
        }
        return data;
    }

    public static string ParseToCSV<T>(T obj)
    {
        try
        {
            var properties = typeof(T).GetProperties();
            var values = properties.Select(p => p.GetValue(obj)?.ToString());
            return string.Join(",", values);
        }
        catch (Exception)
        {
            return string.Empty;
        }
    }

    public static List<T> SearchCSV<T>(string file, string query)
    {
        List<T> results = new List<T>();

        try
        {
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
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found.");
        }
        return results;
    }
}