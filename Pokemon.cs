namespace Pokedex;

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

