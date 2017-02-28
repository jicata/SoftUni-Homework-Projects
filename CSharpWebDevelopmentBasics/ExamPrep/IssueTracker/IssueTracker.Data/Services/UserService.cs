namespace IssueTracker.Data.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Contracts;
    using Models;
    using Models.BindingModels;
    using Models.Enums;
    using Models.Extensions;
    using Models.ViewModels;
    using SimpleHttpServer.Models;
    using RegistrationErrorVM = Models.ViewModels.RegistrationVerificationErrorViewModel;
    public class UserService : Service
    {
        public UserService(IIssueTrackerData data) : base(data)
        {

        }

        public HashSet<RegistrationErrorVM> ValidateUserRegister(UserRegisterBindingModel urbm)
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
            if (urbm.Password.Length < 8 || !urbm.Password.Any(char.IsUpper) || !urbm.Password.Any(char.IsDigit) ||
                !specialSymbolrgx.IsMatch(urbm.Password))
            {
                revms.Add(new RegistrationErrorVM(Constants.PasswordIncorrectFormatMessage));
            }
            if (urbm.Password != urbm.ConfirmPassword)
            {
                revms.Add(new RegistrationErrorVM(Constants.PasswordsDoNotMatchMessage));
            }
            return revms;

        }

        public bool RegisterUser(UserRegisterBindingModel urbm)
        {
            Role role = this.data.Users.GetAll().Any() ? Role.Regular : Role.Administrator;
            
            User user = new User()
            {
                UserName = urbm.Username,
                FullName = urbm.FullName,
                Password = urbm.Password,
                Role = role
            };
            try
            {
                this.data.Users.InsertOrUpdate(user);
                this.data.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
            return true;
        }

        public bool LoginUser(HttpSession session, LoginUserBindingModel lubm)
        {
            var user = this.data.Users.FindByPredicate(u => u.UserName == lubm.Username && u.Password == lubm.Password);
            if (user != null)
            {
                var existingLogin = this.data.Logins.FindByPredicate(l => l.SessionId == session.Id);
                if (existingLogin !=null)
                {
                    existingLogin.IsActive = true;
                }
                else
                {
                    var login = new Login()
                    {
                        User = user,
                        SessionId = session.Id,
                        IsActive = true
                    };
                    this.data.Logins.InsertOrUpdate(login);                
                }
                this.data.SaveChanges();
                return true;
            }
            return false;
        }

        public void LogoutUser(HttpSession session, HttpResponse response)
        {
            var login = this.data.Logins.FindByPredicate(l => l.SessionId == session.Id);
            //login.IsActive = false;
            this.data.Logins.Delete(login);
            this.data.SaveChanges();
        }
    }
}
