using System;
using System.Linq;

namespace _01_DiabloDatabaseFirst
{
    class DiabloDatabaseFirst
    {
        static void Main()
        {
            var context = new DiabloEntities();

            var playerNames = context.Users.Select(u => new
            {
               Name = u.FirstName + " " + u.LastName
            });

            foreach (var player in playerNames)
            {
                Console.WriteLine("Name: {0}", player.Name);
            }
        }
    }
}
