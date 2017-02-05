namespace PizzaMore.Models
{
    public class Pizza
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Recipe { get; set; }

        public string ImageUrl { get; set; }

        public int Upvotes { get; set; }

        public int Downvotes { get; set; }

        public User User { get; set; }

    }
}
