using Pokedex.Enums;

namespace Pokedex;

class Pokemon
{
    public int ID { get; set; }
    public string Name { get; set; }
    public PokemonType Type { get; set; }
    public int StrengthLevel { get; set; }

    public Pokemon(string id, string name, string type, string strengthLevel)
    {
        var _id = 0;
        var _strengthLevel = 0;
        int.TryParse(id, out _id);
        int.TryParse(strengthLevel, out _strengthLevel);

        ID = _id;
        Name = name;
        Type = (PokemonType)Enum.Parse(typeof(PokemonType), type ?? string.Empty);
        StrengthLevel = _strengthLevel;
    }
}

