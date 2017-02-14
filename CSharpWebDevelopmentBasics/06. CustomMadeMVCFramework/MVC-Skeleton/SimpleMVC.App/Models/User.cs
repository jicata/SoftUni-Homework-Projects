namespace SimpleMVC.App.Models
{
    using System.Collections.ObjectModel;

    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public virtual Collection<Note> Notes { get; set; }
        
    }
}
