namespace Phonebook.Client
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using Data;
    using Models;
    using Newtonsoft.Json;

    class Program
    {
        static void Main()
        {
            PhonebookContext contexgt = new PhonebookContext();

            string jsonPath =
                @"C:\Users\Maika\Documents\Programming\Homework\Databases Fundamentals\Databases Advanced\ExamWarmup\Football-Author-Solution\Import-Contacts-from-JSON\contacts.json";

           List<ContactDTO> contacts = JsonConvert.DeserializeObject<List<ContactDTO>>(File.ReadAllText(jsonPath));

            foreach (var contactDto in contacts)
            {
                try
                {
                    if (string.IsNullOrEmpty(contactDto.Name))
                    {
                        throw new InvalidDataException("Name is required");
                    }
                    Contact contact = InsertContactIntoDb(contactDto);
                    contexgt.Contacts.Add(contact);
                    contexgt.SaveChanges();
                    Console.WriteLine($"Contact {contact.Name} imported");
                }
                catch (InvalidDataException e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
               
            }
        }

        private static Contact InsertContactIntoDb(ContactDTO contactDto)
        {
            string company = null;
            string position = null;
            string site = null;
            string notes = null;
            HashSet<Email> emails = new HashSet<Email>();
            HashSet<Phone> phones = new HashSet<Phone>();

            if (!string.IsNullOrEmpty(contactDto.Company))
            {
                company = contactDto.Company;
            }
            if (!string.IsNullOrEmpty(contactDto.Position))
            {
                position = contactDto.Position;
            }
            if (!string.IsNullOrEmpty(contactDto.Site))
            {
                site = contactDto.Site;
            }
            if (!string.IsNullOrEmpty(contactDto.Notes))
            {
                notes = contactDto.Notes;
            }
            if (contactDto.Emails.Any())
            {
                var emailsFromDto = contactDto.Emails.Select(e => new Email() {EmailAdress = e});
                foreach (var email in emailsFromDto)
                {
                    emails.Add(email);
                }
            }
            if (contactDto.Phones.Any())
            {
                var phonesFromDto = contactDto.Phones.Select(p => new Phone() {PhoneNumber = p});
                foreach (var phone in phonesFromDto)
                {
                    phones.Add(phone);
                }
            }
            Contact contact = new Contact()
            {
                Company = company,
                Emails = emails,
                Name = contactDto.Name,
                Notes = notes,
                Phones = phones,
                Position = position,
                Site = site
            };
            return contact;
        }
    }
}
