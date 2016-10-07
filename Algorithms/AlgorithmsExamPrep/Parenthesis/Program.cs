namespace Parenthesis
{
    using System;
    using System.CodeDom;
    using System.Collections.Generic;
    using System.Text;

    class Program
    {
        static StringBuilder sb = new StringBuilder();
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            brackets(n,0,"");
            Console.Write(sb);
        }

        static void brackets(int openStock, int closeStock, String s)
        {
            if (openStock == 0 && closeStock == 0)
            {
                sb.AppendLine(s);

            }
            if (openStock > 0)
            {
                brackets(openStock - 1, closeStock + 1, s + "(");
            }
            if (closeStock > 0)
            {
                brackets(openStock, closeStock - 1, s + ")");
            }

        }

        
    }
}
