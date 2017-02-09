using System.ComponentModel.DataAnnotations;

namespace PizzaMore.Data
{
    public class Session
    {
        [Key]
        public string Id { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public override string ToString()
        {
            return $"{this.Id}\t{this.User.Id}";
        }
    }
}
