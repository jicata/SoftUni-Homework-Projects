namespace QueryTheDatabase
{
    using System.Data.Entity;
    using MovieDatabase;
    using Newtonsoft.Json;
    using System.IO;
    using System.Linq;
    using MovieDatabase.Migrations;
    using MovieDatabase.Models;

    public class DbQueries
    {
        static void Main()
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<MovieDbContext, Configuration>());

            var context = new MovieDbContext();

            // Query 1
            ExportRatedMoviesByUserId(context, "jmeyery");

            // Query 2
            ExportAdultMovies(context);

            // Query 3
            ExportTop10FavouriteMovies(context);
        }

        private static void ExportTop10FavouriteMovies(MovieDbContext context)
        {
            var favouriteMovies = context.Movies
                .Where(m => m.AgeRestriction == AgeRestriction.Teen)
                .OrderByDescending(m => m.Favoured.Count())
                .ThenBy(m => m.Title)
                .Take(10)
                .Select(m => new
                {
                    isbn = m.Isbn,
                    title = m.Title,
                    favouritedBy = m.Favoured
                        .Select(u => u.Username)
                });

            var json = JsonConvert.SerializeObject(favouriteMovies, Formatting.Indented);
            File.WriteAllText("top-10-favorite-movies.json", json);
        }

        private static void ExportAdultMovies(MovieDbContext context)
        {
            var adultMovies = context.Movies
                .Where(m => m.AgeRestriction == AgeRestriction.Adult)
                .OrderBy(m => m.Title)
                .ThenBy(m => m.Ratings.Count())
                .Select(m => new
                {
                    title = m.Title,
                    ratingsGiven = m.Ratings.Count()
                });

            var json = JsonConvert.SerializeObject(adultMovies, Formatting.Indented);
            File.WriteAllText("adult-movies.json", json);
        }

        private static void ExportRatedMoviesByUserId(MovieDbContext context, string username)
        {
            var ratedMovies = context.Users
                .Where(u => u.Username == username)
                .Select(u => new
                {
                    username = u.Username,
                    ratedMovies = u.GivenRatings
                        .OrderBy(r => r.Movie.Title)
                        .Select(r => new
                        {
                            title = r.Movie.Title,
                            userRating = r.Stars,
                            averageRating = r.Movie.Ratings
                                .Average(mr => mr.Stars)
                        })
                })
                .First();

            var json = JsonConvert.SerializeObject(ratedMovies, Formatting.Indented);
            File.WriteAllText("rated-movies-by-user.json", json);
        }
    }
}
