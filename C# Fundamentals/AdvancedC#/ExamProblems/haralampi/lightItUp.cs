using System;


namespace haralampi
{
    class lightItUp
    {
        static void Main()
        {
            int numberOfRooms = int.Parse(Console.ReadLine());
            string lightOrDark = Console.ReadLine();
            string directions = "";
            int aide = 0;

            int count = 0;
            int count2 = 0;
            int startingPos = numberOfRooms / 2;
            int currentPos = 0;
            
            int lastPos = startingPos;

            char[] allTheRooms = new char[numberOfRooms];

            for (int i = 0; i < allTheRooms.Length; i++)
            {
                if (count >= lightOrDark.Length)
                {
                    count = 0;
                }
               
              
                    allTheRooms[i] = lightOrDark[count];
                    count++;
            }

                
                while (directions!= "END")
                {
                    
                    directions = Console.ReadLine();
                    if (directions == "END")
                    {
                        continue;
                    }
                    string[] directionAndMoves = directions.Split();
                    int[] moves = new int[1];
                    moves[0] = Convert.ToInt32(directionAndMoves[1]) + 1;
                    
                    

                    if (count2 ==0)
                    {
                        currentPos = startingPos;
                    }
                   

                    
                    if (directionAndMoves[0] == "LEFT" && currentPos - moves[0] < 0)
                    {
                        currentPos = 0;
                        if (currentPos != lastPos)
                        {
                            if (allTheRooms[currentPos] == 'L')
                            {
                                allTheRooms[currentPos] = 'D';
                            }
                            else
                            {
                                allTheRooms[currentPos] = 'L';
                            }
                        }
                        
                        
                       
                        lastPos = currentPos;

                    }
                    else if (directionAndMoves[0] == "RIGHT" && currentPos + moves[0] >= numberOfRooms)
                    {
                        currentPos = allTheRooms.Length -1;

                        if (currentPos != lastPos)
                        {
                            if (allTheRooms[currentPos] == 'L')
                            {
                                allTheRooms[currentPos] = 'D';
                            }
                            else
                            {
                                allTheRooms[currentPos] = 'L';
                            }

                        }
                        
                        lastPos = currentPos;
                    }
                    else if(directionAndMoves[0] == "LEFT" && !(currentPos - moves[0] < 0))
                    {
                        currentPos = currentPos - moves[0];
                        if (currentPos != lastPos)
                        {
                            if (allTheRooms[currentPos] == 'L')
                            {
                                allTheRooms[currentPos] = 'D';
                            }
                            else
                            {
                                allTheRooms[currentPos] = 'L';
                            }

                        }
                        
                        lastPos = currentPos;
                    }
                    else if(directionAndMoves[0] == "RIGHT"&& !(currentPos + moves[0] >= numberOfRooms))
                    {
                        currentPos = currentPos + moves[0];
                        if (currentPos != lastPos)
                        {
                            if (allTheRooms[currentPos] == 'L')
                            {
                                allTheRooms[currentPos] = 'D';
                            }
                            else
                            {
                                allTheRooms[currentPos] = 'L';
                            }
                        }
                        
                        lastPos = currentPos;
                    }



                    count2++;
                }

                foreach (var item in allTheRooms)
                {
                    if (item == 'D')
                    {
                        
                        aide++;
                    }
                }
                Console.WriteLine(aide * 'D');
           

        }
    }
}
