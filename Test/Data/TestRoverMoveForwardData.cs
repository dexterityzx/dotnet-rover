using Rover;
using Xunit;

namespace Test.Data
{
    internal class TestRoverStateData : TheoryData<RoverState>
    {
        public TestRoverStateData()
        {
            Add(new RoverState(1, 1, Directions.North));
            Add(new RoverState(1, 1, Directions.East));
            Add(new RoverState(1, 1, Directions.South));
            Add(new RoverState(1, 1, Directions.West));
        }
    }
}