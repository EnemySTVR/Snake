using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class Figure
    {
        protected List<Point> pointList;

        public virtual bool IsHit(Figure figure)
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
        public void Draw()
        {
            foreach (var point in pointList)
            {
                point.Draw();
            }
        }
    }
}
