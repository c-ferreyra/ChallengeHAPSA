using ChallengeHAPSA.Application.Commands;
using ChallengeHAPSA.Domain.Common.Enums;
using ChallengeHAPSA.Domain.Horses;
using Moq;

namespace ChallengeHAPSA.Application.Tests.Commands
{
    public class DisableHorseCommandHandlerTests
    {
        private Mock<IHorseRepository> MockHorseRepository = new();
        private DisableHorseCommandHandler handler;

        public DisableHorseCommandHandlerTests()
        {
            handler = new DisableHorseCommandHandler(MockHorseRepository.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnFailureResult_WhenHorseDoesNotExist()
        {
            // Arrange
            MockHorseRepository.Setup(repo => repo.Get(It.IsAny<Guid>())).ReturnsAsync((Horse)null);
            var command = new DisableHorseCommand()
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
        public async Task Handle_ShouldReturnFailureResult_WhenHorseDisableFails()
        {
            // Arrange
            var horse = Horse.Create("TestHorse", DateTime.Now.AddYears(-5), HorseType.Racehorse);
            MockHorseRepository.Setup(repo => repo.Get(It.IsAny<Guid>())).ReturnsAsync(horse.Value);
            horse.Value.Disable(); // Disable the horse to make it fail on second disable
            var command = new DisableHorseCommand()
            {
                Id = horse.Value.Id
            };
            // Act
            var result = await handler.Handle(command, CancellationToken.None);
            // Assert
            Assert.True(result.IsFailure);
        }

        [Fact]
        public async Task Handle_WhenHorseDisableSucceeds_ShouldReturnSuccessResult()
        {
            // Arrange
            var horse = Horse.Create("TestHorse", DateTime.Now.AddYears(-5), HorseType.Racehorse);
            MockHorseRepository.Setup(repo => repo.Get(It.IsAny<Guid>())).ReturnsAsync(horse.Value);
            var command = new DisableHorseCommand()
            {
                Id = horse.Value.Id
            };
            // Act
            var result = await handler.Handle(command, CancellationToken.None);
            // Assert
            Assert.True(result.IsSuccess);
        }
    }
}
