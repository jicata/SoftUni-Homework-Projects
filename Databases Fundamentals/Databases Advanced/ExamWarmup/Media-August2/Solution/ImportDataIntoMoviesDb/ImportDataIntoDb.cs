namespace ImportDataIntoMoviesDb
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using MovieDatabase;
    using MovieDatabase.Models;
    using MovieDatabase.Models.DTO;
    using Newtonsoft.Json;

    public class ImportDataIntoDb
    {
        private const string RootDirectory = "../../";
        private const string UsersFavouriteMoviesJsonPath = RootDirectory + "data/users-and-favourite-movies.json";
        private const string MoviesJsonPath = RootDirectory + "data/movies.json";
        private const string UsersJsonPath = RootDirectory + "data/users.json";
        private const string CountriesJsonPath = RootDirectory + "data/countries.json";
        private const string MovieRatingsJsonPath = RootDirectory + "data/movie-ratings.json";

        static void Main()
        {
            ImportCountries();
            ImportUsers();
            ImportMovies();
            ImportRatings();
            ImportFavouriteMovies();
        }

        private static void ImportFavouriteMovies()
        {
            var context = new MovieDbContext();
            var json = File.ReadAllText(UsersFavouriteMoviesJsonPath);
            var userMovies = JsonConvert.DeserializeObject<IEnumerable<UserMoviesDTO>>(json);

            foreach (var userFavouriteMovies in userMovies)
            {
                var user = GetUserByUsername(userFavouriteMovies.Username, context);
                foreach (var favouriteMovie in userFavouriteMovies.FavouriteMovies)
                {
                    var movie = GetMovieByIsbn(favouriteMovie, context);
                    user.FavouriteMovies.Add(movie);
                }
            }

            context.SaveChanges();
        }

        private static void ImportRatings()
        {
            var json = File.ReadAllText(MovieRatingsJsonPath);
            var ratings = JsonConvert.DeserializeObject<IEnumerable<RatingDTO>>(json);
            var context = new MovieDbContext();
            foreach (var rating in ratings)
            {
                var user = GetUserByUsername(rating.User, context);
                var movie = GetMovieByIsbn(rating.Movie, context);
                user.GivenRatings.Add(new Rating()
                {
                    Movie = movie,
                    User = user,
                    Stars = rating.Rating
                });
            }

            context.SaveChanges();
        }

        private static void ImportMovies()
        {
            var context = new MovieDbContext();
            var moviesJson = File.ReadAllText(MoviesJsonPath);
            var movies = JsonConvert.DeserializeObject<IEnumerable<MovieDTO>>(moviesJson);

            foreach (var movie in movies)
            {
                context.Movies.Add(new Movie()
                {
                    Title = movie.Title,
                    AgeRestriction = (AgeRestriction)movie.AgeRestriction,
                    Isbn = movie.Isbn
                });
            }

            context.SaveChanges();
        }

        private static void ImportUsers()
        {
            var context = new MovieDbContext();
            var usersJson = File.ReadAllText(UsersJsonPath);
            var users = JsonConvert.DeserializeObject<IEnumerable<UserDTO>>(usersJson);

            foreach (var user in users)
            {
                var userEntity = new User
                {
                    Username = user.Username,
                    Email = user.Email,
                    Age = user.Age,
                    Country = GetCountryByName(user.Country, context)
                };

                context.Users.Add(userEntity);
            }

            context.SaveChanges();
        }

        private static void ImportCountries()
        {
            var context = new MovieDbContext();
            var countriesJson = File.ReadAllText(CountriesJsonPath);

            var countries = JsonConvert.DeserializeObject<IEnumerable<CountryDTO>>(countriesJson);
            foreach (var country in countries)
            {
                context.Countries.Add(new Country()
                {
                    Name = country.Name
                });
            }

            context.SaveChanges();
        }

        private static User GetUserByUsername(string username, MovieDbContext context)
        {
            return context.Users.First(u => u.Username == username);
        }

        private static Movie GetMovieByIsbn(string isbn, MovieDbContext context)
        {
            return context.Movies.First(u => u.Isbn == isbn);
        }

        private static Country GetCountryByName(string name, MovieDbContext context)
        {
            return context.Countries.FirstOrDefault(c => c.Name == name);
        }
    }
}
