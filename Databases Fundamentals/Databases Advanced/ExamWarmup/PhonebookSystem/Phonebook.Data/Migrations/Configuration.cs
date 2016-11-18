namespace Phonebook.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Phonebook.Data.PhonebookContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Phonebook.Data.PhonebookContext context)
        {
            Contact con1 = new Contact()
            {
                Name = "Peter Ivanov",
                Position = "CTO",
                Company = "Smart Ideas",
                Emails = new HashSet<Email>()
                {
                    new Email() {EmailAdress = "peter@gmail.com"},
                    new Email() {EmailAdress = "peter_ivanov@yahoo.com"}
                },
                Phones = new HashSet<Phone>()
                {
                    new Phone() {PhoneNumber = "+359 2 22 22 22"},
                    new Phone() {PhoneNumber = "+359 88 77 88 99"}
                },
                Site = @"http://blog.peter.com",
                Notes = "Friend from school"

            };

            Contact con2 = new Contact()
            {
                Name = "Maria",
                Phones = new HashSet<Phone>()
                {
                    new Phone() {PhoneNumber = "+359 22 33 44 55"},
                }
            };

            Contact con3 = new Contact()
            {
                Name = "Angie Stanton",
                Emails = new HashSet<Email>()
                {
                    new Email() {EmailAdress = "info@angiestanton.com"}
                },
                Site = "http://angiestanton.com"
            };
            context.Contacts.Add(con1);
            context.Contacts.Add(con2);
            context.Contacts.Add(con3);
            context.SaveChanges();
        }
    }
}
