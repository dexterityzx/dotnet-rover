using Rover;
using Test.Data;
using Xunit;

namespace Test
{
    public class UnitTestRoverState
    {
        [Theory]
        [ClassData(typeof(TestRoverStateData))]
        public void TestRoverStateCanCloneOtherRoverState(RoverState state)
        {
            var clonedState = RoverState.Clone(state);
            Assert.True(clonedState.Equals(state));
            Assert.True(state.Equals(clonedState));
        }

        [Theory]
        [ClassData(typeof(TestRoverStateData))]
        public void TestRoverStateCanOutputState(RoverState state)
        {
            Assert.Equal($"{state.x} {state.y} {DirectionEnumHelper.ToString(state.direction)}", state.Output());
        }

        [Theory]
        [ClassData(typeof(TestRoverStateEqualityData))]
        public void TestRoverStateCanCompareEquality(RoverState state1, RoverState state2, bool expected)
        {
            Assert.Equal(expected, state1.Equals(state2));
            Assert.Equal(expected, state2.Equals(state1));
        }
    }
}