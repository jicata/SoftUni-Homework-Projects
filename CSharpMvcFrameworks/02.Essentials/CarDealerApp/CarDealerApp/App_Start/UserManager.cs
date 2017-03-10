namespace CarDealerApp
{
    using CarDealer.Data;
    using CarDealer.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin;

    public class UserManager : UserManager<User>
    {
        public UserManager(IUserStore<User> store) : base(store)
        {

        }
        public static UserManager Create(IdentityFactoryOptions<UserManager> options, IOwinContext context)
        {
            var manager = new UserManager(
                new UserStore<User>(context.Get<CarDealerContext>()));

            // optionally configure your manager
            // ...

            return manager;
        }

    }
}