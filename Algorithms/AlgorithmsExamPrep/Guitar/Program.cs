namespace Guitar
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;

    class Program
    {
        static void Main()
        {
            int[] volumePower = Console.ReadLine().Split(',').Select(int.Parse).ToArray();
            int currentPower = int.Parse(Console.ReadLine());
            int maxPower = int.Parse(Console.ReadLine());

            bool[,] littleKnap = new bool[volumePower.Length,maxPower+1];
            if (currentPower + volumePower[0] <= maxPower)
            {
                littleKnap[0, currentPower + volumePower[0]] = true;
            }
            if (currentPower - volumePower[0] >= 0)
            {
                littleKnap[0, currentPower - volumePower[0]] = true;
            }
           // Print(littleKnap);
            
            
            //littleKnap[0, currentPower] = false;
            bool flag = false;
            for (int i = 1; i < volumePower.Length; i++)
            {
                for (int j = 0; j <= maxPower; j++)
                {
                    if (littleKnap[i - 1, j])
                    {
                        
                        if (j + volumePower[i] <= maxPower)
                        {
                            littleKnap[i, volumePower[i] + j] = true;
                            flag = true;
                        }
                        if (j - volumePower[i] >= 0)
                        {
                            littleKnap[i, j - volumePower[i]] = true;
                            flag = true;
                        }
                    }
                }
                if (!flag)
                {
                    Console.WriteLine(-1);
                    return;
                }
                flag = false;
            }

            for (int i = maxPower; i >= 0; i--)
            {
                if (littleKnap[volumePower.Length - 1, i])
                {
                    Console.WriteLine(i);
                    break;
                }
            }
        }

        static void Print(bool[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (!matrix[i, j])
                    {
                        Console.Write((j) + " ");
                    }
                    else
                    {
                        Console.Write("K");
                    }
                    
                }
                Console.WriteLine();
            }
        }
    }
}
