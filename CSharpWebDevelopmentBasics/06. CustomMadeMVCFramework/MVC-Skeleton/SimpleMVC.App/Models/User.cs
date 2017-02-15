namespace SimpleMVC.App.Models
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class User
    {
        public User()
        {
            this.Notes = new List<Note>();
        }
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public virtual List<Note> Notes { get; set; }
        
    }
}
