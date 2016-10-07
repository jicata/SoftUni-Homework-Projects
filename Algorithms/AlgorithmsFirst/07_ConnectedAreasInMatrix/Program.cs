namespace _07_ConnectedAreasInMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static List<int[]> entryCoordinates = new List<int[]>();
        //static char[,] matrix = new char[4, 9]
        //   {
        //        {' ', ' ', ' ', '*', ' ', ' ', ' ', '*', ' '},
        //        {' ', ' ', ' ', '*', ' ', ' ', ' ', '*', ' '},
        //        {' ', ' ', ' ', '*', ' ', ' ', ' ', '*', ' '},
        //        {' ', ' ', ' ', ' ', '*', ' ', '*', ' ', ' '}
        //   };
        static char[,] matrix = new char[5, 10]
          {
                {'*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ',' '},
                {'*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ',' '},
                {'*', ' ', ' ', '*', '*', '*', '*', '*', ' ',' '},
                {'*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ',' '},
                {'*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ',' '}
          };

        private static int counter = 0;

        static void Main()
        {
           
            while (true)
            {
                int[] startingCoordinates = FindEntryPoint(matrix);
                int entryRow = startingCoordinates[0];
                int entryCol = startingCoordinates[1];
                if (entryRow == -1 || entryCol == -1)
                {
                    break;
                }
                
                DiscoverArea(entryRow, entryCol);
                entryCoordinates.Add(new[] { counter,entryRow, entryCol });
                counter = 0;
            }
            var sortedAreas = entryCoordinates.OrderByDescending(x => x[0]).ThenBy(x => x[1]).ThenBy(x => x[2]);
            Console.WriteLine("Total areas found: {0}", entryCoordinates.Count);
            int count = 1;
            foreach (var coordinates in sortedAreas)
            {
                Console.WriteLine("Area #{0} at ({1},{2}), size: {3}", count, coordinates[1], coordinates[2], coordinates[0]);
                count++;
            }
            

        }

        private static void DiscoverArea(int entryRow, int entryCol)
        {
            if (!IsValid(entryRow, entryCol))
            {
                return;
            }
            if (matrix[entryRow, entryCol] != ' ')
            {
                return;
            }
            counter++;
            matrix[entryRow, entryCol] = '.';
            DiscoverArea(entryRow-1, entryCol);
            DiscoverArea(entryRow, entryCol+1);
            DiscoverArea(entryRow+1, entryCol);
            DiscoverArea(entryRow, entryCol-1);
            
        }

        private static bool IsValid(int entryRow, int entryCol)
        {
            bool validRow = entryRow >= 0 && entryRow < matrix.GetLength(0);
            bool validCol = entryCol >= 0 && entryCol < matrix.GetLength(1);
            return validRow && validCol;
        }

        private static int[] FindEntryPoint(char[,] matrix)
        {
            int[] coordinates = new int[2];
            bool foundIt = false;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == ' ')
                    {
                        coordinates[0] = row;
                        coordinates[1] = col;
                        foundIt = true;
                        break;
                    }
                }
                if (foundIt)
                {
                    break;
                }
            }
            if (!foundIt)
            {
                coordinates[0] = -1;
                coordinates[1] = -1;
            }
            return coordinates;
        }
    }
}
