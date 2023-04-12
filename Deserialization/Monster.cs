using Deserialization;

public class Monster
{
    // represent my JSON keys
    public string Name {get;set;} = string.Empty;
    public string Alignment {get;set;} = string.Empty;
    public int Strength {get;set;}
    public int Dexterity {get;set;}
    public int Constitution {get;set;}
    public int Intelligence {get;set;}
    public int Wisdom {get;set;}
    public int Charisma {get;set;}
    public List<MonsterAction> Actions { get; set; } = new List<MonsterAction>();


    public override string ToString()
    {
        string monsterString =
        $"-------------------------------------\n" +
        $"{Name} - {Alignment}\n" +
        $"-------------------------------------\n" +
        $"Strength: {Strength}\n" +
        $"Dexterity: {Dexterity}\n" +
        $"Constitution: {Constitution}\n" +
        $"Intelligence: {Intelligence}\n" +
        $"Wisdom: {Wisdom}\n" +
        $"Charisma: {Charisma}\n";
        monsterString += "Action(s): ";
        foreach(var a in Actions)
        {
            monsterString += (Actions.IndexOf(a) == Actions.Count - 1)
                ? $"{a.Name}" : $"{a.Name}, ";
        }
        return monsterString;
    }
}