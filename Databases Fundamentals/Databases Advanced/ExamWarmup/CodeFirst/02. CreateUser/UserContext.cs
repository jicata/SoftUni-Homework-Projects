namespace _02.CreateUser
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class UserContext : DbContext
    {

        public UserContext()
            : base("name=UserContext")
        {
        }

        public IDbSet<User> Users { get; set; }



    }
}

  