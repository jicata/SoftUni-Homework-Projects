namespace PhotoShare.Client
{
    using Core;
    using Data;
    using Interfaces;
    using IO;
    using Models;
    using System.Data.Entity;

    class Application
    {
        static void Main()
        {
            var context = new PhotoShareContext();
            DbSet<User> users = context.Users;
            DbSet<Album> albums = context.Albums;
            DbSet<Picture> pictures = context.Pictures;
            DbSet<Tag> tags = context.Tags;
            DbSet<AlbumRole> albumRoles = context.AlbumRoles;
            DbSet<Town> towns = context.Towns;
            ICommandDispatcher commandDispatcher = new CommandDispatcher(context, users, albums, pictures, tags, albumRoles, towns);
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IRunnable engine = new Engine(commandDispatcher, reader, writer);
            engine.Run("start");
        }
    }
}
