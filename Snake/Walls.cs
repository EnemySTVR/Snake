using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class Walls : Figure
    {
        private readonly List<Figure> wallList;
        public Walls(int xLength, int yLength)
        {
            wallList = new List<Figure>();
            var leftLine = new VerticalLine(0, yLength - 1, 0, '+');
            var rightLine = new VerticalLine(0, yLength - 1, xLength - 2, '+');
            var topLine = new HorizontalLine(0, xLength - 2, 0, '+');
            var bottomLine = new HorizontalLine(0, xLength - 2, yLength - 1, '+');
            wallList.Add(leftLine);
            wallList.Add(rightLine);
            wallList.Add(topLine);
            wallList.Add(bottomLine);
        }

        public override bool IsHit(Figure figure)
        {
            foreach (var wall in wallList)
            {
                if (wall.IsHit(figure))
                {
                    return true;
                }
            }
            return false;
        }

        public void Draw()
        {
            foreach (var wall in wallList)
            {
                wall.Draw();
            }
        }
    }
}
