namespace ByTheCakeAddCake
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices;

    public class Program
    {
        static void Main(string[] args)
        {
            string dbpath = @"D:\xampp\cgi-bin\cakes.csv";
            string byTheCakeHtml =
               File.ReadAllText(
                   @"D:\xampp\cgi-bin\AddCake.html");
            Console.Write("Content-Type: text/html image/jpeg \n\n");
            Console.Write(byTheCakeHtml);
            string postContent = Console.ReadLine();
            if (postContent != null)
            {
                string[] firstSplit = postContent.Split('&');
                string name = firstSplit[0].Split('=')[1].Replace("+", string.Empty);
                string price = firstSplit[1].Split('=')[1];
                string formatted = $"{name} ${price} \n";
                File.AppendAllText(dbpath, formatted);
                Console.WriteLine($"{name} ${price}");
            }
        }
    }
}
