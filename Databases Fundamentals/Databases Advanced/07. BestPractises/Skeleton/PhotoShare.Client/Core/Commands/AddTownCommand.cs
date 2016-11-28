namespace PhotoShare.Client.Core.Commands
{
    using Attributes;
    using Data;
    using Models;
    using System;
    using System.Data.Entity;
    using Data.Contracts;

    public class AddTownCommand : Command
    {
        [Inject]
        private IRepository<Town> Towns;

        public AddTownCommand(string[] data) : base(data)
        {
        }

        //AddTown <townName> <countryName>
        public override string Execute()
        {
            string townName = Data[1];
            string country = Data[2];

            Town town = new Town()
            {
                Name = townName,
                Country = country
            };

            this.Towns.Add(town);

            return townName + " was added to database";
        }
    }
}
