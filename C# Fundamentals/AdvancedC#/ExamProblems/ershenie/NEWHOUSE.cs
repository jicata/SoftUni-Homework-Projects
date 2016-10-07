using System;

class Sunglasses
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

         //foundations + fill
        string fill = new string('*', n - 2);
        string foundations = string.Format("{0}{1}{0}", '|', fill);
        //foundations + fill
        
        //roof
        int i = 0;
        for (i=1; i<=n; i+=2)
        {
            string roofie = new string('*', i);
            string underScore = new string('-', (n - roofie.Length)/2);
            string roof = string.Format("{0}{1}{0}", underScore, roofie);
            Console.WriteLine(roof);
         
        }
        //roof
        for (int y = 1; y<=n; y++)
        {
            Console.WriteLine(foundations);
        }
        
        





    }
}