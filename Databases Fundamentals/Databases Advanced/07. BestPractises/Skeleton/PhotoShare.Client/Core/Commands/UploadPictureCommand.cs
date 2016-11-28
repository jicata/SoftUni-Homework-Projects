namespace PhotoShare.Client.Core.Commands
{
    using System;
    using Attributes;
    using Data;
    using Models;
    using System.Data.Entity;
    using Data.Contracts;

    public class UploadPictureCommand : Command
    {
        [Inject]
        private IRepository<Album> Albums;

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
