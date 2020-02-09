using Xunit;

namespace Test.Data
{
    internal class TestMapBoundaryData : TheoryData<int, int, int, int, bool>
    {
        public TestMapBoundaryData()
        {
            Add(5, 5, 2, 2, true);
            Add(5, 5, 0, 0, true);
            Add(5, 5, 5, 5, true);

            Add(5, 5, 6, 2, false);
            Add(5, 5, 2, 6, false);
            Add(5, 5, 6, 6, false);

            Add(5, 5, -1, 2, false);
            Add(5, 5, 2, -1, false);
        }
    }
}