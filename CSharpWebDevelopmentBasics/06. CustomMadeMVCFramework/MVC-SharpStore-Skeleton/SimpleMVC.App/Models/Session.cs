using System.ComponentModel.DataAnnotations;

namespace SimpleMVC.App.Models
{
    public class Session
    {
        [Key]
        public string Id { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
