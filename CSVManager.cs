namespace Pokedex;

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