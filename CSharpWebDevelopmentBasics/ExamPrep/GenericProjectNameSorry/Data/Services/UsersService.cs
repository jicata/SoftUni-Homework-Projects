using SoftUniStore.Data.Contracts;

namespace SoftUniStore.Data.Services
{
    using System.Linq;
    using System.Threading;
    using AutoMapper;
    using Models;
    using Models.BIndingModels;
    using SimpleHttpServer.Models;

    public class UsersService : Service
    {
        public UsersService(ISoftStoreData data) : base(data)
        {
        }

        public bool VerifyRegistration(UserRegisterBindingModel urbm)
        {
            if (!urbm.Email.Contains("@") || !urbm.Email.Contains(".") ||
                this.data.Users.GetAll().Any(u => u.Email == urbm.Email))
            {
                return false;
            }
            if (urbm.Password.Length < 6 || !urbm.Password.Any(char.IsUpper) || !urbm.Password.Any(char.IsLower) ||
                !urbm.Password.Any(char.IsDigit))
            {
                return false;
            }
            if (urbm.Password != urbm.ConfirmPassword)
            {
                return false;
            }
            if (string.IsNullOrEmpty(urbm.FullName))
            {
                return false;
            }

            return true;
        }

        public void Register(UserRegisterBindingModel urbm)
        {
            bool isAdmin = !this.data.Users.GetAll().Any();
            var user= Mapper.Map<UserRegisterBindingModel, User>(urbm);
            user.IsAdmin = isAdmin;

            this.data.Users.InsertOrUpdate(user);
            this.data.SaveChanges();
        }

        public bool IsUserLoggedInOrRegistered(HttpSession session)
        {
            return base.GetUserBySession(session) != null;
        }

        public bool LogUserIn(HttpSession session,UserLoginBindingModel ulbm)
        {
            var user = this.data.Users.FindByPredicate(u => u.Email == ulbm.Email && u.Password == ulbm.Password);
            if (user != null)
            {
                this.CreateLoginForUser(session,user);
                this.data.SaveChanges();
                return true;
            }
            return false;
        }

        private void CreateLoginForUser(HttpSession session, User user)
        {
            var login = new Login()
            {
                IsActive = true,
                SessionId = session.Id,
                User = user
            };
            this.data.Logins.InsertOrUpdate(login);
        }

        public void LogoutUser(HttpSession session)
        {
            var login =this.data.Logins.FindByPredicate(l => l.SessionId == session.Id);
            this.data.Logins.Delete(login);
            this.data.SaveChanges();

            // alternative approach would be to simply deactivate login (e.g login.IsActive = false)
            // however it does not always work properly for me due to sessioning issues 
            // so instead I'm simply deleting the login altogether
        }
    }
}
