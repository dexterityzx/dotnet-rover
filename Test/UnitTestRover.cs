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

        [Theory]
        [ClassData(typeof(TestRoverStateData))]
        public void RoverCanReturnCurrentSatus(RoverState initialState)
        {
            var rover = new Rover.Rover(_fixture.map, initialState);
            Assert.True(initialState.Equals(rover.GetCurrentState()));
        }

        [Fact]
        public void RoverCanTrackMovingOutOfBoundaryError()
        {
            var rover = new Rover.Rover(_fixture.map, new RoverState(1, 1, Directions.South));

            rover.MoveForward();
            Assert.Null(rover.GetLastError());

            rover.MoveForward();
            Assert.Equal($"(1,{1 - 2}) is out of map boundary.", rover.GetLastError());
            //rover should stop moving when it's next step is out of boundary
            rover.MoveForward();
            Assert.Equal($"(1,{1 - 2}) is out of map boundary.", rover.GetLastError());
        }

        [Fact]
        public void RoverCanTrackCreationOutOfBoundarysError()
        {
            var x = _fixture.map.maxX + 1;
            var y = _fixture.map.maxY + 1;
            var rover = new Rover.Rover(_fixture.map, new RoverState(x, y, Directions.South));

            Assert.Equal($"({x},{y}) is out of map boundary.", rover.GetLastError());
        }
    }
}