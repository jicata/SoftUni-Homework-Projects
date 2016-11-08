namespace MovieDatabase.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        private ICollection<Movie> favouriteMovies;
        private ICollection<Rating> givenRatings;
 
        public User()
        {
            this.favouriteMovies = new HashSet<Movie>();   
            this.givenRatings = new HashSet<Rating>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        public string Username { get; set; }

        public string Email { get; set; }

        public int? Age { get; set; }

        public int? CountryId { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<Rating> GivenRatings
        {
            get { return this.givenRatings; }
            set { this.givenRatings = value; }
        }

        public virtual ICollection<Movie> FavouriteMovies
        {
            get { return this.favouriteMovies; }
            set { this.favouriteMovies = value; }
        }
    }
}
