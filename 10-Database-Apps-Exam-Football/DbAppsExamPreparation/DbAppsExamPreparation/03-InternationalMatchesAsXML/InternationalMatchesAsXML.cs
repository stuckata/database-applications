using _01_DatabaseFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _03_InternationalMatchesAsXML
{
    class InternationalMatchesAsXML
    {
        static void Main()
        {
            var context = new FootballEntities();

            var internationalMatches = 
                context.InternationalMatches
                    .OrderBy(im => im.MatchDate)
                    .ThenBy(im => im.CountryHome.CountryName)
                    .ThenBy(im => im.CountryAway.CountryName)
                    .Select(im => new
                    {
                        HomeScore = im.HomeGoals,
                        AwayScore = im.AwayGoals,
                        HomeCountryCode = im.HomeCountryCode,
                        AwayCountryCode = im.AwayCountryCode,
                        Date = im.MatchDate,
                        HomeCountryName = im.CountryHome.CountryName,
                        AwayCountryName = im.CountryAway.CountryName,
                        LeagueName = im.League.LeagueName
                    }
                ).ToList();

            XElement matches = new XElement("matches");

            foreach (var match in internationalMatches)
            {
                XElement xmlMatch =
                    new XElement("match",
                        new XElement("home-country",
                            new XAttribute("code", match.HomeCountryCode),
                            match.HomeCountryName
                        ),
                        new XElement("away-country",
                            new XAttribute("code", match.AwayCountryCode),
                            match.AwayCountryName
                        )
                );

                if (match.LeagueName != null)
                {
                    xmlMatch.Add(new XElement("league", match.LeagueName));
                }

                if (match.HomeScore != null && match.AwayScore != null)
                {
                    xmlMatch.Add(new XElement("score", match.HomeScore + "-" + match.AwayScore));
                }

                if (match.Date != null)
                {
                    DateTime date = new DateTime();
                    DateTime.TryParse(match.Date.ToString(), out date);
                    if (date.Hour != 0)
                    {
                        xmlMatch.Add(new XAttribute("date-time", date.ToString("dd-MMM-yyyy hh:mm")));
                    } else
                    {
                        xmlMatch.Add(new XAttribute("date", date.ToString("dd-MMM-yyyy")));
                    }
                }

                matches.Add(xmlMatch);
            }

            matches.Save("../../international-matches.xml");
        }
    }
}
