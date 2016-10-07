using System;


namespace buildingBlocks
{
    class buildingBlox
    {
        static void Main()
        {
            
            double h = double.Parse(Console.ReadLine());

           
            int[] funkyArray = new int[10];
            for (int i = 0; i < funkyArray.Length; i++)
			{
                
			 funkyArray[i] = int.Parse(Console.ReadLine());
			}

            for (int j = 0; j < funkyArray.Length - 1; j+=2)
            {
                bool isInsideLowerRekt = ((funkyArray[j] >= 0) && (funkyArray[j] <= 3*h))&& ((funkyArray[j+1] >= 0) && (funkyArray[j+1] <= h));
                bool isInsideUpperRekt = ((funkyArray[j] >= h) && (funkyArray[j] <=h*2)) &&((funkyArray[j+1] >= h) && (funkyArray[j+1] <= h*4));
                if (isInsideLowerRekt || isInsideUpperRekt)
                {
                    Console.WriteLine("inside");
                }
                else
                {
                    Console.WriteLine("outside");
                }

            }
            
        }
    }
}
