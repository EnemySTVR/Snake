using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake
{
    class Snake : Figure
    {
        private Direction direction;
        public Snake(Point tail, int length, Direction direction)
        {
            this.direction = direction;
            pointList = new List<Point>();
            for (int i = 0; i < length; i++)
            {
                Point p = new Point(tail);
                p.Move(i, direction);
                pointList.Add(p);
            }
        }

        public bool Eat(Point food)
        {
            Point head = GetNextPoint();
            if (head.IsHit(food))
            {
                food.Clear();
                food = head;
                food.Draw();
                pointList.Add(food);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsHitTail()
        {
            var head = pointList.Last();
            for (int i = 0; i < pointList.Count - 2; i++)
            {
                if (head.IsHit(pointList[i]))
                {
                    return true;
                }
            }
            return false;
        }

        public void ChangeDirection(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    direction = Direction.Left;
                    break;
                case ConsoleKey.RightArrow:
                    direction = Direction.Right;
                    break;
                case ConsoleKey.UpArrow:
                    direction = Direction.Up;
                    break;
                case ConsoleKey.DownArrow:
                    direction = Direction.Down;
                    break;
                default:
                    break;
            }
        }

        public void Move()
        {
            var tail = pointList.First();
            pointList.Remove(tail);
            var head = GetNextPoint();
            pointList.Add(head);

            tail.Clear();
            head.Draw();
        }

        private Point GetNextPoint()
        {
            var head = pointList.Last();
            var nextPoint = new Point(head);
            nextPoint.Move(1, direction);
            return nextPoint;
        }
    }
}
