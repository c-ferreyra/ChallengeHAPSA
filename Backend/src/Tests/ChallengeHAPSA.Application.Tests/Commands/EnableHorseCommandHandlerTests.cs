using ChallengeHAPSA.Application.Commands;
using ChallengeHAPSA.Domain.Common.Enums;
using ChallengeHAPSA.Domain.Horses;
using Moq;

namespace ChallengeHAPSA.Application.Tests.Commands
{
    public class EnableHorseCommandHandlerTests
    {
        private Mock<IHorseRepository> MockHorseRepository = new();
        private EnableHorseCommandHandler handler;

        public EnableHorseCommandHandlerTests()
        {
            handler = new EnableHorseCommandHandler(MockHorseRepository.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnFailureResult_WhenHorseDoesNotExist()
        {
            // Arrange
            MockHorseRepository.Setup(repo => repo.Get(It.IsAny<Guid>())).ReturnsAsync((Horse)null);
            var command = new EnableHorseCommand()
            {
                Id = Guid.NewGuid()
            };
            // Act
            var result = await handler.Handle(command, CancellationToken.None);
            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(ErrorCodes.HORSE_NOT_FOUND, result.Error?.Code);
        }

        [Fact]
        public async Task Handle_ShouldReturnFailureResult_WhenHorseIsAlreadyEnabled()
        {
            // Arrange
            var horse = Horse.Create("TestHorse", DateTime.Now.AddYears(-5), HorseType.Racehorse).Value;
            MockHorseRepository.Setup(repo => repo.Get(It.IsAny<Guid>())).ReturnsAsync(horse);
            var command = new EnableHorseCommand()
            {
                Id = horse.Id
            };
            // Act
            var result = await handler.Handle(command, CancellationToken.None);
            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(ErrorCodes.HORSE_ALREADY_ENABLED, result.Error?.Code);
        }

        [Fact]
        public async Task Handle_ShouldReturnSuccessResult_WhenHorseIsEnabledSuccessfully()
        {
            // Arrange
            var horse = Horse.Create("TestHorse", DateTime.Now.AddYears(-5), HorseType.Racehorse).Value;
            horse.Disable(); // Disable the horse first
            MockHorseRepository.Setup(repo => repo.Get(It.IsAny<Guid>())).ReturnsAsync(horse);
            var command = new EnableHorseCommand()
            {
                Id = horse.Id
            };
            // Act
            var result = await handler.Handle(command, CancellationToken.None);
            // Assert
            Assert.True(result.IsSuccess);
        }
    }
}
