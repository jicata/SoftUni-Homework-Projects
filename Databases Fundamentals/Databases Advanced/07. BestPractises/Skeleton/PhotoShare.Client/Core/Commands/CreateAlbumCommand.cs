using PhotoShare.Models;
using System;

namespace PhotoShare.Client.Core.Commands
{
    using Attributes;
    using Data;
    using Models;
    using System;
    using System.Data.Entity;
    using Data.Contracts;

    public class CreateAlbumCommand : Command
    {
        [Inject]
        private IRepository<Album> Albums;

        public CreateAlbumCommand(string[] data) : base(data)
        {
        }

        //CreateAlbum <username> <albumTitle> <BgColor> <tag1> <tag2>...<tagN>
        public override string Execute()
        {
            throw new NotImplementedException();
        }
    }
}
