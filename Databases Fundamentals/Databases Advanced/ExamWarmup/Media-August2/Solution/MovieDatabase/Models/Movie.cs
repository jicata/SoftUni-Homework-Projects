namespace MovieDatabase.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Movie
    {
        private ICollection<Rating> ratings;
        private ICollection<User> favoured;
 
        public Movie()
        {
            this.ratings = new HashSet<Rating>();    
            this.favoured = new HashSet<User>();
        }

        public int Id { get; set; }

        [Required]
        public string Isbn { get; set; }

        [Required]
        [MinLength(2)]
        public string Title { get; set; }

        public AgeRestriction AgeRestriction { get; set; }

        public virtual ICollection<User> Favoured
        {
            get { return this.favoured; }
            set { this.favoured = value; }
        }

        public virtual ICollection<Rating> Ratings
        {
            get { return this.ratings; }
            set { this.ratings = value; }
        }
    }
}
