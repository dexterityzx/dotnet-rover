using System.Collections.Generic;

namespace Rover
{
    public class Rover
    {
        public enum Turns
        {
            Left,
            Right
        }

        private Map _map;
        private Stack<RoverState> _states;

        public Rover(Map map, RoverState state = null)
        {
            _map = map;
            _states = new Stack<RoverState>();

            if (IsValidState(state))
            {
                _states.Push(RoverState.Clone(state));
            }
        }

        public bool MoveForward()
        {
            RoverState currentState = GetCurrentState();

            if (currentState == null) return false;

            var nextState = RoverState.Clone(currentState);

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
            }
            if (IsValidState(nextState) == false) return false;

            _states.Push(nextState);
            return true;
        }

        public bool Turn(Turns turn)
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
            nextState.direction = DirectionEnumHelper.ToEnum(nextDirection);

            if (IsValidState(nextState) == false) return false;

            _states.Push(nextState);

            return true;
        }

        public RoverState GetCurrentState()
        {
            RoverState currentState = null;
            _states.TryPeek(out currentState);
            return currentState;
        }

        private bool IsValidState(RoverState state)
        {
            return state != null && _map.IsInBoundary(state.x, state.y);
        }
    }
}