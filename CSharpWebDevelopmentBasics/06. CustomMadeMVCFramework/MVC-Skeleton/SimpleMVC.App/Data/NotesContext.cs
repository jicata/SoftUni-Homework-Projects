namespace SimpleMVC.App.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Models;

    public class NotesContext : DbContext
    {
        
        public NotesContext()
            : base("name=NotesContext")
        {
        }

        public IDbSet<User> Users { get; set; }

        public IDbSet<Note> Notes { get; set; }
    }


}