namespace PhotoShare.Client.Core.Commands
{
    using System;
    using Attributes;
    using Data;
    using Models;
    using System;
    using System.Data.Entity;

    public class ModifyUserCommand : Command
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
