using System;

namespace Rover
{
    public enum Directions
    {
        North = 0,
        East = 1,
        South = 2,
        West = 3
    }

    public static class DirectionEnumHelper
    {
        public const int NUM_OF_DIRECTIONS = 4;
        public const int NORTH = 0;
        public const int EAST = 1;
        public const int SOUTH = 2;
        public const int WEST = 3;

        public static int Length()
        {
            return Enum.GetNames(typeof(Directions)).Length;
        }

        public static Directions ToEnum(int direction)
        {
            return (Directions)Enum.ToObject(typeof(Directions), direction);
        }

        public static int ToInt(Directions direction)
        {
            return (int)direction;
        }

        public static string ToString(Directions direction)
        {
            switch (direction)
            {
                case Directions.North:
                    return "North";

                case Directions.East:
                    return "East";

                case Directions.South:
                    return "South";

                case Directions.West:
                    return "West";

                default:
                    return null;
            }
        }
    }
}