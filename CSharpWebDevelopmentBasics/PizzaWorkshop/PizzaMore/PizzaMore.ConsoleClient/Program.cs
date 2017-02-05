namespace PizzaMore.ConsoleClient
{
    using System;
    using System.IO;
    using Utility;

    class Program
    {
        static void Main(string[] args)
        {
           var home = new Home();
            home.AddDefaultLanguageCookie();
            home.ShowPage();
        }
    }
}
