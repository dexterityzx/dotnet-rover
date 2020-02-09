using Rover;
using Xunit;

namespace Test.Data
{
    internal class TestRoverStateEqualityData : TheoryData<RoverState, RoverState, bool>
    {
        public TestRoverStateEqualityData()
        {
            Add(new RoverState(1, 1, Directions.North), new RoverState(1, 1, Directions.North), true);
            Add(new RoverState(1, 1, Directions.East), new RoverState(1, 1, Directions.East), true);
            Add(new RoverState(1, 1, Directions.South), new RoverState(1, 1, Directions.South), true);
            Add(new RoverState(1, 1, Directions.West), new RoverState(1, 1, Directions.West), true);
            Add(new RoverState(1, 2, Directions.North), new RoverState(1, 2, Directions.North), true);
            Add(new RoverState(2, 1, Directions.East), new RoverState(2, 1, Directions.East), true);

            Add(new RoverState(1, 1, Directions.South), new RoverState(2, 1, Directions.South), false);
            Add(new RoverState(1, 1, Directions.West), new RoverState(1, 2, Directions.West), false);
            Add(new RoverState(1, 1, Directions.East), new RoverState(1, 1, Directions.West), false);
        }
    }
}