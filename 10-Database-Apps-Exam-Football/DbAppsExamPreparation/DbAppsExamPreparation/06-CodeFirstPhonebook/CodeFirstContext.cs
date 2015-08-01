using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_CodeFirstPhonebook
{
    class CodeFirstContext
    {
        static void Main()
        {
            var context = new PhonebookContext();

            var people = context.Contacts.Select(c => new
            {
                ContactName = c.Name,
                ContactPhones = c.Phones.Select(p => p.PhoneNumber),
                ContactEmails = c.Emails.Select(e => e.EmailAddress)
            }).ToList();

            foreach (var person in people)
            {
                Console.WriteLine(person.ContactName);
                Console.WriteLine("Phones: " + String.Join(", ", person.ContactPhones));
                Console.WriteLine("Emails: " + String.Join(", ", person.ContactEmails));
            }
        }
    }
}
