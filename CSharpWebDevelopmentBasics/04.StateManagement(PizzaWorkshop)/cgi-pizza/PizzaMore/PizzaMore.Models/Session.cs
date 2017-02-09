namespace PizzaMore.Models
{
    public class Session
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public override string ToString()
        {
            return $"{this.Id}\t{this.UserId}";
        }
    }
}
