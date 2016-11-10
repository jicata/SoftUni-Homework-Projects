namespace _02.CreateUser
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
           UserContext context = new UserContext();
            Console.WriteLine(context.Users.Count());
          
        }
    }
}
