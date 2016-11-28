namespace PhotoShare.Client.Core.Commands
{
    using Data;
    using Models;
    using System.Data.Entity;
    using Attributes;
    using Data.Contracts;

    public class AddTagCommand : Command
    {
        [Inject]
        private IRepository<Tag> Tags;
        
        public AddTagCommand(string[] data) : base(data)
        {
        }

        //AddTag <tag>
        public override string Execute()
        {
            string tag = Data[1].ValidateOrTransform();

            this.Tags.Add(new Tag
            {
                Name = tag
            });
            
            return tag + " was added sucessfully to database";
        }
    }
}
