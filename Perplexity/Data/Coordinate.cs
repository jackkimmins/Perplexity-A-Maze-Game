using System;

namespace Perplexity
{
    public class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinate(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public void Output()
        {
            Console.WriteLine("X: " + this.X + " Y: " + this.Y);
        }
    }
}
