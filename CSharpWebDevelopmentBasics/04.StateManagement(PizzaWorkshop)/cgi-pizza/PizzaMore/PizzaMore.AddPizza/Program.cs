using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMore.AddPizza
{
    using System.Collections;
    using Data;
    using Models;
    using Utility;


    class Program
    {
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

                Session = sessions.FirstOrDefault(s => s.Id == sid);


                if (Session == null)
                {
                    WebUtil.PrintFileContent(@"D:\xampp\cgi-bin\cgi-pizza\PizzaMoreAssets\game\index.html");
                }

            }
            Logger.Log(Session.User.Email);
            if (WebUtil.IsGet())
            {

                WebUtil.PrintFileContent(@"D:\xampp\cgi-bin\cgi-pizza\addpizza.html");
            }
            else
            {
           
                try
                {

                    IDictionary<string, string> postParams = WebUtil.RetrievePostParameters();
                    string pizzaName = postParams["title"];
                    string pizzaRecipe = postParams["recipe"];
                    string pizzaUrl = postParams["url"];
                    Pizza pizza = new Pizza()
                    {
                        Name = pizzaName,
                        Recipe = pizzaRecipe,
                        ImageUrl = pizzaUrl,
                        User = Session.User
                    };
                    context.Pizzas.Add(pizza);
                    context.SaveChanges();
                    WebUtil.PrintFileContent(@"D:\xampp\cgi-bin\cgi-pizza\addpizza.html");
                   
                }
                catch (Exception e)
                {
                    Logger.Log(e.Message);
                    throw;
                }
            }
        }
        
    }
}
