namespace ExportUsersGamesFromXml
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Globalization;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.XPath;
    using DiabloDatabaseFirst;

    public class ImportUsersGamesFromXml
    {
        private const string SourceXmlPath = "../../new-users.xml";

        static void Main()
        {
            var xml = XDocument.Load(SourceXmlPath);
            var users = xml.XPathSelectElements("users/user");

            var context = new DiabloEntities();
            foreach (var userNode in users)
            {
                try
                {
                    ImportUsersAndGames(userNode, context);
                }
                catch (Exception ex)
                {
                    if (ex is ValidationException || ex is InvalidOperationException || ex is DataException)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    else
                    {
                        throw;
                    }
                }
            }
        }

        private static void ImportUsersAndGames(XElement userNode, DiabloEntities context)
        {
            var username = userNode.Attribute("username").Value;

            if (GetUserByUsername(username, context) != null)
            {
                throw new InvalidOperationException(string.Format(
                    "User {0} already exists", 
                    username));
            }

            bool isDeleted = int.Parse(userNode.Attribute("is-deleted").Value) == 0;

            var regDate = ParseDate(userNode.Attribute("registration-date").Value);

            var ipAddress = userNode.Attribute("ip-address").Value;

            var user = new User()
            {
                Username = username,
                IsDeleted = isDeleted,
                RegistrationDate = regDate,
                IpAddress = ipAddress
            };

            var firstName = userNode.Attribute("first-name");
            if (firstName != null)
            {
                user.FirstName = firstName.Value;
            }

            var lastName = userNode.Attribute("last-name");
            if (lastName != null)
            {
                user.LastName = lastName.Value;
            }

            var email = userNode.Attribute("email");
            if (email != null)
            {
                user.Email = email.Value;
            }

            context.Users.Add(user);
            Console.WriteLine("Successfully added user {0}", username);

            var games = userNode.XPathSelectElements("games/game");
            foreach (var gameNode in games)
            {
                ImportGame(context, gameNode, user, username);
            }

            context.SaveChanges();
        }

        private static void ImportGame(DiabloEntities context, XElement gameNode, User user, string username)
        {
            var gameName = gameNode.XPathSelectElement("game-name").Value;
            var joinDate = ParseDate(gameNode.XPathSelectElement("joined-on").Value);
            var characterNode = gameNode.XPathSelectElement("character");
            var characterName = characterNode.Attribute("name").Value;
            var cash = decimal.Parse(characterNode.Attribute("cash").Value);
            var level = int.Parse(characterNode.Attribute("level").Value);

            user.UsersGames.Add(new UsersGame()
            {
                Character = GetCharacterByName(characterName, context),
                Game = GetGameByName(gameName, context),
                Level = level,
                JoinedOn = joinDate,
                Cash = cash
            });

            Console.WriteLine("User {0} successfully added to game {1} with character {2}",
                username,
                gameName,
                characterName);
        }

        private static DateTime ParseDate(string datetime)
        {
            return DateTime.ParseExact(
                datetime,
                "dd/MM/yyyy",
                CultureInfo.InvariantCulture);
        }

        private static User GetUserByUsername(string username, DiabloEntities context)
        {
            return context.Users.FirstOrDefault(u => u.Username == username);
        }

        private static Character GetCharacterByName(string name, DiabloEntities context)
        {
            return context.Characters.First(ch => ch.Name == name);
        }

        private static Game GetGameByName(string name, DiabloEntities context)
        {
            return context.Games.First(g => g.Name == name);
        }
    }
}
