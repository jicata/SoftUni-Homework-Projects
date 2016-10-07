using System;


namespace bitsAtXroads
{
    class xRoadBits
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            string[] oneDeArray = new string[size];
            string zero = "0";
            string rawInput = "";
            string letMeUseThis = "";
            long xRoad = 0;
            long initialBit = 0;
            long bit1 = 0;
            long bit2 = 0;
            long mask1 = 0;
            long mask2 = 0;
            long xRoadCheck = 0;
            long xRoadTrueOrNot = 0;
            long count = 0;

            for (int i = 0; i < size; i++)
            {
                oneDeArray[i] = zero;
                
            }
            long[] numbers = Array.ConvertAll(oneDeArray, long.Parse);
            while (rawInput != "end")
            {
                rawInput = Console.ReadLine();
                if (rawInput == "end" || string.IsNullOrWhiteSpace(rawInput))
                {
                    continue;
                }
                else
                {
                    if (rawInput != letMeUseThis)
                    {
                        count++;
                    }
                    letMeUseThis = rawInput;
                    string[] coordinates = letMeUseThis.Split();
                    int[] actualCoordinates = Array.ConvertAll(coordinates, int.Parse);
                    int row = actualCoordinates[0];
                    int shiftLeft = actualCoordinates[1];
                    int shiftRight = actualCoordinates[1];

                    initialBit = 1 << shiftLeft;
                    xRoad = numbers[row] | initialBit;
                    numbers[row] = numbers[row] | xRoad;
                    if (row >= 0 && shiftLeft <= size && shiftRight >= 0)
                    {
                        row--;
                        shiftLeft++;
                        shiftRight--;
                    }

                    while (row >= 0)
                    {
                        if (shiftLeft < size)
                        {
                            xRoadCheck = numbers[row] >> shiftLeft;
                            xRoadTrueOrNot = xRoadCheck & 1;
                            if (xRoadTrueOrNot > 0)
                            {
                                count++;
                                xRoadTrueOrNot = 0;
                            }
                            bit1 = 1 << shiftLeft;
                            mask1 = bit1 | numbers[row];
                            numbers[row] = numbers[row] | mask1;
                        }
                        if (shiftRight >= 0)
                        {
                            xRoadCheck = numbers[row] >> shiftRight;
                            xRoadTrueOrNot = xRoadCheck & 1;
                            if (xRoadTrueOrNot > 0)
                            {
                                count++;
                                xRoadTrueOrNot = 0;
                            }
                            bit2 = 1 << shiftRight;
                            mask2 = bit2 | numbers[row];
                            numbers[row] = numbers[row] | mask2;
                        }


                        row--;
                        shiftLeft++;
                        shiftRight--;



                    }

                    row = actualCoordinates[0];
                    shiftLeft = actualCoordinates[1];
                    shiftRight = actualCoordinates[1];
                    if (row <= size && shiftLeft <= size && shiftRight >= 0)
                    {
                        row++;
                        shiftLeft++;
                        shiftRight--;
                    }
                    while (row < size)
                    {
                        if (shiftLeft < size)
                        {
                            xRoadCheck = numbers[row] >> shiftLeft;
                            xRoadTrueOrNot = xRoadCheck & 1;
                            if (xRoadTrueOrNot > 0)
                            {
                                count++;
                                xRoadTrueOrNot = 0;
                            }
                            bit1 = 1 << shiftLeft;
                            mask1 = bit1 | numbers[row];
                            numbers[row] = numbers[row] | mask1;

                        }

                        if (shiftRight >= 0)
                        {
                            xRoadCheck = numbers[row] >> shiftRight;
                            xRoadTrueOrNot = xRoadCheck & 1;
                            if (xRoadTrueOrNot > 0)
                            {
                                count++;
                                xRoadTrueOrNot = 0;
                            }
                            bit2 = 1 << shiftRight;
                            mask2 = bit2 | numbers[row];
                            numbers[row] = numbers[row] | mask2;
                        }




                        row++;
                        shiftLeft++;
                        shiftRight--;


                    }
                }




            }
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine((uint)numbers[i]);
              
            }
            Console.WriteLine(count);
           

        }
    }
}
