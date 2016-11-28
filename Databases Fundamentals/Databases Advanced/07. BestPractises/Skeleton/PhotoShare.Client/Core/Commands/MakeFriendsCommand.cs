namespace PhotoShare.Client.Core.Commands
{
    using Attributes;
    using Data;
    using Models;
    using System;
    using System.Data.Entity;
    using Data.Contracts;

    public class MakeFriendsCommand : Command
    {
        [Inject]
        private IRepository<User> Users;

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
