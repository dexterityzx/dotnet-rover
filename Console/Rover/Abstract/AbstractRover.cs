using Rover.Interface;
using System.Collections.Generic;

namespace Rover.Abstract
{
    public abstract class AbstractRover<TRoverState> where TRoverState : IRoverState
    {
        public enum Turns
        {
            Left,
            Right
        }

        protected Map _map;

        protected Stack<TRoverState> _states;

        protected Stack<string> _errors;

        public AbstractRover(Map map, TRoverState state)
        {
            _map = map;
            _states = new Stack<TRoverState>();
            _errors = new Stack<string>();
        }

        public abstract bool MoveForward();

        public abstract bool Turn(Turns turn);

        protected abstract bool IsValidState(TRoverState state);

        public virtual TRoverState GetCurrentState()
        {
            TRoverState currentState;
            _states.TryPeek(out currentState);
            return currentState;
        }

        public virtual string GetLastError()
        {
            string error = null;
            _errors.TryPeek(out error);
            return error;
        }
    }
}