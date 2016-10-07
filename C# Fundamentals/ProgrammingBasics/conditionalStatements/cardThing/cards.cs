using System;


namespace cardThing
{
    class cards
    {
        static void Main()
        {
            
            string thing = Console.ReadLine();
            string J = "J";
            string Q = "Q";
            string K = "K";
            string A = "A";
            int cardNumber = 0;
            bool daVidim =  int.TryParse(thing, out cardNumber);
            int[] nums = new int[12];
            for (int i = 2; i <= 10; i++)
            {
                nums[i] = i;
            }
           
                
                if (thing == J || thing == Q || thing == K || thing == A)
                {
                    Console.WriteLine("yes");
                    return;
                }
                else if (daVidim == true)
                {
                    if (nums[cardNumber] == cardNumber)
                 {
                     Console.WriteLine("yes");
                     return;
                 }
                    else if (nums[cardNumber] > nums[12])
                    {
                        Console.WriteLine("no");
                    }

                }
                
                else
                {
                    Console.WriteLine("no");
                    
                }
            
            
        }
    }
}
