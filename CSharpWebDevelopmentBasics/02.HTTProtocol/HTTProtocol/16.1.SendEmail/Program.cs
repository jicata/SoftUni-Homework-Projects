namespace _16._1.SendEmail
{
    using System;
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            string emailHtml =
              File.ReadAllText(
                  @"D:\xampp\cgi-bin\Email.html");
            Console.Write("Content-Type: text/html image/jpeg \n\n");
            Console.Write(emailHtml);
            string postContent = Console.ReadLine();
            if (!string.IsNullOrEmpty(postContent))
            {
                
            }
        }
    }
}
