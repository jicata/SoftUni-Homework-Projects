using PhotoShare.Models;
using System;

namespace PhotoShare.Client.Core.Commands
{
    using Attributes;
    using Data;
    using Models;
    using System;
    using System.Data.Entity;
    public class CreateAlbumCommand : Command
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

        public CreateAlbumCommand(string[] data) : base(data)
        {
        }

        //CreateAlbum <username> <albumTitle> <BgColor> <tag1> <tag2>...<tagN>
        public override string Execute()
        {
            throw new NotImplementedException();
        }
    }
}
