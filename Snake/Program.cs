using System;
using System.Threading;

namespace Snake
{
    class Program
    {
        static void Main()
        {
            int test = 0;
            
            Console.SetWindowSize(80, 26);
            Console.CursorVisible = false;

            var walls = new Walls(80, 25);
            walls.Draw();

            var startPoint = new Point(5, 5, '*');

            var snake = new Snake(startPoint, 4, Direction.Right);
            snake.Draw();

            ShowCounter(snake.GetCount());

            var foodCreator = new FoodCreator(80, 25, '$');
            var food = foodCreator.CreateFood();
            food.Draw();

            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                {
                    break;
                }
                if (snake.Eat(food))
                {
                    ChangeCounter(snake.GetCount());
                    food = foodCreator.CreateFood();
                    food.Draw();
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
            ShowGameOverMessage();
            Console.ReadKey();
        }

        static void ShowGameOverMessage()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.SetCursorPosition(35, 13);
            Console.Write("Game Over!");

            Console.ResetColor();
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
