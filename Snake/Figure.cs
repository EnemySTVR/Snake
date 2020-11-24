using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class Figure
    {
        protected List<Point> pointList;

        public bool IsHit(Figure figure)
        {
            foreach (var point in pointList)
            {
                if (figure.IsHit(point))
                {
                    return true;
                }
            }
            return false;
        }

        private bool IsHit(Point p)
        {
            foreach (var point in pointList)
            {
                if (point.IsHit(p))
                {
                    return true;
                }
            }
            return false;
        }
        public void Drow()
        {
            foreach (var point in pointList)
            {
                point.Drow();
            }
        }
    }
}
