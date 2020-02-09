using Rover;
using Xunit;

namespace Test.Data
{
    internal class TestDirectionEnumInt : TheoryData<Directions?, int>
    {
        public TestDirectionEnumInt()
        {
            Add(Directions.North, 0);
            Add(Directions.East, 1);
            Add(Directions.South, 2);
            Add(Directions.West, 3);
            Add(null, 4);
            Add(null, 5);
        }
    }
}