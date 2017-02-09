namespace PizzaMore.SignUp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using ConsoleClient;
    using Data;
    using Models;
    using Utility;
    using Utility.Security.TopSecurity.NooneWillKnow;

    class Program
    {
        static void Main(string[] args)
        {
            Header header = new Header();
            if (WebUtil.IsGet())
            {
              
                Console.Write(header.ToString());
                WebUtil.PrintFileContent(@"D:\xampp\cgi-bin\cgi-pizza\PizzaSignUp.html");
            }
            else
            {
                IDictionary<string, string> postParams = WebUtil.RetrievePostParameters();
                if (!string.IsNullOrEmpty(postParams["email"]) && !string.IsNullOrEmpty(postParams["password"]))
                {
                    try
                    {
                        using (var context = new PizzaMoreContext())
                        {
                            string email = postParams["email"];
                            string password = PasswordHasher.Hash(postParams["password"]);
                            if (!context.Users.Any(u => u.Email == email))
                            {
                                var user = new User()
                                {
                                    Email = WebUtility.UrlDecode(email),
                                    Password = password
                                };
                                context.Users.Add(user);
                                context.SaveChanges();
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Logger.Log(e.Message +"\n");
                    }
                    Console.Write(header.ToString());
                    WebUtil.PrintFileContent(@"D:\xampp\cgi-bin\cgi-pizza\PizzaSignUp.html");

                }
            }

        }
    }
}
