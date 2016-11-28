namespace PhotoShare.Client.Core.Commands
{
    using Attributes;
    using Data;
    using Models;
    using System;
    using System.Data.Entity;
    using Data.Contracts;

    public class UploadProfilePictureCommand : Command
    {
        [Inject]
        private IRepository<User> Users;

        public UploadProfilePictureCommand(string[] data) : base(data)
        {
        }

        //UploadProfilePicture <username> <pictureFilePath>
        public override string Execute()
        {
            throw new NotImplementedException();
        }
    }
}
