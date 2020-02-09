using Rover.Interface;

namespace Rover
{
    public class RoverState : IRoverState
    {
        public Directions direction;
        public int x;
        public int y;

        public RoverState()
        {
            x = 0;
            y = 0;
            direction = Directions.North;
        }

        public RoverState(int x, int y, Directions direciton)
        {
            this.x = x;
            this.y = y;
            direction = direciton;
        }

        public static RoverState Clone(RoverState state)
        {
            return new RoverState(state.x, state.y, state.direction);
        }

        public string Output()
        {
            return $"{x} {y} {DirectionEnumHelper.ToString(direction)}";
        }

        public bool Equals(IRoverState state)
        {
            var roverState = (RoverState)state;

            if (direction != roverState.direction) return false;
            if (x != roverState.x) return false;
            if (y != roverState.y) return false;
            return true;
        }

        public IRoverState Clone()
        {
            return new RoverState(x, y, direction);
        }
    }
}