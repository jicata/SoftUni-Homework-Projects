using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoShare.Client.Core.Commands
{
    using Attributes;
    using Data;
    using Models;
    using System;
    using System.Data.Entity;

    public class PrintFriendsListCommand : Command
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

        public PrintFriendsListCommand(string[] data) : base(data)
        {
        }

        //PrintFriendsList <username>
        public override string Execute()
        {
            //TODO prints all friends of user with given username
            throw new NotImplementedException();
        }
    }
}
