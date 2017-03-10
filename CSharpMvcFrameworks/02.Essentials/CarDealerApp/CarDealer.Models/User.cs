namespace CarDealer.Models
{
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser
    {
        public string Email { get; set; }

    }
}
