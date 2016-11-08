namespace MovieDatabase.Models.DTO
{
    using System.Collections.Generic;

    public class UserMoviesDTO
    {
        public string Username { get; set; }

        public IEnumerable<string> FavouriteMovies { get; set; }
    }
}
