namespace PizzaMore.SignIn
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
    using Cookie = Utility.Cookie;

    class Program
    {
        static void Main()
        {
            Header header = new Header();
            if (WebUtil.IsGet())
            {
                Console.Write(header.ToString());
                WebUtil.PrintFileContent(@"D:\xampp\cgi-bin\cgi-pizza\PizzaSignIn.html");
            }
            else
            {
                IDictionary<string, string> postParams = WebUtil.RetrievePostParameters();
                if (!string.IsNullOrEmpty(postParams["email"]) && !string.IsNullOrEmpty(postParams["password"]))
                {
                    try
                    {
                        var context = new PizzaMoreContext();
                         Logger.Log(context.Sessions.Count().ToString());
                            Logger.Log(context.Users.Count().ToString());
                             Logger.Log(context.Pizzas.Count().ToString());

                            string email = WebUtility.UrlDecode(postParams["email"]);
                            string password = PasswordHasher.Hash(postParams["password"]);
                            var user = context.Users.FirstOrDefault(u => u.Email == email);
                            if (user != null && user.Password == password)
                            {
                                Session session = new Session()
                                {
                                    User = user
                                };
                                context.Sessions.Add(session);
                                context.SaveChanges();

                                var lastSession = context.Sessions.FirstOrDefault(s => s.User.Email == email);
                                Cookie cookie = new Cookie("sid", lastSession.Id.ToString()); 
                                header.AddCookie(cookie);
                                Logger.Log($" {cookie} ADDED!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! \n");
                            }
                            
                        
                    }
                    catch (Exception e)
                    {
                        Logger.Log(e.Message + "\n");
                    }
                    Console.Write(header.ToString());
                    WebUtil.PrintFileContent(@"D:\xampp\cgi-bin\cgi-pizza\PizzaSignIn.html");

                }
            }

        }
    }
}
