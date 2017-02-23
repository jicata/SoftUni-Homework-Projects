namespace Shouter.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Models;
    public class ShoutRepository : Repository<Shout>
    {
        public ShoutRepository(IShouterContext context) 
            : base(context)
        {
        }

        public List<Shout> UpdateAndGetAllShouts()
        {
            var shouts = this.GetAll();
            var shoutsThatHaveNotExpired = new List<Shout>();
            foreach (var shout in shouts)
            {
                var now = DateTime.Now;
                var timeSinceCreation = now - shout.PostedOn;
                if (timeSinceCreation > shout.Lifetime && shout.Lifetime.Value.Minutes!=0)
                {
                    this.EntityTable.Remove(shout);
                }
                else
                {
                    shoutsThatHaveNotExpired.Add(shout);
                }
            }
            return shoutsThatHaveNotExpired;
        }
    }
}
