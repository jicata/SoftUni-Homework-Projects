namespace _18.Survey
{
    using System;
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            string loginHtml =
             File.ReadAllText(
                 @"D:\xampp\cgi-bin\18.Survey.html");
            Console.Write("Content-Type: text/html image/jpeg \n\n");
            Console.Write(loginHtml);
        }
    }
}
