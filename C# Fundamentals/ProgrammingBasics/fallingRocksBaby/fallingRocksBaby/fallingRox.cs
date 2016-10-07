using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;

namespace fallingRocksBaby
{
     struct Object
    {
        public int x;
        public int y;
        public char c;
        public ConsoleColor color;
    }
     


    
    class fallingRox
    {
        //static void PrintMeSomethingRocky(int x, int y, char c)
        //{
        //    Random r = new Random();
        //    Console.SetCursorPosition(x, y);
        //    Console.ForegroundColor = (ConsoleColor)r.Next(0,16);
        //    Console.Write(c);

        //}

        static void PrintMeSomething(int x, int y, char c, ConsoleColor color)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(c);

        }
        static void PrintMeAString(int x, int y, string str, ConsoleColor color)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(str);

        }
        static void Main()
        {
            //Color color = Color.Blue;
            //string colorString = color.A + "," + color.R + "," + color.G + "," + color.B;
            //string[] components = colorString.Split();
            //color = Color.FromArgb(Convert.ToInt32(components[0]));
            



            Console.BufferHeight = Console.WindowHeight = 30;
            Console.BufferWidth = Console.WindowWidth = 60;
            int playfieldWidth = Console.WindowWidth - 20;
            Random rnG = new Random();
            int livesCount = 5;
            double sleepTime = 150.0;
            

            char[] randomSymbols = new char[]
            {
                '!', '@', '#',
                '%', '&',
                '^','*','+',
                '.',';'
            };
            
            
            


            Object theDwarf = new Object();
            theDwarf.x = playfieldWidth / 2;
            theDwarf.y = Console.WindowHeight - 1;
            theDwarf.c = '0';
            theDwarf.color = ConsoleColor.White;
            List<Object> rocks = new List<Object>();

            
            while (true)
            {





                sleepTime -= 0.5;

                    bool hit = false;
                    int chance = rnG.Next(0, 101);
                    if (chance <= 15)
                    {
                        Object bonus = new Object();
                        bonus.x = rnG.Next(0, playfieldWidth);
                        bonus.y = 0;
                        bonus.c = '$';
                        bonus.color = ConsoleColor.Green;
                        rocks.Add(bonus);
                    }
                    else
                    {
                        Object rock = new Object();
                        rock.x = rnG.Next(0, playfieldWidth);
                        rock.y = 0;
                        rock.c = randomSymbols[rnG.Next(1, 10)];
                        rock.color = (ConsoleColor)rnG.Next(5, 9);
                        rocks.Add(rock);
                    }
                  
                    

                    // player movement
                    while (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                        if (pressedKey.Key == ConsoleKey.LeftArrow)
                        {
                            if (theDwarf.x - 1 >= 0)
                            {
                                theDwarf.x = theDwarf.x - 1;
                            }
                        }
                        else if (pressedKey.Key == ConsoleKey.RightArrow)
                        {
                            if (theDwarf.x + 1 <= playfieldWidth)
                            {
                                theDwarf.x = theDwarf.x + 1;
                            }
                        }
                    }
                    //player movement

                    //generate the rocks
                    List<Object> newRocks = new List<Object>();

                        for (int i = 0; i < rocks.Count; i++)
                        {
                            Object oldRock = rocks[i];
                            Object newRock = new Object();
                            newRock.x = oldRock.x;
                            newRock.y = oldRock.y + 1;
                            newRock.c = oldRock.c;
                            newRock.color = oldRock.color;
                            if (newRock.y + 1 <= Console.WindowHeight)
                            {
                                newRocks.Add(newRock);
                            }
                            if (newRock.c == '$' && (newRock.x == theDwarf.x && newRock.y == theDwarf.y))
                            {
                                sleepTime+=10;
                                Console.Beep(1300, 100);

                            }
                            else if (newRock.x == theDwarf.x && newRock.y == theDwarf.y) 
                            {
                                hit = true;
                                livesCount--;
                                Console.Beep(2109, 100);
                                if (livesCount == 0)
                                {
                                    Console.SetCursorPosition(45, 5);
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write("Game Over");
                                    Console.ReadLine();
                                    Environment.Exit(0);
                                }

                            }
                        }
                        rocks = newRocks;
                    //generate the rocks
                   


                Console.Clear();
                if (hit)
                {
                    rocks.Clear();
                    PrintMeSomething(theDwarf.x, theDwarf.y, 'X', ConsoleColor.Red);
                    if (sleepTime + 60 > 150)
                    {
                        sleepTime = 150;
                    }
                    else
                    {
                        sleepTime += 60;
                    }
                    
                    
                    
                    
                }
                else 
                {
                    PrintMeSomething(theDwarf.x, theDwarf.y, theDwarf.c, theDwarf.color);
                }

                
                foreach (Object pebble in newRocks)
                {
                    PrintMeSomething(pebble.x, pebble.y, pebble.c, pebble.color);
                }
                PrintMeAString(45, 3, "Lives count: " + livesCount, ConsoleColor.White);
                PrintMeAString(45, 5, "Speed: " + sleepTime, ConsoleColor.White);

                Thread.Sleep((int)sleepTime);
            }
        }
    }
}
