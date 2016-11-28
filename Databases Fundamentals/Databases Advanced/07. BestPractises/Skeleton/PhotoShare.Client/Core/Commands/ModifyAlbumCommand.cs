namespace PhotoShare.Client.Core.Commands
{
    using Attributes;
    using Data;
    using Models;
    using System;
    using System.Data.Entity;
    using Data.Contracts;

    public class ModifyAlbumCommand : Command
    {
        [Inject]
        private IRepository<Album> Albums;

        public ModifyAlbumCommand(string[] data) : base(data)
        {
        }

        //ModifyAlbum <albumId> <property> <new value>
        //For example
        //ModifyAlbum 4 Name <new name>
        //ModifyAlbum 4 BackgroundColor <new color>
        //ModifyAlbum 4 IsPublic <True/False>
        public override string Execute()
        {
            throw new NotImplementedException();
        }
    }
}
