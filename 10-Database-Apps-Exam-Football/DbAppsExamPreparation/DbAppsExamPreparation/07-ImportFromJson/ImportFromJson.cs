using _06_CodeFirstPhonebook;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace _07_ImportFromJson
{
    class ImportFromJson
    {
        static void Main()
        {
            var context = new PhonebookContext();
            string text = System.IO.File.ReadAllText("../../contacts.json");

            JArray contacts = JArray.Parse(text);

            foreach (JToken contact in contacts)
            {
                Contact dbContact = new Contact();

                if (contact["name"] == null)
                {
                    Console.WriteLine("Error: Name is required");
                    continue;
                }

                dbContact.Name = contact["name"].ToString();

                if(contact["phone"] != null)
                {
                    foreach (var phone in contact["phone"])
                    {
                        dbContact.Phones.Add(new Phone()
                        {
                            PhoneNumber = phone.ToString()
                        });
                    }
                }

                if (contact["email"] != null)
                {
                    foreach (var email in contact["email"])
                    {
                        dbContact.Emails.Add(new Email()
                        {
                            EmailAddress = email.ToString()
                        });
                    }
                }

                if (contact["company"] != null)
                {
                    dbContact.Company = contact["company"].ToString();
                }

                if (contact["notes"] != null)
                {
                    dbContact.Notes = contact["notes"].ToString();
                }

                if (contact["position"] != null)
                {
                    dbContact.Position = contact["position"].ToString();
                }

                if (contact["siteUrl"] != null)
                {
                    dbContact.SiteUrl = contact["siteUrl"].ToString();
                }

                context.Contacts.Add(dbContact);
                context.SaveChanges();

                Console.WriteLine("Contact {0} imported", dbContact.Name);
            }
        }
    }
}
