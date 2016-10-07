using System;


namespace bitsUp
{
    class bitsUp
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int step = int.Parse(Console.ReadLine());
            int nextStep = step+1;
            
            int[] theNumbers = new int[n];
            int pos1 = 0;
            int bit1 = 0;
            int mask1 = 0;
            int count = 0;

            for (int i = 0; i < n; i++)
            {
                theNumbers[i] = int.Parse(Console.ReadLine());
                
            }
            //for (int i = 0; i < n; i++)
            //{
            //    Console.WriteLine(Convert.ToString(theNumbers[i], 2).PadLeft(8, '0')); 
            //}
          
            for (int i = 0; i < theNumbers.Length; i++)
            {
                for (int j = 7; j >= 0; j--)
                {

                   
                    if(count ==1 )
                    {
                        
                        bit1 = 1 << j;
                        mask1 = bit1 | mask1;
                        //Console.WriteLine(Convert.ToString(mask1, 2).PadLeft(8, '0'));
                        
                        
                       
                    }
                    
                    else if (count == nextStep)
                    {
                        bit1 = 1 << j;
                        mask1 = bit1 | mask1;
                        nextStep += step;
                       // Console.WriteLine(Convert.ToString(mask1, 2).PadLeft(8, '0'));

                    }
                    
                    count++;
                   
                  

                }
                
                theNumbers[i] = theNumbers[i] | mask1;
             //   Console.WriteLine(Convert.ToString(theNumbers[i], 2).PadLeft(8, '0'));
                
                mask1 = 0;
                bit1 = 0;
               //Console.WriteLine(theNumbers[i]);
            }
            for (int i = 0; i < theNumbers.Length; i++)
            {
                Console.WriteLine(theNumbers[i]);
            }
        }
    }
}
