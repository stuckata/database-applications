using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_DatabaseFirst
{
    class DatabaseFirst
    {
        static void Main()
        {
            var context = new FootballEntities();

            var teamNames = context.Teams.Select(t => t.TeamName);

            foreach (var name in teamNames)
            {
                Console.WriteLine(name);
            }
        }
    }
}
