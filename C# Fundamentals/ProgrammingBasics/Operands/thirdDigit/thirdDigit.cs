using System;

namespace thirdDigit
{
    class thirdDigit
    {
        static void Main()
        {
            string[] penis = Console.ReadLine().Split();
            int[] n = Array.ConvertAll(penis, element => int.Parse(element));
            bool flag = false;
            int isItSeven = n.Length - 3;
            
                if (n[isItSeven] == 7)
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
