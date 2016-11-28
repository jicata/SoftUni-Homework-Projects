namespace PhotoShare.Client.Core.Commands
{
    using System;
    using Attributes;
    using Data;
    using Models;
    using System.Data.Entity;
    public class UploadPictureCommand : Command
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

        public UploadPictureCommand(string[] data) : base(data)
        {
        }

        //UploadPicture <albumName> <pictureTitle> <pictureFilePath>
        public override string Execute()
        {
            throw new NotImplementedException();
        }
    }
}
