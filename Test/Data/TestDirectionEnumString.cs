using Rover;
using Xunit;

namespace Test.Data
{
    internal class TestDirectionEnumString : TheoryData<Directions?, string>
    {
        public TestDirectionEnumString()
        {
            Add(Directions.North, "N");
            Add(Directions.East, "E");
            Add(Directions.South, "S");
            Add(Directions.West, "W");
            Add(null, "ABC");
        }
    }
}