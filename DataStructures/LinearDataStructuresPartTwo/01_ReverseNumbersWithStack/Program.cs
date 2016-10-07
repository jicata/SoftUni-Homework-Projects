namespace _01_ReverseNumbersWithStack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input))
            {
                int[] numbers = input.Split().Select(x => int.Parse(x)).ToArray();
                Stack<int> myStack = new Stack<int>();
                for (int i = 0; i < numbers.Length; i++)
                {
                    myStack.Push(numbers[i]);
                }
                while (myStack.Count > 0)
                {
                    Console.Write(myStack.Pop() + " ");
                } 
            }
            Console.WriteLine();
        }
    }
}
