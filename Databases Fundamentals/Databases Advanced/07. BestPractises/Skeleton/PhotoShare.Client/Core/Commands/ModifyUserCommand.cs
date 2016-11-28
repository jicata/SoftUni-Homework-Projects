namespace PhotoShare.Client.Core.Commands
{
    using System;
    using Attributes;
    using Data;
    using Models;
    using System;
    using System.Data.Entity;
    using Data.Contracts;

    public class ModifyUserCommand : Command
    {
        [Inject]
        private IRepository<User> Users;

        public ModifyUserCommand(string[] data) : base(data)
        {
        }

        //ModifyUser <username> <property> <new value>
        //For example:
        //ModifyUser <username> Password <NewPassword>
        //ModifyUser <username> Email <NewEmail>
        //ModifyUser <username> FirstName <NewFirstName>
        //ModifyUser <username> LastName <newLastName>
        //ModifyUser <username> BornTown <newBornTownName>
        //ModifyUser <username> CurrentTown <newCurrentTownName>
        //!!! Cannot change username
        public override string Execute()
        {
            throw new NotImplementedException();
        }
    }
}
