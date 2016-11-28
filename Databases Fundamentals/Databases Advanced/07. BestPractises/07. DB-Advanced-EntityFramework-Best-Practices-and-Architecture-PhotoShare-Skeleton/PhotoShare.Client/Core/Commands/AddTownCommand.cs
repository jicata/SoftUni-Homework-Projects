namespace PhotoShare.Client.Core.Commands
{
    using Attributes;
    using Data;
    using Models;
    using System;
    using System.Data.Entity;
    public class AddTownCommand : Command
    {
        [Inject]
        private PhotoShareContext context;
        [Inject]
        private DbSet<User> users;
        [Inject]
        private DbSet<Album> albums;
        [Inject]
        private DbSet<Picture> pictures;
        [Inject]
        private DbSet<Tag> tags;
        [Inject]
        private DbSet<AlbumRole> albumRoles;
        [Inject]
        private DbSet<Town> towns;

        public AddTownCommand(string[] data) : base(data)
        {
        }

        //AddTown <townName> <countryName>
        public override string Execute()
        {
            string townName = Data[1];
            string country = Data[2];

            Town town = new Town()
            {
                Name = townName,
                Country = country
            };

            this.towns.Add(town);

            return townName + " was added to database";
        }
    }
}
