namespace PhotoShare.Client.Core.Commands
{
    using Attributes;
    using Data;
    using Models;
    using System;
    using System.Data.Entity;
    public class AddTagToCommand : Command
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

        public AddTagToCommand(string[] data) : base(data)
        {
        }

        //AddTagTo <albumName> <tag>
        public override string Execute()
        {
            throw new NotImplementedException();
        }
    }
}
