using Rover;
using Test.Data;
using Xunit;

namespace Test
{
    public class UnitTestMap
    {
        [Theory]
        [ClassData(typeof(TestMapBoundaryData))]
        public void TesMapCanCheckBoundary(int maxX, int maxY, int x, int y, bool expected)
        {
            var map = new Map(maxX, maxY);
            Assert.Equal(expected, map.IsInBoundary(x, y));
        }

        [Theory]
        [ClassData(typeof(TestMapOriginData))]
        public void TestMapHasZeroOrigin(int maxX, int maxY, int expectedX, int expectedY)
        {
            var map = new Map(maxX, maxY);
            Assert.Equal(expectedX, map.maxX);
            Assert.Equal(expectedY, map.maxY);
        }
    }
}