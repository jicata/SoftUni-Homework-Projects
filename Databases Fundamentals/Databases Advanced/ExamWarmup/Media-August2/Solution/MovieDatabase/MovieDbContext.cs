namespace MovieDatabase
{
    using System.Data.Entity;
    using Migrations;
    using Models;

    public class MovieDbContext : DbContext
    {
        public MovieDbContext()
            : base("MovieDbContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MovieDbContext, Configuration>());
        }

        public virtual IDbSet<Movie> Movies { get; set; }

        public virtual IDbSet<User> Users { get; set; }

        public virtual IDbSet<Rating> Ratings { get; set; }

        public virtual IDbSet<Country> Countries { get; set; }
    }
}