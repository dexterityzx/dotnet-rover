namespace Rover
{
    public class RoverState
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

        public bool Equals(RoverState state)
        {
            if (direction != state.direction) return false;
            if (x != state.x) return false;
            if (y != state.y) return false;
            return true;
        }
    }
}