using _01_DatabaseFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _04_ImportLeaguesTeamsFromXml
{
    class ImportLeaguesTeamsFromXml
    {
        static void Main()
        {
            var context = new FootballEntities();

            XmlDocument doc = new XmlDocument();
            doc.Load("../../leagues-and-teams.xml");

            var root = doc.DocumentElement;
            int id = 1;

            foreach (XmlNode xmlLeague in root.ChildNodes)
            {
                Console.WriteLine("Processing league #{0} ...", id++);
                XmlNode leagueNameNode = xmlLeague.SelectSingleNode("league-name");
                League league = null; 

                if (leagueNameNode != null)
                {
                    string leagueName = leagueNameNode.InnerText;

                    league = context.Leagues.FirstOrDefault(l => l.LeagueName == leagueName);
                    if (league != null)
                    {
                        Console.WriteLine("Existing league: {0}", leagueName);
                    }
                    else
                    {
                        league = new League()
                        {
                            LeagueName = leagueName
                        };
                        Console.WriteLine("Created league: {0}", leagueName);
                    }
                }

                XmlNode teamsNode = xmlLeague.SelectSingleNode("teams");

                if (teamsNode != null)
                {
                    foreach (XmlNode xmlTeam in teamsNode.ChildNodes)
                    {
                        Team team = null;
                        string teamName = xmlTeam.Attributes["name"].Value;
                        string countryName = null;

                        if (xmlTeam.Attributes["country"] != null)
                        {
                            countryName = xmlTeam.Attributes["country"].Value;
                        }

                        team = context.Teams.FirstOrDefault(t => t.TeamName == teamName && t.Country.CountryName == countryName);
                        if (team != null)
                        {
                            Console.WriteLine("Existing team: {0} ({1})", teamName, countryName ?? "no country");
                        }
                        else
                        {
                            Country country = context.Countries.FirstOrDefault(c => c.CountryName == countryName);
                            team = new Team()
                            {
                                TeamName = teamName,
                                Country = country
                            };
                            context.Teams.Add(team);
                           
                            Console.WriteLine("Created team: {0} ({1})", teamName, countryName ?? "no country");
                        }

                        if (league != null)
                        {
                            if (league.Teams.Contains(team))
                            {
                                Console.WriteLine("Existing team in league:{0} belongs to {1}", teamName, league.LeagueName);
                            }
                            else
                            {
                                league.Teams.Add(team);
                                Console.WriteLine("Added team to league: {0} to league {1}", teamName, league.LeagueName);
                            }  
                        }
                    }
                }
                context.SaveChanges();
            }
        }
    }
}
