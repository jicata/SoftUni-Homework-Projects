namespace PhotoShare.Client.Core.Commands
{
    using Attributes;
    using Data;
    using Models;
    using System;
    using System.Data.Entity;
    using Data.Contracts;

    public class AddTagToCommand : Command
    {
        [Inject]
        private IRepository<Album> Albums;

        public AddTagToCommand(string[] data) : base(data)
        {
        }

        //AddTagTo <albumName> <tag>
        public override string Execute()
        {
            throw new NotImplementedException();
        }
    }
}
