using System;
using System.Threading;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            ShowCounter(count);
            Console.SetWindowSize(80, 26);
            Console.CursorVisible = false;

            var walls = new Walls(80, 25);
            walls.Drow();

            var startPoint = new Point(5, 5, '*');

            var snake = new Snake(startPoint, 4, Direction.Right);
            snake.Drow();

            var foodCreator = new FoodCreator(80, 25, '$');
            var food = foodCreator.CreateFood();
            food.Drow();

            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                {
                    break;
                }
                if (snake.Eat(food))
                {
                    count++;
                    ChangeCounter(count);
                    food = foodCreator.CreateFood();
                    food.Drow();
                }
                else
                {
                    snake.Move();
                }

                Thread.Sleep(100);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    snake.ChangeDirection(keyInfo.Key);
                }
            }

            Console.Clear();
            Console.WriteLine("Game Over!");
        }


        static void ChangeCounter(int count)
        {
            ClearCounterRow();
            ShowCounter(count);
        }
        static void ShowCounter(int count)
        {
            Console.SetCursorPosition(0, 25);
            Console.Write($"Count: {count}");
        }
        static void ClearCounterRow()
        {
            Console.SetCursorPosition(0, 25);
            for (int i = 0; i < 80; i++)
            {
                Console.Write(' ');
            }
        }
    }
}
