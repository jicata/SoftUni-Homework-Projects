namespace PhotoShare.Client.Core.Commands
{
    using Attributes;
    using Data;
    using Models;
    using System;
    using System.Data.Entity;
    public class MakeFriendsCommand : Command
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

        public MakeFriendsCommand(string[] data) : base(data)
        {
        }

        public override string Execute()
        {
            //bidirectional adding friends
            //MakeFriends <username1> <username2>
            throw new NotImplementedException();
        }
    }
}
