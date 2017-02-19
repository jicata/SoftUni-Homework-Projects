namespace SimpleMVC.App.MVC.Interfaces
{
    using System.Data.Entity;
    using Models;

    public interface IDbIdentityContext
    {
        DbSet<Login> Logins { get; }

        DbSet<User> Users { get; }

        void SaveChanges();
    }
}
