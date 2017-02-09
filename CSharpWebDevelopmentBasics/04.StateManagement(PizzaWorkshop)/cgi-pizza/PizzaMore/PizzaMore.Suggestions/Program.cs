namespace PizzaMore.Suggestions
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Data;
    using Models;
    using Utility;

    class Program
    {
        private static string SuggestionTop = File.ReadAllText(@"D:\xampp\cgi-bin\cgi-pizza\yoursuggestions-top.html");
        private static string SuggestionBottom = File.ReadAllText(@"D:\xampp\cgi-bin\cgi-pizza\yoursuggestions-bottom.html");
        private static Session Session;

        static void Main(string[] args)
        {
            Header header = new Header();
            Console.WriteLine(header);
            var context = new PizzaMoreContext();
            var cookies = WebUtil.GetCookies();
            if (!cookies.ContainsKey("sid"))
            {
                WebUtil.PrintFileContent(@"D:\xampp\cgi-bin\cgi-pizza\PizzaMoreAssets\game\index.html");
            }
            else
            {
                int sid = int.Parse(cookies["sid"].Value.ToString());


                var sessions = context.Sessions.ToList();


                Session = context.Sessions.FirstOrDefault(s => s.Id == sid);


                if (Session == null)
                {
                    WebUtil.PrintFileContent(@"D:\xampp\cgi-bin\cgi-pizza\PizzaMoreAssets\game\index.html");
                }
            }
            if (WebUtil.IsGet())
            {
                Console.WriteLine(SuggestionTop);
                var userPizzas = context.Users.FirstOrDefault(u => Session.User.Id == u.Id).Suggestions.ToList();
                PrintListOfSuggestedItems(userPizzas);
                Console.WriteLine(SuggestionBottom);
            }
            else
            {
                IDictionary<string, string> postParams = WebUtil.RetrievePostParameters();
                int pizzaId = int.Parse(postParams["pizzaId"]);
                var pizza = context.Pizzas.FirstOrDefault(p => p.Id == pizzaId);
                context.Users.FirstOrDefault(u => Session.User.Id == u.Id).Suggestions.Remove(pizza);
                context.SaveChanges();
                Console.WriteLine(SuggestionTop);
                var userPizzas = context.Users.FirstOrDefault(u => Session.User.Id == u.Id).Suggestions.ToList();
                PrintListOfSuggestedItems(userPizzas);
                Console.WriteLine(SuggestionBottom);
            }

        }

        public static void PrintListOfSuggestedItems(IList<Pizza> suggestions)
        {
            
            //http://localhost/cgi-bin/cgi-pizza/PizzaMore/PizzaMore.SignIn/bin/Debug/PizzaMore.Details.exe
            foreach (var suggestion in suggestions)
            {
                Console.WriteLine("<form method=\"POST\">");
                Console.WriteLine($"<li><a href=\"http://localhost/cgi-bin/cgi-pizza/PizzaMore/PizzaMore.SignIn/bin/Debug/PizzaMore.Details.exe" 
                    + $"?pizzaId={suggestion.Id}"+@""">"
                    + $"{suggestion.Name}</a> <input type=\"hidden\" name=\"pizzaId\" value=\"{suggestion.Id}\"/> <input type=\"submit\" class=\"btn btn-sm btn-danger\" value=\"X\"/></li>");
                Console.WriteLine("</form>");
            }
            Console.WriteLine("</ul>");


        }
    }
}
