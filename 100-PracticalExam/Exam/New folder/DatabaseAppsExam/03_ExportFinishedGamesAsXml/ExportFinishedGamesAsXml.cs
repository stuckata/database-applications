using _01_DiabloDatabaseFirst;
using System.Linq;
using System.Xml.Linq;

namespace _03_ExportFinishedGamesAsXml
{
    class ExportFinishedGamesAsXml
    {
        static void Main()
        {
            var context = new DiabloEntities();

            var finishedGames = context.Games.Where(g => g.IsFinished).OrderBy(g => g.Name).Select(g => new
            {
                Name = g.Name,
                Duration = g.Duration,
                Usernames = g.UsersGames.Select(ug => ug.User.Username),
                IpAddresses = g.UsersGames.Select(ug => ug.User.IpAddress)
            });

            XElement games = new XElement("games");

            foreach (var game in finishedGames)
            {
                XElement users = new XElement("users");
                XElement xmlGame =
                   new XElement("game", 
                        new XAttribute("name", game.Name)
                   );

                if (game.Duration != null)
                {
                    xmlGame.Add(new XAttribute("duration", game.Duration));
                }

                for (int i = 0; i < game.Usernames.Count(); i++)
                {
                    XElement xmlUser = new XElement("user",
                        new XAttribute("username", game.Usernames.ElementAt(i)),
                        new XAttribute("ip-address", game.IpAddresses.ElementAt(i))
                    );
                    xmlGame.Add(xmlUser);
                }

                games.Add(xmlGame);
            }
            games.Save("../../finished-games.xml");
        }
    }
}
