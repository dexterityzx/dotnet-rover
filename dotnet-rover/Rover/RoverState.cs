namespace Rover
{
    public class RoverState
    {
        public Directions direction = Directions.North;
        public int x = 0;
        public int y = 0;

        public RoverState()
        {
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
            // using reflection, may not be necessary here.
            //foreach (PropertyInfo property in GetType().GetProperties())
            //{
            //    var propertyName = property.Name;
            //    if (property.GetValue(this) != state.GetType().GetProperty(propertyName).GetValue(state))
            //    {
            //        return false;
            //    }
            //}

            if (direction != state.direction) return false;
            if (x != state.x) return false;
            if (y != state.y) return false;
            return true;
        }
    }
}