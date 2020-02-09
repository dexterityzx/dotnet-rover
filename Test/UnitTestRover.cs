using Rover;
using System;
using Test.Data;
using Xunit;

namespace Test
{
    public class RoverFixture : IDisposable
    {
        public Map map { get; private set; }

        public const int MAX_X = 15;
        public const int MAX_Y = 10;

        public RoverFixture()
        {
            map = new Map(MAX_X, MAX_Y);
        }

        public void Dispose()
        {
        }
    }

    public class UnitTestRover : IClassFixture<RoverFixture>
    {
        private RoverFixture _fixture;

        public UnitTestRover(RoverFixture fixture)
        {
            _fixture = fixture;
        }

        [Theory]
        [ClassData(typeof(TestRoverMoveForwardData))]
        public void RoverCanMoveForward(RoverState initialState, RoverState expectedState)
        {
            var rover = new Rover.Rover(_fixture.map, initialState);
            rover.MoveForward();
            Assert.True(rover.GetCurrentState().Equals(expectedState));
        }

        [Theory]
        [ClassData(typeof(TestRoverTurnData))]
        public void RoverCanTrun(RoverState initialState, Rover.Rover.Turns turn, RoverState expectedState)
        {
            var rover = new Rover.Rover(_fixture.map, initialState);
            rover.Turn(turn);
            Assert.True(rover.GetCurrentState().Equals(expectedState));
        }

        [Fact]
        public void RoverCanReturnCurrentSatus()
        {
        }
    }
}