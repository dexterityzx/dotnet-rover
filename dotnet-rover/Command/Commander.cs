using System.Collections.Generic;

namespace Rover
{
    public class Commander
    {
        private Dictionary<int, Rover> _rovers;
        private Map _map = null;

        private const char TURN_LEFT = 'L';
        private const char TURN_RIGHT = 'R';
        private const char MOVE_FORWARD = 'M';

        public Commander()
        {
            _rovers = new Dictionary<int, Rover>();
        }

        public void CreateMap(int maxX, int maxY)
        {
            _map = new Map(maxX, maxY);
        }

        public int CreateRover(int x, int y, string initialDirection)
        {
            if (_map == null) return -1;

            Directions? direction = DirectionEnumHelper.FromString(initialDirection);
            if (direction == null) return -1;

            var roverId = _rovers.Count;
            var rover = new Rover(_map, new RoverState(x, y, direction.Value));
            _rovers.Add(roverId, rover);

            return roverId;
        }

        public Rover GetRover(int roverId)
        {
            Rover rover = null;
            if (_rovers.TryGetValue(roverId, out rover))
            {
                return rover;
            }
            return null;
        }

        public Map GetMap()
        {
            return _map;
        }

        public bool MoveRover(int roverId, string commands)
        {
            var rover = GetRover(roverId);
            if (rover == null) return false;

            commands = commands.ToUpper();
            foreach (var command in commands)
            {
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
                if (success == false) return false;
            }
            return true;
        }

        public string Output(int roverId)
        {
            var rover = GetRover(roverId);
            if (rover == null) return "Error:Rover is not found.";
            return rover.GetCurrentState().Output();
        }
    }
}