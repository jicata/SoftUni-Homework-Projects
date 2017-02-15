namespace SimpleMVC.App.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class Note
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        public virtual User User { get; set; }

    }
}
