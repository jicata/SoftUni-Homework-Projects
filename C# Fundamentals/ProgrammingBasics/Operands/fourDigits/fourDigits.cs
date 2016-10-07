using System;

namespace fourDigits
{
    class fourDigits
    {
        static void Main()
        {
            

            int number = int.Parse(Console.ReadLine());
            int sum = 0;
            int[] coolArray = new int[4];
            



            
            coolArray[0] = (number / 1000) % 10;
            coolArray[1] = (number / 100) % 10;
            coolArray[2] = (number / 10) % 10;
            coolArray[3] = number % 10;
            for (int i = 0; i<coolArray.Length; i++)
            {
                sum += coolArray[i];

            }
            int[] clone = (int[])coolArray.Clone();
            int[] clone1 = (int[])coolArray.Clone();
            //sum
            Console.WriteLine(sum);
            //sum

            //last -> first
            int tempSpot = clone[0];
            clone[0] = clone[3];
            clone[3] = tempSpot;
            Console.Write(clone[0]);
            Console.Write(clone[1]);
            Console.Write(clone[2]);
            Console.WriteLine(clone[3]);
           
            //last -> first
          

            //seoncd -> third
            int tempSpot2 = clone1[1];
            clone1[1] = clone1[2];
            clone1[2] = tempSpot2;
            Console.Write(clone1[0]);
            Console.Write(clone1[1]);
            Console.Write(clone1[2]);
            Console.WriteLine(clone1[3]);
           
            
            //seoncd -> third
            
            Array.Reverse(coolArray);
            Console.Write(coolArray[0]);
            Console.Write(coolArray[1]);
            Console.Write(coolArray[2]);
            Console.WriteLine(coolArray[3]);
            
            

            

          
        }
    }
}
