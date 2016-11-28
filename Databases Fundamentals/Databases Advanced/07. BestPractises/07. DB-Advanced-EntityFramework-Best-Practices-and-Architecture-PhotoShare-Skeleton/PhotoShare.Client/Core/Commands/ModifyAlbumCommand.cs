namespace PhotoShare.Client.Core.Commands
{
    using Attributes;
    using Data;
    using Models;
    using System;
    using System.Data.Entity;
    public class ModifyAlbumCommand : Command
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

        public ModifyAlbumCommand(string[] data) : base(data)
        {
        }

        //ModifyAlbum <albumId> <property> <new value>
        //For example
        //ModifyAlbum 4 Name <new name>
        //ModifyAlbum 4 BackgroundColor <new color>
        //ModifyAlbum 4 IsPublic <True/False>
        public override string Execute()
        {
            throw new NotImplementedException();
        }
    }
}
