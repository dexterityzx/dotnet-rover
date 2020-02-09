using Rover;
using Test.Data;
using Xunit;

namespace Test
{
    public class UnitTestDirections
    {
        [Fact]
        public void TesDriectionEnumHelperCanReturnCount()
        {
            Assert.Equal(4, DirectionEnumHelper.Count());
        }

        [Theory]
        [ClassData(typeof(TestDirectionEnumInt))]
        public void TesDriectionEnumHelperCanCastIntToEnum(Directions? direction, int intValue)
        {
            if (direction.HasValue)
            {
                Assert.Equal(direction.Value, DirectionEnumHelper.ToEnum(intValue));
            }
            else
            {
                Assert.Null(DirectionEnumHelper.ToEnum(intValue));
            }
        }

        [Theory]
        [ClassData(typeof(TestDirectionEnumInt))]
        public void TesDriectionEnumHelperCanCastEnumToInt(Directions? direction, int intValue)
        {
            if (direction.HasValue)
            {
                Assert.Equal(intValue, DirectionEnumHelper.ToInt(direction.Value));
            }
        }

        [Theory]
        [ClassData(typeof(TestDirectionEnumString))]
        public void TesDriectionEnumHelperCanCastEnumToString(Directions? direction, string strValue)
        {
            if (direction.HasValue)
            {
                Assert.Equal(strValue, DirectionEnumHelper.ToString(direction.Value));
            }
        }

        [Theory]
        [ClassData(typeof(TestDirectionEnumString))]
        public void TesDriectionEnumHelperCanCastStringToEnum(Directions? direction, string strValue)
        {
            if (direction.HasValue)
            {
                Assert.Equal(direction.Value, DirectionEnumHelper.ToEnum(strValue));
            }
            else
            {
                Assert.Null(DirectionEnumHelper.ToEnum(strValue));
            }
        }
    }
}