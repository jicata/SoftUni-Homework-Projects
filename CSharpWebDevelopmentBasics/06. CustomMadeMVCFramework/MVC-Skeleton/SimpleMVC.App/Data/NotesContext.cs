namespace SimpleMVC.App.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Models;
    using MVC.Interfaces;

    public class NotesContext : DbContext, IDbIdentityContext
    {
        
        public NotesContext()
            : base("name=NotesContext")
        {
        }

        public DbSet<User> Users { get; set; }
        public IDbSet<Note> Notes { get; set; }
        public DbSet<Login> Logins { get; set; }
        public void SaveChanges()
        {
            base.SaveChanges();
        }
    }


}