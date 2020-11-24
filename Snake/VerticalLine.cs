using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class VerticalLine : Figure
    {
        public VerticalLine(int yTop, int yDown, int x, char sym)
        {
            pointList = new List<Point>();
            for (int y = yTop; y <= yDown; y++)
            {
                pointList.Add(new Point(x, y, sym));
            }
        }
    }
}
