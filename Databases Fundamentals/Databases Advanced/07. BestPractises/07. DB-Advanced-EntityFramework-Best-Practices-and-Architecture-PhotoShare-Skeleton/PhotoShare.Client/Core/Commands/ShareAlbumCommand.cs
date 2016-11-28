namespace PhotoShare.Client.Core.Commands
{
    using System;
    using Attributes;
    using Data;
    using Models;
    using System;
    using System.Data.Entity;

    public class ShareAlbumCommand : Command
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

        public ShareAlbumCommand(string[] data) : base(data)
        {
        }

        //ShareAlbum <albumId> <username> <permission>
        //For example:
        //ShareAlbum 4 dragon321 Owner
        //ShareAlbum 4 dragon11 Viewer
        public override string Execute()
        {
            throw new NotImplementedException();
        }
    }
}
