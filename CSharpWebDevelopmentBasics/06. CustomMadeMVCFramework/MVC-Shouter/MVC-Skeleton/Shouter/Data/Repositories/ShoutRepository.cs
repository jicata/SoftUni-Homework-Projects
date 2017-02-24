namespace Shouter.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
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
            shoutsThatHaveNotExpired.Sort((x, y) => y.PostedOn.Value.CompareTo(x.PostedOn.Value));

            return shoutsThatHaveNotExpired;
        }

        public List<Shout> UpdateAndGetAllShouts(Expression<Func<Shout, bool>> predicate)
        {
            var shouts = this.EntityTable.Where(predicate);
            var shoutsThatHaveNotExpired = new List<Shout>();
            foreach (var shout in shouts)
            {
                var now = DateTime.Now;
                var timeSinceCreation = now - shout.PostedOn;
                if (timeSinceCreation > shout.Lifetime && shout.Lifetime.Value.Minutes != 0)
                {
                    this.EntityTable.Remove(shout);
                }
                else
                {
                    shoutsThatHaveNotExpired.Add(shout);
                }
            }
            shoutsThatHaveNotExpired.Sort((x, y) => y.PostedOn.Value.CompareTo(x.PostedOn.Value));
            return shoutsThatHaveNotExpired;
        }
    }
}
