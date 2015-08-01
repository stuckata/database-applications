using _01_DatabaseFirst;
using System.IO;
using System.Linq;
using System.Web.Script.Serialization;

namespace _02_ExportLeaguesAndTeamsAsJSON
{
    class ExportLeaguesAndTeamsAsJSON
    {
        static void Main()
        {
            var context = new FootballEntities();

            var leagues = context.Leagues.OrderBy(l => l.LeagueName).Select(l => new
                {
                    leagueName = l.LeagueName,
                    teams = l.Teams.OrderBy(t => t.TeamName).Select(t => t.TeamName)
                }
            );

            var json = new JavaScriptSerializer().Serialize(leagues);

            File.WriteAllText(@"../../leagues-and-teams.json", json);
        }
    }
}
