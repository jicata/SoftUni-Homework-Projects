namespace _04_HanoiTower
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static int stepsTaken = 0;
        private static Stack<int> source;
        static Stack<int> spare = new Stack<int>();
        static Stack<int> destination = new Stack<int>();
        static void Main()
        {
            int numeberOfDisks = int.Parse(Console.ReadLine());
            var range = Enumerable.Range(1, numeberOfDisks);
            source = new Stack<int>(range.Reverse());           
            MoveDisks(numeberOfDisks, source, spare, destination);
        }

        private static void MoveDisks(int bottomDisk, Stack<int> source, Stack<int> spare, Stack<int> destination)
        {
            if (bottomDisk == 1)
            {
                stepsTaken++;
                destination.Push(source.Pop());
                Console.WriteLine("Step {0}: Moved disk {1}",stepsTaken, bottomDisk );
                PrintRods();
            }
            else
            {
                MoveDisks(bottomDisk-1, source,destination,spare);

                stepsTaken++;
                destination.Push(source.Pop());
                Console.WriteLine("Step {0}: Moved disk {1}", stepsTaken, bottomDisk);
                PrintRods();

                MoveDisks(bottomDisk-1,spare,source,destination);
            }
        }

        private static void PrintRods()
        {
            Console.WriteLine("Source {0}", string.Join(", ", source.Reverse()));
            Console.WriteLine("Destination {0}", string.Join(", ", destination.Reverse()));
            Console.WriteLine("Spare {0}", string.Join(", ", spare.Reverse()));
            Console.WriteLine();
        }
    }
}
