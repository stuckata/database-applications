using _01_DiabloDatabaseFirst;
using System.IO;
using System.Linq;
using System.Web.Script.Serialization;

namespace _02_ExportCharactersPlayersAsJson
{
    class ExportCharactersPlayersAsJson
    {
        static void Main()
        {
            var context = new DiabloEntities();

            var characters = context.Characters.OrderBy(c => c.Name).Select(c => new
            {
                name = c.Name,
                playedBy = c.UsersGames.Select(ug => ug.User.Username)
            });

            var json = new JavaScriptSerializer().Serialize(characters);

            File.WriteAllText(@"../../characters.json", json);
        }
    }
}
