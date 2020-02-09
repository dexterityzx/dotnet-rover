using System.Collections.Generic;

namespace Rover
{
    public class Commander
    {
        private const char TURN_LEFT = 'L';
        private const char TURN_RIGHT = 'R';
        private const char MOVE_FORWARD = 'M';

        private Dictionary<int, Rover> _rovers;
        private Map _map = null;
        private Stack<string> _errors;

        public Commander()
        {
            _rovers = new Dictionary<int, Rover>();
            _errors = new Stack<string>();
        }

        public int NextRoverId()
        {
            return _rovers.Count;
        }

        public void CreateMap(int maxX, int maxY)
        {
            _map = new Map(maxX, maxY);
        }

        public int? CreateRover(int x, int y, Directions direction)
        {
            if (_map == null)
            {
                _errors.Push("Map is null.");
                return null;
            }

            var roverId = NextRoverId();
            var rover = new Rover(_map, new RoverState(x, y, direction));
            if (rover.GetLastError() != null)
            {
                _errors.Push($"Failed to create Rover: {rover.GetLastError()}");
                return null;
            }
            _rovers.Add(roverId, rover);
            return roverId;
        }

        public Rover GetRover(int roverId)
        {
            Rover rover = null;
            _rovers.TryGetValue(roverId, out rover);
            return rover;
        }

        public Map GetMap()
        {
            return _map;
        }

        public string GetLastError()
        {
            string error = null;
            _errors.TryPeek(out error);
            return error;
        }

        public static bool IsValidCommand(string commands, out string error)
        {
            error = null;

            for (int index = 0; index < commands.Length; index++)
            {
                var command = commands[index];
                switch (command)
                {
                    case TURN_LEFT:
                    case TURN_RIGHT:
                    case MOVE_FORWARD:
                        break;

                    default:
                        error = $"Invalid command {command} at index {index}";
                        return false;
                }
            }
            return true;
        }

        public bool MoveRover(int roverId, string commands)
        {
            commands = commands.ToUpper();

            string error = null;
            if (IsValidCommand(commands, out error) == false)
            {
                _errors.Push(error);
                return false;
            }

            var rover = GetRover(roverId);
            if (rover == null) return false;

            for (int index = 0; index < commands.Length; index++)
            {
                var command = commands[index];
                bool success = false;
                switch (command)
                {
                    case TURN_LEFT:
                        success = rover.Turn(Rover.Turns.Left);
                        break;

                    case TURN_RIGHT:
                        success = rover.Turn(Rover.Turns.Right);
                        break;

                    case MOVE_FORWARD:
                        success = rover.MoveForward();
                        break;
                }
                if (success == false)
                {
                    _errors.Push($"Failed to execute command {command} at index {index}: {rover.GetLastError()}");
                    return false;
                }
            }
            return true;
        }

        public string Output(int roverId)
        {
            var rover = GetRover(roverId);
            if (rover == null) return "Error:Rover is not found.";
            return rover.GetCurrentState().Output();
        }

        public string GetRoverLastError(int roverId)
        {
            var rover = GetRover(roverId);
            return rover.GetLastError();
        }
    }
}