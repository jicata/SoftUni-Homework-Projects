namespace SoftUniStore.Models.BIndingModels
{
    public class UserRegisterBindingModel
    {
        public string Email { get; set; }

        public string FullName { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; } 
    }
}
