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

        public static int Count()
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

        public static Directions? FromString(string str)
        {
            str = str.ToUpper();
            switch (str)
            {
                case "N":
                    return Directions.North;

                case "E":
                    return Directions.East;

                case "S":
                    return Directions.South;

                case "W":
                    return Directions.West;

                default:
                    return null;
            }
        }

        public static string ToString(Directions direction)
        {
            switch (direction)
            {
                case Directions.North:
                    return "N";

                case Directions.East:
                    return "E";

                case Directions.South:
                    return "S";

                case Directions.West:
                    return "W";

                default:
                    return null;
            }
        }
    }
}