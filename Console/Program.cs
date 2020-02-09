using System;

namespace Rover
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var commander = new Commander();
            int? roverId = null;
            string commands = null;
            while (true)
            {
                while (commander.GetMap() == null)
                {
                    CreateMap(commander);
                }

                while (roverId.HasValue == false)
                {
                    roverId = CreateRover(commander);
                }

                while (commands == null)
                {
                    commands = SetCommands(roverId.Value);
                }

                ExecuteCommands(commander, roverId.Value, commands);
                //reset
                roverId = null;
                commands = null;
            }
        }

        private static bool CreateMap(Commander commander)
        {
            Console.WriteLine("Enter Graph Upper Right Coordinate:");
            var coordinates = Console.ReadLine().Split(' ');
            if (coordinates.Length < 2)
            {
                PrintError("Coordinate needs to be a space delimited list of two positive numbers");
                return false;
            }
            int x, y;
            if (int.TryParse(coordinates[0], out x) == false)
            {
                PrintError("X Coordinate in not valid");
                return false;
            };

            if (int.TryParse(coordinates[1], out y) == false)
            {
                PrintError("Y Coordinate in not valid");
                return false;
            };
            commander.CreateMap(x, y);
            PrintDivider();
            return true;
        }

        private static int? CreateRover(Commander commander)
        {
            Console.WriteLine($"Rover {commander.NextRoverId()} Starting Position:");

            var position = Console.ReadLine().ToUpper().Split(' ');
            if (position.Length < 3)
            {
                PrintError(@"Position needs to be a space delimited list of two positive numbers and a direction (N, E, S, W)");
                return null;
            }

            int x, y;
            if (int.TryParse(position[0], out x) == false)
            {
                PrintError("X Coordinate is not valid");
                return null;
            };
            if (int.TryParse(position[1], out y) == false)
            {
                PrintError("Y Coordinate is not valid");
                return null;
            };
            if (commander.GetMap().IsInBoundary(x, y) == false)
            {
                PrintError("Position is out of map boundary");
                return null;
            }

            var direction = DirectionEnumHelper.ToEnum(position[2]);
            if (!direction.HasValue)
            {
                PrintError("Direction is not valid.");
                return null;
            }

            var roverId = commander.CreateRover(x, y, direction.Value);
            if (roverId.HasValue == false)
            {
                PrintError(commander.GetLastError());
            }
            return roverId;
        }

        private static string SetCommands(int roverId)
        {
            Console.WriteLine($"Rover {roverId} Movement Plan:");
            var commands = Console.ReadLine().ToUpper();

            string error = null;
            if (Commander.IsValidCommand(commands, out error) == false)
            {
                PrintError(error);
                return null;
            }
            return commands;
        }

        private static void ExecuteCommands(Commander commander, int roverId, string commands)
        {
            var success = commander.MoveRover(roverId, commands);
            if (success == false)
            {
                PrintError(commander.GetLastError());
            }
            Console.WriteLine($"Rover {roverId} Output:");
            Console.WriteLine($"{commander.Output(roverId)}");
            PrintDivider();
        }

        private static void PrintError(string errorMessage)
        {
            Console.WriteLine($"Error: {errorMessage}");
        }

        private static void PrintDivider()
        {
            Console.WriteLine($"_________________________________");
        }
    }
}