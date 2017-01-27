namespace BrowseCakes
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;

    class Program
    {
        static void Main()
        {
            string dbpath = @"D:\xampp\cgi-bin\cakes.csv";
            string byTheCakeHtml =
                File.ReadAllText(
                    @"D:\xampp\cgi-bin\ByTheCakeBrowseCakes.html");
            Console.Write("Content-Type: text/html image/jpeg \n\n");
            Console.Write(byTheCakeHtml);
            string getQuery = Environment.GetEnvironmentVariable("QUERY_STRING");
            //string getQuery = @"cakeName=chocolate";
            string cakeName = getQuery.Split('=')[1].Replace("+", "");
            string[] allTheCakes = File.ReadAllLines(dbpath);
            foreach (string cake in allTheCakes)
            {
                if (cake.Contains(cakeName))
                {
                    //string relevantCake = cake.Split(',')[0].Replace("Name:", string.Empty);
                    Console.WriteLine(cake +"\n");
                }
            }

        }
    }
}
