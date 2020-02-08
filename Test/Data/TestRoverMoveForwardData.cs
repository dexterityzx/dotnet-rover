using Rover;
using Xunit;

namespace Test.Data
{
    internal class TestRoverMoveForwardData : TheoryData<RoverState, RoverState>
    {
        public TestRoverMoveForwardData()
        {
            Add(new RoverState(Directions.North, 1, 1), new RoverState(Directions.North, 1, 2));
            Add(new RoverState(Directions.East, 1, 1), new RoverState(Directions.East, 2, 1));
            Add(new RoverState(Directions.South, 1, 1), new RoverState(Directions.South, 1, 0));
            Add(new RoverState(Directions.West, 1, 1), new RoverState(Directions.West, 0, 1));
        }
    }
}