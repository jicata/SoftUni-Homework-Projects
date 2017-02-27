namespace PizzaForum.BindingModels
{
    using System;

    public class UserRegisterBindingModel
    {
        public String Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
