using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class Point
    {
        private int x;
        private int y;
        private char sym;

        public Point(int x, int y, char sym)
        {
            this.x = x;
            this.y = y;
            this.sym = sym;

        }

        public Point(Point p)
        {
            x = p.x;
            y = p.y;
            sym = p.sym;

        }

        public void Move(int step, Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    x = x - step;
                    break;
                case Direction.Right:
                    x = x + step;
                    break;
                case Direction.Up:
                    y = y - step;
                    break;
                case Direction.Down:
                    y = y + step;
                    break;
            }
        }

        internal bool IsHit(Point point)
        {
            return point.x == x && point.y == y;
        }

        public void Clear()
        {
            sym = ' ';
            Drow();
        }

        public void Drow()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sym);
        }
    }
}
