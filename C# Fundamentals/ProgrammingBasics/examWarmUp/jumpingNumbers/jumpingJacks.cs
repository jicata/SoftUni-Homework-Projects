using System;


namespace jumpingNumbers
{
    class jumpingJacks
    {
        static void Main()
        {
            string input = Console.ReadLine();
            int jumps = int.Parse(Console.ReadLine());

            string[] arrayOfNumbers = input.Split();
            int[] intNumbers = Array.ConvertAll(arrayOfNumbers, int.Parse);
            int maxSum = int.MinValue;
            int sum = 0;
            int currentPos = 0;
            int currentVal = 0;
            int nextJump = 0;
            bool flag = false;
            int count = 0;

            

            for (int i = 0; i < intNumbers.Length; i++)
            {
                currentPos = i;
                for (int j = 0; j <= jumps; j++)
                {
                    
                    currentVal = intNumbers[currentPos];
                    

                    nextJump = currentPos + currentVal;

                    if (nextJump >= intNumbers.Length)
                    {
                      //  nextJump = nextJump - (intNumbers.Length -1 - currentPos);
                       
                        while (nextJump > (intNumbers.Length -1))
                        {
                            nextJump = nextJump - intNumbers.Length;
                            
                           
                            
                        }
                       
                       
                    }
                       
                       
                       
                       
                    
                    currentPos = nextJump;
                    sum += currentVal;
                }
                flag = false;
                
                if(sum > maxSum)
                {
                    maxSum = sum;
                }
                sum = 0;

            }
            Console.WriteLine("max sum = {0}",maxSum);





        }
    }
}
