namespace ExportGamesToXml
{
    using System.Linq;
    using System.Xml.Linq;
    using DiabloDatabaseFirst;

    public class ExportGamesToXml
    {
        static void Main()
        {
            var context = new DiabloEntities();
            var games = context.Games
                .Where(g => g.IsFinished)
                .OrderBy(g => g.Name)
                .Select(g => new
                {
                    g.Name,
                    g.Duration,
                    Users = g.UsersGames
                            .Select(ug => new
                            {
                                ug.User.Username,
                                ug.User.IpAddress
                            })
                });

            var doc = new XElement("games");
            foreach (var game in games)
            {
                var gameNode = new XElement("game");
                gameNode.Add(new XAttribute("name", game.Name));

                if (game.Duration.HasValue)
                {
                    gameNode.Add(new XAttribute("duration", game.Duration));
                }

                var usersNode = new XElement("users");
                foreach (var user in game.Users)
                {
                    var singleUserNode = new XElement("user");
                    singleUserNode.Add(new XAttribute("username", user.Username));
                    singleUserNode.Add(new XAttribute("ip-address", user.IpAddress));

                    usersNode.Add(singleUserNode);
                }

                gameNode.Add(usersNode);

                doc.Add(gameNode);
            }

            doc.Save("finished-games.xml");
        }
    }
}
