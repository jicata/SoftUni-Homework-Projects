using System;


namespace by5and7
{
    class divideBy
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            bool flag = false;
            if (n % 5 == 0 && n % 7 == 0)
            {
                flag = true;
                Console.WriteLine(flag);
            }
            else
            {
                Console.WriteLine(flag);
            }
        }
    }
}
