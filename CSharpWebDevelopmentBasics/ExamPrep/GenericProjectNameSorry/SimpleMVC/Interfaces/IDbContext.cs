using SimpleMVC.App.Models;
using System.Data.Entity;

namespace SimpleMVC.App.MVC.Interfaces
{
    public interface IDbContext
    {
        DbSet<Login> Logins { get; }
    }
}
