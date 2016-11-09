namespace Phonebook_EF_Code_First
{
    using System.Data.Entity;

    using Phonebook_EF_Code_First.Migrations;

    public class PhonebookContext : DbContext
    {
        public PhonebookContext()
            : base("name=PhonebookContext")
        {
            Database.SetInitializer(
               new MigrateDatabaseToLatestVersion<PhonebookContext,
                   PhonebookMigrationsConfiguration>());
        }

        public virtual DbSet<Contact> Contacts { get; set; }

        public virtual DbSet<Email> Emails { get; set; }
        
        public virtual DbSet<Phone> Phones { get; set; }
    }
}
