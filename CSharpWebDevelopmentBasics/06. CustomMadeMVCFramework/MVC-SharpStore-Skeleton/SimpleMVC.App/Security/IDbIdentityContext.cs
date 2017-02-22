namespace SharpStore.Security
{
    using System.Data.Entity;
    using Models;

    public interface IDbIdentityContext
    {
        DbSet<Login> Logins { get; set; }

        DbSet<User> Users { get; set; }

        void SaveChanges();
    }
}
