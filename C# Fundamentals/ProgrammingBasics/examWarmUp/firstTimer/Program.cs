using System;

class Penis
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int weight = 3 * n;
        int topDots = weight/3;

        int medDots  = n/2 + 1;
        int nextDots = topDots - 1;

        int fuckDots = n /2;
        int shitDots = n + n/2 -1;

        int fuckStars = n + 2;

        Console.Write(new string ('.', topDots));
        Console.Write(new string('*', n));
        Console.WriteLine(new string('.', topDots));

        Console.Write(new string('.', topDots));
        Console.Write('*');
        Console.Write(new string('.', topDots - 2));
        Console.Write('*');
        Console.WriteLine(new string('.', topDots));

        Console.Write(new string('.', nextDots));
        Console.Write('*');
        Console.Write(new string('.', fuckDots));
        Console.Write('*');
        Console.Write(new string('.', fuckDots));
        Console.Write('*');
        Console.WriteLine(new string('.', nextDots));

        Console.Write(new string ('.', nextDots));
        Console.Write(new string ('*', fuckStars));
        Console.WriteLine(new string('.', nextDots));
   
        for (int i = 0; i < nextDots; i++)
        {
            Console.Write(new string('.', nextDots));
            Console.Write('*');
            Console.Write(new string ('.',n));
            Console.Write('*');
            Console.WriteLine(new string('.', nextDots));
        }
        for (int i = 0; i < nextDots; i++)
        {
            Console.Write(new string('.', nextDots));
            Console.Write('*');
            Console.Write(new string('.', n));
            Console.Write('*');
            Console.WriteLine(new string('.', nextDots));
        }

        Console.WriteLine(new string('*', weight));


        for (int i = 0; i < nextDots; i++)
        {


            Console.Write('*');
            Console.Write(new string('.', shitDots));
            Console.Write('*');
            Console.Write(new string('.', shitDots));
            Console.WriteLine('*');

        }

        Console.WriteLine(new string('*', weight));
    }
}
