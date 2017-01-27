namespace Calculator
{
    using System;
    using System.IO;
    using System.Net;

    class Program
    {
        static void Main(string[] args)
        {
            string calculatorHtml =
              File.ReadAllText(
                  @"D:\xampp\cgi-bin\Calculator.html");
            Console.Write("Content-Type: text/html image/jpeg \n\n");
            Console.Write(calculatorHtml);
            string postContent = Console.ReadLine();
            // string postContent = @"firstOperand=1.1&operator=%2B&secondOperand=2.2";
            if (!string.IsNullOrEmpty(postContent))
            {
                string[] postFormatted = postContent.Split('&');
                double firstOperand = double.Parse(postFormatted[0].Split('=')[1]);
                double secondOperand = double.Parse(postFormatted[2].Split('=')[1]);
                char @operator = char.Parse(WebUtility.UrlDecode(postFormatted[1].Split('=')[1]));
                double result = 0;

                switch (@operator)
                {
                    case '+':
                        result = firstOperand + secondOperand;
                        break;
                    case '-':
                        result = firstOperand - secondOperand;
                        break;
                    case '*':
                        result = firstOperand * secondOperand;
                        break;
                    case ':':
                        result = firstOperand / secondOperand;
                        break;
                    default:
                        Console.WriteLine("Invalid sign");
                        return;
                }
                Console.WriteLine($"Result: {result}");
            }
        }
    }
}
