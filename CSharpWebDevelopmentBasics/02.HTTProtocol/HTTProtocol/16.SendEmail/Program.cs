namespace _16.SendEmail
{
    using System;
    using System.IO;

    class Program
    {
        static void Main()
        {
            string loginHtml =
              File.ReadAllText(
                  @"D:\xampp\cgi-bin\Login2.html");
            Console.Write("Content-Type: text/html image/jpeg \n\n");
            Console.Write(loginHtml);
            string postContent = Console.ReadLine();
            if (!string.IsNullOrEmpty(postContent))
            {
                string[] postContentFormatted = postContent.Split('&');
                string userName = postContentFormatted[0].Split('=')[1];
                string password = postContentFormatted[1].Split('=')[1];
                if (userName == @"suAdmin" && password == @"aDmInPw17")
                {
                  Console.WriteLine(@"<script language=""javascript"">
                                    window.location.href = ""http://localhost/cgi-bin/16.1.SendEmail.exe""
                                    </script>");

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Invalid username or password");
                    Console.ResetColor();
                }
               

            }
        }
    }
}
