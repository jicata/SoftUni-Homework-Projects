namespace Login
{
    using System;
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            string loginHtml =
              File.ReadAllText(
                  @"D:\xampp\cgi-bin\Login.html");
            Console.Write("Content-Type: text/html image/jpeg \n\n");
            Console.Write(loginHtml);
            string postContent = Console.ReadLine();
            if (!string.IsNullOrEmpty(postContent))
            {
                string[] postFormatted = postContent.Split('&');
                string username = postFormatted[0].Split('=')[1];
                string password = postFormatted[1].Split('=')[1];
                Console.WriteLine($"Hi {username}, your password is {password}");
            }
        }
    }
}
