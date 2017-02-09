namespace PizzaMore.Menu
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Validation;
    using System.IO;
    using System.Linq;
    using Data;
    using Microsoft.Win32;
    using Models;
    using Utility;

    class Program
    {
        private static string MenuTop = File.ReadAllText(@"D:\xampp\cgi-bin\cgi-pizza\menu-top.html");
        private static string MenuBottom = File.ReadAllText(@"D:\xampp\cgi-bin\cgi-pizza\menu-bottom.html");
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

                Session = context.Sessions.FirstOrDefault(s => s.Id == sid);

                Logger.Log($" {context.Sessions.Count()} \n");
                Console.WriteLine(MenuTop);
                if (Session == null)
                {
                    Logger.Log($" {context.Sessions.Count()} \n");
                    Console.WriteLine("kuuuuuuuuuuuuuuuuuuur");
                    return;
                }
            }


            if (WebUtil.IsGet())
            {
               
               
                GenerateNavBar();
               
                var pizzas = context.Pizzas.ToList();
                GenerateSuggestions(pizzas);
                Console.WriteLine(MenuBottom);


            }
            else
            {
                IDictionary<string, string> postParams = WebUtil.RetrievePostParameters();
                string vote = postParams["pizzaVote"];
                int pizzaId = int.Parse(postParams["pizzaid"]);
                var pizza = context.Pizzas.FirstOrDefault(p => p.Id == pizzaId);
                if (vote == "up")
                {
                    pizza.Upvotes++;
                }
                else
                {
                    pizza.Downvotes++;
                }
                context.SaveChanges();

                Console.WriteLine(MenuTop);
                GenerateNavBar();

                var pizzas = context.Pizzas.ToList();
                GenerateSuggestions(pizzas);
                Console.WriteLine(MenuBottom);
            }
        }

        private static void GenerateSuggestions(List<Pizza> pizzas)
        {
            Console.WriteLine("<div class=\"card-deck\">");
            foreach (var pizza in pizzas)
            {
                Console.WriteLine("<div class=\"card\">");
                Console.WriteLine($"<img class=\"card-img-top\" src=\"{pizza.ImageUrl}\" width=\"200px\"alt=\"Card image cap\">");
                Console.WriteLine("<div class=\"card-block\">");
                Console.WriteLine($"<h4 class=\"card-title\">{pizza.Name}</h4>");
                Console.WriteLine($"<p class=\"card-text\"><a href=\"DetailsPizza.exe?pizzaid={pizza.Id}\">Recipe</a></p>");
                Console.WriteLine("<form method=\"POST\">");
                Console.WriteLine($"<div class=\"radio\"><label><input type = \"radio\" name=\"pizzaVote\" value=\"up\">Up</label></div>");
                Console.WriteLine($"<div class=\"radio\"><label><input type = \"radio\" name=\"pizzaVote\" value=\"down\">Down</label></div>");
                Console.WriteLine($"<input type=\"hidden\" name=\"pizzaid\" value=\"{pizza.Id}\" />");
                Console.WriteLine("<input type=\"submit\" class=\"btn btn-primary\" value=\"Vote\" />");
                Console.WriteLine("</form>");
                Console.WriteLine("</div>");
                Console.WriteLine("</div>");
            }
            Console.WriteLine("</div>");

        }

        private static void GenerateNavBar()
        {
            Console.WriteLine("<nav class=\"navbar navbar-default\">" +
                "<div class=\"container-fluid\">" +
                "<div class=\"navbar-header\">" +
                "<a class=\"navbar-brand\" href=\"http://localhost/cgi-bin/cgi-pizza/PizzaMore/PizzaMore.SignIn/bin/Debug/PizzaMore.ConsoleClient.exe\">PizzaMore</a>" +
                "</div>" +
                "<div class=\"collapse navbar-collapse\" id=\"bs-example-navbar-collapse-1\">" +
                "<ul class=\"nav navbar-nav\">" +
                "<li ><a href=\"http://localhost/cgi-bin/cgi-pizza/PizzaMore/PizzaMore.SignIn/bin/Debug/PizzaMore.AddPizza.exe\">Suggest Pizza</a></li>" +
                "<li><a href=\"http://localhost/cgi-bin/cgi-pizza/PizzaMore/PizzaMore.SignIn/bin/Debug/PizzaMore.Suggestions.exe\" > Your Suggestions</a></li>" +
                "</ul>" +
                "<ul class=\"nav navbar-nav navbar-right\">" +
                "<p class=\"navbar-text navbar-right\"></p>" +
                "<p class=\"navbar-text navbar-right\"><a href=\"http://localhost/cgi-bin/cgi-pizza/PizzaMore/PizzaMore.SignIn/bin/Debug/PizzaMore.ConsoleClient.exe"
                    + "?logout=true\"" 
                    + "class=\"navbar-link\">Sign Out</a></p>" +
                $"<p class=\"navbar-text navbar-right\">Signed in as {Session.User.Email}</p>" +
                "</ul> </div></div></nav>");

        }
    }
}
