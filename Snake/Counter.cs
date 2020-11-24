using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class Counter
    {
        private int count;

        public Counter()
        {
            count = 0;
        }

        public int GetCount()
        {
            return count;
        }

        public void IncreaseCount()
        {
            count++;
        }
    }
}
