using System;

namespace Rover
{
    public class Map
    {
        public const int minX = 0;
        public const int minY = 0;
        public readonly int maxX;
        public readonly int maxY;

        public Map(int maxX = 0, int maxY = 0)
        {
            this.maxX = Math.Max(maxX, 0);
            this.maxY = Math.Max(maxY, 0);
        }

        public bool IsInBoundary(int x, int y)
        {
            return minX <= x && x <= maxX
                && minY <= y && y <= maxY;
        }
    }
}