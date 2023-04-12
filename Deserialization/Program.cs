using System.Text.Json;
using Newtonsoft.Json;
using ConsoleTables;

//////////////////////////////////////////////////////////////////////////
// 1. Send a request to https://www.dnd5eapi.co/api/monsters/{names}
// 2. Get the responses and deserialize them into Monster objects, adding them to a lis
// 3. Display the monster list
/////////////////////////////////////////////////////////////////////////
var bestiary = await ReadFromAPINewtonSoft();
foreach(var m in bestiary) Console.WriteLine(m);

// Showing all abilities for each monster in the bestiary using the
// ConsoleTables package
var table = new ConsoleTable("Ability Name", "Description");
foreach(var m in bestiary)
{
    foreach(var a in m.Actions)
    {
        table.AddRow(a.Name, (a.Desc.Substring(0,50)) + "...");
    }
}
table.Write();

// Reading monster from a .json file ('dryad.json')
Console.WriteLine(ReadFromFile());


static async Task<List<Monster>> ReadFromAPIJsonSerializer()
{   
    List<Monster> bestiary = new List<Monster>();
    var monsterNames = new string[]{"chimera", "bugbear", "dryad", "gargoyle"};
    HttpClient client = new HttpClient();

    foreach(var name in monsterNames)
    {
        HttpResponseMessage response = await client.GetAsync
            ($"https://www.dnd5eapi.co/api/monsters/{name}");
        string json = await response.Content.ReadAsStringAsync();

        var options = new JsonSerializerOptions(){PropertyNameCaseInsensitive = true};
        var m = System.Text.Json.JsonSerializer.Deserialize<Monster>(json, options);
        bestiary.Add(m); 
    }
    return bestiary;
}

static async Task<List<Monster>> ReadFromAPINewtonSoft()
{
    List<Monster> bestiary = new List<Monster>();
    var monsterNames = new string[] { "chimera", "bugbear", "dryad", "gargoyle" };
    HttpClient client = new HttpClient();

    foreach (var name in monsterNames)
    {
        HttpResponseMessage response = await client.GetAsync
            ($"https://www.dnd5eapi.co/api/monsters/{name}");
        string json = await response.Content.ReadAsStringAsync();

        var m = JsonConvert.DeserializeObject<Monster>(json);
        bestiary.Add(m);
    }
    return bestiary;
}

static Monster ReadFromFile()
{
    var filePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString() + Path.DirectorySeparatorChar + "dryad.json";

    string json = File.ReadAllText(filePath);
    var monster = JsonConvert.DeserializeObject<Monster>(json);
    return monster;
}