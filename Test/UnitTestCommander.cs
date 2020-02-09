using Rover;
using System;
using Xunit;

namespace Test
{
    public class CommanderFixture : IDisposable
    {
        public Commander commander { get; private set; }

        public CommanderFixture()
        {
            commander = new Commander();
        }

        public void Dispose()
        {
        }
    }

    public class UnitTestCommander : IClassFixture<CommanderFixture>
    {
        public const int MAX_X = 15;
        public const int MAX_Y = 10;

        private CommanderFixture _fixture;

        public UnitTestCommander(CommanderFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void CommanderCanCreateAMap()
        {
            _fixture.commander.CreateMap(MAX_X, MAX_Y);

            var map = _fixture.commander.GetMap();
            Assert.Equal(MAX_X, map.maxX);
            Assert.Equal(MAX_Y, map.maxY);
        }

        [Fact]
        public void CommanderCanCreateARover()
        {
            _fixture.commander.CreateMap(MAX_X, MAX_Y);

            Random random = new Random();
            int randomX = random.Next(0, MAX_X);
            int randomY = random.Next(0, MAX_Y);
            string randomDirection = DirectionEnumHelper.ToString(
                DirectionEnumHelper.ToEnum(
                    random.Next(0, DirectionEnumHelper.Count() - 1)
                )
            );

            var roverId = _fixture.commander.CreateRover(randomX, randomY, randomDirection);

            var rover = _fixture.commander.GetRover(roverId);
            var roverState = rover.GetCurrentState();

            Assert.Equal(randomX, roverState.x);
            Assert.Equal(randomY, roverState.y);
            Assert.Equal(randomDirection, DirectionEnumHelper.ToString(roverState.direction));
        }

        [Fact]
        public void CommanderCanCreateRovers()
        {
            for (var i = 0; i < 5; i++)
            {
                CommanderCanCreateARover();
            }
        }

        [Fact]
        public void CommandercCanMoveRover()
        {
            _fixture.commander.CreateMap(MAX_X, MAX_Y);
            var roverId = _fixture.commander.CreateRover(1, 2, "N");
            _fixture.commander.MoveRover(roverId, "LMLMLMLMM");
            var output = _fixture.commander.Output(roverId);
            Assert.Equal("1 3 N", output);
        }
    }
}