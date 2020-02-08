using Rover;
using Xunit;

namespace Test.Data
{
    internal class TestRoverTurnData : TheoryData<RoverState, Rover.Rover.Turns, RoverState>
    {
        public TestRoverTurnData()
        {
            Add(new RoverState(Directions.North, 1, 1), Rover.Rover.Turns.Left, new RoverState(Directions.West, 1, 1));
            Add(new RoverState(Directions.East, 1, 1), Rover.Rover.Turns.Left, new RoverState(Directions.North, 1, 1));
            Add(new RoverState(Directions.South, 1, 1), Rover.Rover.Turns.Left, new RoverState(Directions.East, 1, 1));
            Add(new RoverState(Directions.West, 1, 1), Rover.Rover.Turns.Left, new RoverState(Directions.South, 1, 1));
            Add(new RoverState(Directions.North, 1, 1), Rover.Rover.Turns.Right, new RoverState(Directions.East, 1, 1));
            Add(new RoverState(Directions.East, 1, 1), Rover.Rover.Turns.Right, new RoverState(Directions.South, 1, 1));
            Add(new RoverState(Directions.South, 1, 1), Rover.Rover.Turns.Right, new RoverState(Directions.West, 1, 1));
            Add(new RoverState(Directions.West, 1, 1), Rover.Rover.Turns.Right, new RoverState(Directions.North, 1, 1));
        }
    }
}