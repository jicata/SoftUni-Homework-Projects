namespace PhotoShare.Client.Core.Commands
{
    using System;
    using Attributes;
    using Data;
    using Models;
    using System;
    using System.Data.Entity;
    using Data.Contracts;

    public class ShareAlbumCommand : Command
    {
        [Inject]
        private IRepository<User> Users;

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
