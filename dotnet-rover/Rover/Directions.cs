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
        public static int Count()
        {
            return Enum.GetNames(typeof(Directions)).Length;
        }

        public static Directions? ToEnum(int direction)
        {
            if (direction >= Count()) return null;
            return (Directions)Enum.ToObject(typeof(Directions), direction);
        }

        public static Directions? ToEnum(string str)
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

        public static int ToInt(Directions direction)
        {
            return (int)direction;
        }

        public static string ToString(Directions direction)
        {
            return direction.ToString().Substring(0, 1);
        }
    }
}