using _01_DiabloDatabaseFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _04_ImportUsersGamesFromXml
{
    class ImportUsersGamesFromXml
    {
        static void Main()
        {
            var context = new DiabloEntities();

            XmlDocument doc = new XmlDocument();
            doc.Load("../../users-and-games.xml");

            var root = doc.DocumentElement;

            foreach (XmlNode xmlUser in root.ChildNodes)
            {
                XmlNode userNode = xmlUser.SelectSingleNode("user");
                User user = null;
                string gameName = null;
                Character character = null;

                foreach (XmlAttribute xmlUserAttributes in userNode)
                {
                    string firstName = xmlUserAttributes.Attributes["first-name"].Value;
                    string lastName = xmlUserAttributes.Attributes["last-name"].Value;
                    string username = xmlUserAttributes.Attributes["username"].Value;
                    string email = xmlUserAttributes.Attributes["email"].Value;
                    Boolean isDeleted = Boolean.Parse(xmlUserAttributes.Attributes["is-deleted"].Value);
                    string ipAddress = xmlUserAttributes.Attributes["ip-address"].Value;
                    DateTime registrationDate = DateTime.Parse(xmlUserAttributes.Attributes["registration-date"].Value);
                    

                    if (username != null && isDeleted != true && ipAddress != null && registrationDate != null)
                    {
                        User currentUser = null;
                        currentUser = context.Users.FirstOrDefault(u => u.Username == username && u.RegistrationDate == registrationDate);

                        if (currentUser != null)
                        {
                            Console.WriteLine("User {0} already exists", username);
                        }
                        else
                        {
                            user = new User()
                            {
                                FirstName = firstName,
                                LastName = lastName,
                                Username = username,
                                Email = email,
                                IsDeleted = isDeleted,
                                IpAddress = ipAddress,
                                RegistrationDate = registrationDate
                            };
                        }
                    }
                }

                foreach (XmlNode xmlGame in userNode.ChildNodes)
                {
                    XmlNode gameNode = xmlGame.SelectSingleNode("game");
                    gameName = gameNode.SelectSingleNode("game-name").Value;
                    XmlNode characterNode = gameNode.SelectSingleNode("character");
                    string characterName = null;
                    decimal cash = 0;
                    int level = 0;

                    foreach (XmlAttribute xmlCharacter in characterNode)
                    {
                        characterName = xmlCharacter.Attributes["name"].Value;
                        cash = decimal.Parse(xmlCharacter.Attributes["name"].Value);
                        level = int.Parse(xmlCharacter.Attributes["name"].Value);
                    }

                    Character currentCharacter = null;
                    currentCharacter = context.Characters.FirstOrDefault(c => c.Name == characterName);

                    if (currentCharacter == null)
                    {
                        character = new Character()
                        {
                            Name = characterName,
                            Statistic = new Statistic() { }
                        };
                    }
                }
            }
        }
    }
}
