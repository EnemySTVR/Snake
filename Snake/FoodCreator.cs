﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class FoodCreator
    {
        readonly int mapWidth;
        readonly int mapHeight;
        readonly char sym;
        readonly Random rnd = new Random();

        public FoodCreator(int mapWidth, int mapHeight, char sym)
        {
            this.mapWidth = mapWidth;
            this.mapHeight = mapHeight;
            this.sym = sym;
        }

        public Point CreateFood()
        {
            int x = rnd.Next(2, mapWidth - 2);
            int y = rnd.Next(2, mapHeight - 2);
            return new Point(x, y, sym);
        }
    }
}
