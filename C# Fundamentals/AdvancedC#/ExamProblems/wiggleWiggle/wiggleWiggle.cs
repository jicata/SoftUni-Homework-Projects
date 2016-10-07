using System;


namespace wiggleWiggle
{
    class wiggleWiggle
    {
        static void Main()
        {
            string userInput = Console.ReadLine();
            string[] numbers = userInput.Split();
            long firstNum = 0;
            long secondNum = 0;
            long pos1 = 0;
            long pos2 = 0;
            long bit1 = 0;
            long bit2 = 0;
            long mask1 = 0;
            long mask2 = 0;
            int count = 0;


            for (int i = 0; i < numbers.Length -1; i+=2)
            {
                firstNum = Convert.ToInt64(numbers[i]);
                secondNum = Convert.ToInt64(numbers[i + 1]);
                for (int j = 0; j < 64; j++)
                {
                    
                    if (j == 0 || j % 2 ==  0)
                    {
                        
                        
                        pos1 = firstNum >> j;
                        Console.WriteLine(Convert.ToString(pos1, 2).PadLeft(64, '0'));
                        
                        bit1 = pos1 & 1;
                        Console.WriteLine(Convert.ToString(bit1, 2).PadLeft(64, '0'));
                        bit1 = bit1 << j;
                        Console.WriteLine(Convert.ToString(bit1, 2).PadLeft(64, '0'));
                        mask1 = bit1 | mask1;

                       
                        Console.WriteLine(Convert.ToString(mask1, 2).PadLeft(64, '0'));
                        
                        
                       
                        
                        
                        pos2 = secondNum >> j;
                        bit2 = pos2 & 1;
                        bit2 = bit2 << j;
                        
                        mask2 = mask2 | bit2;

                        bit1 = 0;
                        bit2 = 0;
                        pos1 = 0;
                        pos2 = 0;

                       

                        
                        
                    }
                    
                  
                }
                firstNum = firstNum & mask2;
                secondNum = secondNum & mask1; 
            }

            Console.WriteLine(Convert.ToString(firstNum, 2).PadLeft(64, '0'));
            Console.WriteLine(Convert.ToString(secondNum, 2).PadLeft(64, '0'));
            Console.WriteLine(firstNum);
            Console.WriteLine(secondNum);
        }
    }
}
