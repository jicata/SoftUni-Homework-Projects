namespace ExportCharactersToJson
{
    using System.IO;
    using System.Linq;
    using DiabloDatabaseFirst;
    using Newtonsoft.Json;

    public class ExportCharacters
    {
        static void Main()
        {
            var context = new DiabloEntities();
            var characters = context.Characters
                .OrderBy(ch => ch.Name)
                .Select(ch => new
                {
                    name = ch.Name,
                    playedBy = ch.UsersGames
                        .Select(u => u.User.Username)
                });

            var charactersAsJson = JsonConvert.SerializeObject(characters, Formatting.Indented);
            File.WriteAllText("characters.json", charactersAsJson);
        }
    }
}
