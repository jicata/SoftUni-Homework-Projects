namespace IssueTracker.Data.Service
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Contracts;
    using Models.BindingModels;
    using Models.ViewModels;
    using Constants;
    using Models;
    using Models.Enums;
    using SimpleHttpServer.Models;
    using RegistrationErrorVM = Models.ViewModels.RegistrationVerificationErrorViewModel;
    public class UserService : Service
    {
        public UserService(IIssueTrackerData data)
            : base(data)
        {
        }

        public HashSet<RegistrationVerificationErrorViewModel> VerifyRegister
            (UserRegistrationBindingModel urbm)
        {
            HashSet<RegistrationErrorVM> revms = new HashSet<RegistrationErrorVM>();

            if (urbm.Username.Length < 5 || urbm.Username.Length > 30)
            {
                revms.Add(new RegistrationErrorVM(Constants.UserNameLengthErrorMessage));
            }
            if (urbm.FullName.Length < 5)
            {
                revms.Add(new RegistrationErrorVM(Constants.FullNameTooShortMessage));
            }
            Regex specialSymbolrgx = new Regex(@"[!@#$%^&*,.]");
            //if (urbm.Password.Length < 8 || !urbm.Password.Any(char.IsUpper) || !urbm.Password.Any(char.IsDigit) ||
            //    !specialSymbolrgx.IsMatch(urbm.Password))
            //{
            //    revms.Add(new RegistrationErrorVM(Constants.PasswordIncorrectFormatMessage));
            //}
            if (urbm.Password != urbm.ConfirmPassword)
            {
                revms.Add(new RegistrationErrorVM(Constants.PasswordsDoNotMatchMessage));
            }
            return revms;
        }

        public void Register(UserRegistrationBindingModel rubm)
        {
            Role role = this.data.Users.GetAll().Any() ? Role.Regular : Role.Administrator;
            var user = new User()
            {
                FullName = rubm.FullName,
                Password = rubm.Password,
                Username = rubm.Username,
                Role = role
            };
            this.data.Users.InsertOrUpdate(user);
            this.data.SaveChanges();
        }

        public bool LoginUser(HttpSession session, UserLoginBindingModel ulbm)
        {
            var user = this.data.Users.FindByPredicate(
                u => u.Username == ulbm.Username && ulbm.Password == u.Password);
            if (user != null)
            {
                var login = this.data.Logins.FindByPredicate(
                    l => l.User.Username == user.Username && l.SessionId == session.Id);
                if (login != null)
                {
                    login.IsActive = true;               
                }
                else
                {
                    login = new Login()
                    {
                        IsActive = true,
                        User = user,
                        SessionId = session.Id
                    };
                }
                this.data.Logins.InsertOrUpdate(login);
                this.data.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
