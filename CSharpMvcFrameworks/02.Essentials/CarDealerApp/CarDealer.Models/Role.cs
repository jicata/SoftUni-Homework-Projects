namespace CarDealer.Models
{
    using Microsoft.AspNet.Identity.EntityFramework;
    public class Role : IdentityRole
    {
        public Role() 
            : base() { }
        public Role(string name)
            : base(name) { }
    }
}
