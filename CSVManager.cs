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
                    values = values.Select(v => v.Trim()).ToArray();

                    var obj = Activator.CreateInstance(typeof(T), values);
                    if (obj != null)
                        data.Add((T)obj);

                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
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
        query = query.ToLower();

        try
        {
            using (var reader = new StreamReader(Path.Combine(Program.dataPath + file)))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    values = values.Select(v => v.Trim()).ToArray();

                    if (values[1].ToLower().Contains(query) || values[2].ToLower().Contains(query))
                    {
                        var obj = Activator.CreateInstance(typeof(T), values);
                        if (obj != null)
                            results.Add((T)obj);
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Console.ReadKey();
        }

        return results;
    }
}