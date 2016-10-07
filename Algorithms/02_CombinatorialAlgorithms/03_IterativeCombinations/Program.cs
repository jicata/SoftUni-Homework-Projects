namespace _03_IterativeCombinations
{
    using System;

    class Program
    {
        static void Main()
        {
            int arrayLength = int.Parse(Console.ReadLine());
            int numberOfElements = int.Parse(Console.ReadLine());
            char[] arrayGay = new char[arrayLength];
            for (int i = 0; i < arrayLength; i++)
            {
                arrayGay[i] = Char.Parse((i+1).ToString());
            }
            generate_combos(arrayGay, numberOfElements);
        }

        public static void generate_combos(char[] root, int length)
        {
            // allocate an int array to hold the counts:
            int[] pos = new int[length];
            // allocate a char array to hold the current combination:
            char[] combo = new char[length];
            // initialize to the first value:
            for (int i = 0; i < length; i++)
            {
                combo[i] = root[0];
            }

            while (true)
            {
                // output the current combination:
                Console.WriteLine(string.Join(" ", combo));

                // move on to the next combination:
                int place = length - 1;
                while (place >= 0)
                {
                    int wtfIsThisValue = ++pos[place];
                    if (wtfIsThisValue == root.Length)
                    {
                        // overflow, reset to zero
                        pos[place] = 0;
                        combo[place] = root[0];
                        place--; // and carry across to the next value
                    }
                    else
                    {
                        // no overflow, just set the char value and we're done
                        combo[place] = root[pos[place]];
                        break;
                    }
                }
                if (place < 0)
                    break;  // overflowed the last position, no more combinations
            }
        }
    }
}
