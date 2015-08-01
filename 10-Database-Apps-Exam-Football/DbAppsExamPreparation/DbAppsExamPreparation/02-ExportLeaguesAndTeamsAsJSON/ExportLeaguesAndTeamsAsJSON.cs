using _01_DatabaseFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace _02_ExportLeaguesAndTeamsAsJSON
{
    class ExportLeaguesAndTeamsAsJSON
    {
        static void Main()
        {
            var context = new FootballEntities();

            var leagues = context.Leagues.Select(l => new
                {
                    leagueName = l.LeagueName,
                    teams = l.Teams.Select(t => t.TeamName)
                }
            );

            var json = new JavaScriptSerializer().Serialize(leagues);

            Console.WriteLine(json);
        }
    }
}
