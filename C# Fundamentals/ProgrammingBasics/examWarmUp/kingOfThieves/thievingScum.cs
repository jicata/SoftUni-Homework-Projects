using System;

namespace kingOfThieves
{
    class thievingScum
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            char type = (char)Console.Read();
            int center = size/ 2;
            int start = center;
            int end = center;
            int counter = 0;
            

            for (int i = 0; i < size; i++)
			{
			      for (int j  = 0; j  < size; j ++)
			     {
			           if (i == 0 && j == center)
                       {
                           Console.Write(type);
                       }
                       
                       else if( i > 0 &&(j >= start - counter && j <= end + counter))
                       {
                           Console.Write(type);
                       } 

                       else
                       {
                           Console.Write("-");
                       }
                       
			     }
                if (i < size/2)
                {
                    counter++;
                }
                else
                {
                    counter--;
                }
                  
              Console.WriteLine();
			}

           
                    
               
               
                
                
            
        }
    }
}
