using System;

namespace PhotoShare.Client.Core.Commands
{
    using Attributes;
    using Data;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Data.Contracts;

    public class DeleteUser : Command
    {
        [Inject]
        private IRepository<User> Users;

        public DeleteUser(string[] data) : base(data)
        {
        }

        //DeleteUser <username>
        public override string Execute()
        {
            //TODO Delete User by username (only mark him as inactive)
            string username = Data[1];
            var user = Users
                .Get(u => u.Username == username)
                .FirstOrDefault();
            if (user == null)
            {
                throw new InvalidOperationException($"User with {username} was not found");
            }

            user.IsDeleted = true;

            return $"User {username} was deleted from the databse";
        }
    }
}
