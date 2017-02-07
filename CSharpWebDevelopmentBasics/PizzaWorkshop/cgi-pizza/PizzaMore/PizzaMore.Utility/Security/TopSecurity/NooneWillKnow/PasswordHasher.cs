namespace PizzaMore.Utility.Security.TopSecurity.NooneWillKnow
{
    public static class PasswordHasher
    {
        public static string Hash(string password)
        {
            return "SECRET" + password;
 ;       }
    }
}
