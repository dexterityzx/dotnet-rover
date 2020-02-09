using Rover.Abstract;

namespace Rover
{
    public class Rover : AbstractRover<RoverState>
    {
        public Rover(Map map, RoverState state = null) : base(map, state)
        {
            if (IsValidState(state))
            {
                _states.Push(RoverState.Clone(state));
            }
            else
            {
                _states.Push(new RoverState());
            }
        }

        public override bool MoveForward()
        {
            RoverState currentState = GetCurrentState();

            if (currentState == null) return false;

            var nextState = (RoverState)currentState.Clone();

            switch (currentState.direction)
            {
                case Directions.North:
                    nextState.y++;
                    break;

                case Directions.East:
                    nextState.x++;
                    break;

                case Directions.South:
                    nextState.y--;
                    break;

                case Directions.West:
                    nextState.x--;
                    break;

                default:
                    _errors.Push($"Unknown direction : ${currentState.direction}");
                    return false;
            }
            if (IsValidState(nextState) == false) return false;

            _states.Push(nextState);
            return true;
        }

        public override bool Turn(Turns turn)
        {
            RoverState currentState = GetCurrentState();

            if (currentState == null) return false;

            var nextState = RoverState.Clone(currentState);

            int directionDelta = 0;
            switch (turn)
            {
                case Turns.Left:
                    directionDelta = -1;
                    break;

                case Turns.Right:
                    directionDelta = 1;
                    break;
            }

            int currentDirection = DirectionEnumHelper.ToInt(nextState.direction);
            int directionLength = DirectionEnumHelper.Count();
            int nextDirection = (currentDirection + directionDelta + directionLength) % directionLength;
            nextState.direction = DirectionEnumHelper.ToEnum(nextDirection).Value;

            if (IsValidState(nextState) == false) return false;

            _states.Push(nextState);

            return true;
        }

        protected override bool IsValidState(RoverState state)
        {
            if (state == null) return false;
            if (_map.IsInBoundary(state.x, state.y) == false)
            {
                _errors.Push($"({state.x},{state.y}) is out of map boundary.");
                return false;
            }
            return true;
        }
    }
}