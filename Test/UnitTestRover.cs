using Rover;
using Test.Data;
using Xunit;

namespace Test
{
    public class UnitTestRover
    {
        private Rover.Rover _rover;
        private Map _map;

        public UnitTestRover()
        {
            _map = new Map(10, 10);
            _rover = new Rover.Rover(_map);
        }

        [Theory]
        [ClassData(typeof(TestRoverMoveForwardData))]
        public void RoverCanMoveForward(RoverState initialState, RoverState expectedState)
        {
            var rover = new Rover.Rover(_map, initialState);
            rover.MoveForward();
            Assert.True(rover.GetCurrentState().Equals(expectedState));
        }

        [Theory]
        [ClassData(typeof(TestRoverTurnData))]
        public void RoverCanTrun(RoverState initialState, Rover.Rover.Turns turn, RoverState expectedState)
        {
            var rover = new Rover.Rover(_map, initialState);
            rover.Turn(turn);
            Assert.True(rover.GetCurrentState().Equals(expectedState));
        }

        [Fact]
        public void RoverCanReturnCurrentSatus()
        {
        }
    }
}