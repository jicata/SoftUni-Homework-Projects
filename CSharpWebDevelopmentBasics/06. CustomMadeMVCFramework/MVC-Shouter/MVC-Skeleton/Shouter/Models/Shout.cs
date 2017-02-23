namespace Shouter.Models
{
    using System;

    public class Shout
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime? PostedOn { get; set; }

        public TimeSpan? Lifetime { get; set; }

        public virtual User Author { get; set; }
        
    }
}
