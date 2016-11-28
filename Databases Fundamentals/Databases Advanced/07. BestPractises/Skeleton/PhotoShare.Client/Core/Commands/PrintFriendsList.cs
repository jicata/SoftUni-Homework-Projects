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
    using Data.Contracts;

    public class PrintFriendsListCommand : Command
    {
        [Inject]
        private IRepository<User> Users;

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
