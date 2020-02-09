using Rover;
using Xunit;

namespace Test.Data
{
    internal class TestRoverMoveForwardData : TheoryData<RoverState, RoverState>
    {
        public TestRoverMoveForwardData()
        {
            Add(new RoverState(1, 1, Directions.North), new RoverState(1, 2, Directions.North));
            Add(new RoverState(1, 1, Directions.East), new RoverState(2, 1, Directions.East));
            Add(new RoverState(1, 1, Directions.South), new RoverState(1, 0, Directions.South));
            Add(new RoverState(1, 1, Directions.West), new RoverState(0, 1, Directions.West));
        }
    }
}