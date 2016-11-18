namespace Phonebook.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Models;

    public class PhonebookContext : DbContext
    {
        public PhonebookContext()
            : base("name=PhonebookContext")
        {
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Email> Emails { get; set; }
    }
}