namespace _06_CodeFirstPhonebook.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<_06_CodeFirstPhonebook.PhonebookContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(_06_CodeFirstPhonebook.PhonebookContext context)
        {
            context.Contacts.Add(new Contact()
            {
                Name = "Peter Ivanov",
                Position = "CTO",
                Company = "Smart Ideas",
                Emails = new Email[] {
                    new Email() { EmailAddress = "peter@gmail.com" },
                    new Email() { EmailAddress = "peter_ivanov@yahoo.com" }
                },
                Phones = new Phone[]
                {
                    new Phone() {PhoneNumber = "+359 2 22 22 22" },
                    new Phone() {PhoneNumber = "+359 88 77 88 99" }
                },
                SiteUrl = "http://blog.peter.com",
                Notes = "Friend from school"
            });

            context.Contacts.Add(new Contact()
            {
                Name = "Maria",
                Phones = new Phone[]
                {
                    new Phone() {PhoneNumber = "+359 22 33 44 55" }
                }
            });

            context.Contacts.Add(new Contact()
            {
                Name = "Angie Stanton",
                Emails = new Email[] {
                    new Email() { EmailAddress = "info@angiestanton.com" }
                },
                SiteUrl = "http://angiestanton.com"
            });

            context.SaveChanges();
        }
    }
}
