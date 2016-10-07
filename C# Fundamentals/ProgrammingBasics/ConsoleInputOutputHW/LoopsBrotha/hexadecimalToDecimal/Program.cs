using System;


namespace hexadecimalToDecimal
{
    class Program
    {
        static void Main()
        {
            string hex = Console.ReadLine();

            int num = 0;
            long hexNum = 0;
            long degree = hex.Length - 1;

            for (int i = 0; i < hex.Length; i++)
            {
                char ch = hex[i];
                
                switch (ch.ToString())
                {
                    case "A": num = 10;
                    break;
                    case "B": num = 11;
                    break;
                    case "C": num = 12;
                    break;
                    case "D": num = 13;
                    break;
                    case "E": num = 14;
                    break;
                    case "F": num = 15;
                    break;
                    default: num = int.Parse(ch.ToString());
                    break;

                }
                hexNum += num * (long)Math.Pow(16, degree);
                    degree--;
            }
            Console.WriteLine(hexNum);
        }
    }
}
