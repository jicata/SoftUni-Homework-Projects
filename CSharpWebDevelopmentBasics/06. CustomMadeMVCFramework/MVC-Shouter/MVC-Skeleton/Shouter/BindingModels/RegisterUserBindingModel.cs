namespace Shouter.BindingModels
{
    using System;

    public class RegisterUserBindingModel
    {

        public string Username { get; set; }

        public string Password { get; set; }

        public string ConfirmedPassword { get; set; }

        public string Email { get; set; }

        public string Birthdate { get; set; }

    }
}
