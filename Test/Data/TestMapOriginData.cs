using Xunit;

namespace Test.Data
{
    internal class TestMapOriginData : TheoryData<int, int, int, int>
    {
        public TestMapOriginData()
        {
            Add(-1, -1, 0, 0);
            Add(1, -1, 1, 0);
            Add(-1, 1, 0, 1);
            Add(1, 1, 1, 1);
        }
    }
}