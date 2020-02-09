using Rover;
using Xunit;

namespace Test.Data
{
    internal class TestRoverTurnData : TheoryData<RoverState, Rover.Rover.Turns, RoverState>
    {
        public TestRoverTurnData()
        {
            Add(new RoverState(1, 1, Directions.North), Rover.Rover.Turns.Left, new RoverState(1, 1, Directions.West));
            Add(new RoverState(1, 1, Directions.East), Rover.Rover.Turns.Left, new RoverState(1, 1, Directions.North));
            Add(new RoverState(1, 1, Directions.South), Rover.Rover.Turns.Left, new RoverState(1, 1, Directions.East));
            Add(new RoverState(1, 1, Directions.West), Rover.Rover.Turns.Left, new RoverState(1, 1, Directions.South));

            Add(new RoverState(1, 1, Directions.North), Rover.Rover.Turns.Right, new RoverState(1, 1, Directions.East));
            Add(new RoverState(1, 1, Directions.East), Rover.Rover.Turns.Right, new RoverState(1, 1, Directions.South));
            Add(new RoverState(1, 1, Directions.South), Rover.Rover.Turns.Right, new RoverState(1, 1, Directions.West));
            Add(new RoverState(1, 1, Directions.West), Rover.Rover.Turns.Right, new RoverState(1, 1, Directions.North));
        }
    }
}