using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace snakeTest
{
    struct Position
    {
        public int row;
        public int col;
        public Position(int row, int col)
        {
            this.row = row;
            this.col = col;
        }
    }
    class telerikSnake
    {
        static void Main(string[] args)
        {
            byte right = 0;
            byte left = 1;
            byte down = 2;
            byte up = 3;

            Position[] directions = new Position[]
            {
                new Position (0, 1), //right
                new Position (0, -1), //left
                new Position (1, 0), //down
                new Position (-1, 0), //up

            };
            int sleepTime = 100;
            int direction = right; // 0?
            int lastFoodTime = 0;
            int foodDissapearTime = 8000;
            int negativePoints = 0;

            
            
            //obstacles
            List<Position> obstacles = new List<Position>()
            {
                new Position(12,12),
                new Position(14,20),
                new Position(7,7),
            };
            foreach (Position obstacle in obstacles)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition(obstacle.col, obstacle.row);
                Console.Write("==");
            }
            //obstacles

            //food generator
            Random randomNumbersGenerator = new Random();
            Console.BufferHeight = Console.WindowHeight;
            Position food = new Position();
            do
            {
                food = new Position(randomNumbersGenerator.Next(0, Console.WindowHeight), randomNumbersGenerator.Next(0, Console.WindowWidth));
                Console.SetCursorPosition(food.col, food.row);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("@");
            }
            while (obstacles.Contains(food));
            lastFoodTime = Environment.TickCount;
            //food generator


            //snake generator
            Queue<Position> snakeElements = new Queue<Position>();
            for (int i = 0; i < 5; i++)
            {
                snakeElements.Enqueue(new Position(0, i));
            }

            foreach (Position position in snakeElements)
            {
                Console.SetCursorPosition(position.col, position.row);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("*");
            }
            //snake generator
            
            while (true)
            {
                //directed movement
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo userInput = Console.ReadKey();
                    if (userInput.Key == ConsoleKey.RightArrow)
                    {
                        if (direction != left) direction = right;
                    }
                    if (userInput.Key == ConsoleKey.LeftArrow)
                    {
                        if (direction != right) direction = left;
                    }
                    if (userInput.Key == ConsoleKey.DownArrow)
                    {
                         if (direction !=up) direction = down;
                    }
                    if (userInput.Key == ConsoleKey.UpArrow)
                    {
                         if (direction != down) direction = up;
                    }
                }
                //directed movement

                //head generator + bounds/game over
                Position snakeHead = snakeElements.Last();
                Position nextDirection = directions[direction];
                Position snakeNewHead = new Position(snakeHead.row + nextDirection.row, snakeHead.col + nextDirection.col);

                if (snakeNewHead.col < 0) snakeNewHead.col = Console.WindowWidth - 1;
                if (snakeNewHead.row < 0) snakeNewHead.row = Console.WindowHeight - 1;
                if (snakeNewHead.col >= Console.WindowWidth) snakeNewHead.col = 0;
                if (snakeNewHead.row >= Console.WindowHeight) snakeNewHead.row = 0;
                
                
                
                if (snakeElements.Contains(snakeNewHead) || obstacles.Contains(snakeNewHead))
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(0,0);
                    Console.WriteLine("Game Over!");
                    Console.WriteLine("Your points are: {0}", (snakeElements.Count - 5) *100 - negativePoints);
                    return;
                }
                Console.SetCursorPosition(snakeHead.col, snakeHead.row);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("*");
                    
               
                snakeElements.Enqueue(snakeNewHead);
                Console.SetCursorPosition(snakeNewHead.col, snakeNewHead.row);
                Console.ForegroundColor = ConsoleColor.Green;
                if (direction == right) Console.Write(">");
                if (direction == left) Console.Write("<");
                if (direction == up) Console.Write("^");
                if (direction == down) Console.Write("v");
                //head generator + bounds

                
                //spawn and eat food
                if (snakeNewHead.col == food.col && snakeNewHead.row == food.row)
                {
                    // feed
                    do
                    {
                        food = new Position(randomNumbersGenerator.Next(0, Console.WindowHeight), randomNumbersGenerator.Next(0, Console.WindowWidth));

                    }
                    while (snakeElements.Contains(food) || obstacles.Contains(food));
                    sleepTime--;
                    
                    Console.SetCursorPosition(food.col, food.row);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("@");
                    lastFoodTime = Environment.TickCount;

                    Position obstacle = new Position();
                    do
                    {
                        obstacle = new Position(randomNumbersGenerator.Next(0, Console.WindowHeight), randomNumbersGenerator.Next(0, Console.WindowWidth));
                    }
                    while (snakeElements.Contains(obstacle) || obstacles.Contains(obstacle) || (food.col != obstacle.col && food.row != obstacle.row));
                    obstacles.Add(obstacle);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition(obstacle.col, obstacle.row);
                    Console.Write("==");
                }
                else
                {
                    //move
                    Position last = snakeElements.Dequeue();
                    Console.SetCursorPosition(last.col, last.row);
                    Console.Write(" ");
                }
                if (Environment.TickCount - lastFoodTime >= foodDissapearTime)
                {
                    negativePoints = negativePoints + 50;
                    Console.SetCursorPosition(food.col, food.row);
                    Console.Write(" ");
                    do
                    {
                        food = new Position(randomNumbersGenerator.Next(0, Console.WindowHeight), randomNumbersGenerator.Next(0, Console.WindowWidth));

                    }
                    while (snakeElements.Contains(food));
                 

                    Console.SetCursorPosition(food.col, food.row);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("@");
                    lastFoodTime = Environment.TickCount;
                }
                //spawn and eat food
                
                
                
             

               
                Thread.Sleep(sleepTime);
            }
        }
    }
}
