namespace PizzaForum.Models
{
    using System.Collections.Generic;

    public class Category
    {
        public Category()
        {
            this.Topics = new HashSet<Topic>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Topic> Topics { get; set; }
        
    }
}
