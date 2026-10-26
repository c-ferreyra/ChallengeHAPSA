using ChallengeHAPSA.Application.Commands;
using ChallengeHAPSA.Domain.Common.Enums;
using ChallengeHAPSA.Domain.Horses;
using Moq;

namespace ChallengeHAPSA.Application.Tests.Commands
{
    public class UpdateHorseCommandHandlerTests
    {
        private Mock<IHorseRepository> MockHorseRepository = new();
        private UpdateHorseCommandHandler handler;

        public UpdateHorseCommandHandlerTests()
        {
            handler = new UpdateHorseCommandHandler(MockHorseRepository.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnFailureResult_WhenHorseDoesNotExist()
        {
            // Arrange
            MockHorseRepository.Setup(repo => repo.Get(It.IsAny<Guid>())).ReturnsAsync((Horse)null);
            var command = new UpdateHorseCommand()
            {
                Id = Guid.NewGuid(),
                Name = "UpdatedHorse"
            };
            // Act
            var result = await handler.Handle(command, CancellationToken.None);
            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(ErrorCodes.HORSE_NOT_FOUND, result.Error?.Code);
        }

        [Fact]
        public async Task Handle_ShouldReturnFailureResult_WhenHorseNameIsInUse()
        {
            // Arrange
            var existingHorse = Horse.Create("ExistingHorse", DateTime.Now.AddYears(-5), HorseType.Racehorse);
            MockHorseRepository.Setup(repo => repo.Get(It.IsAny<Guid>())).ReturnsAsync(existingHorse.Value);
            MockHorseRepository.Setup(repo => repo.NameInUse(It.IsAny<string>(), It.IsAny<Guid>())).ReturnsAsync(true);
            var command = new UpdateHorseCommand()
            {
                Id = existingHorse.Value.Id,
                Name = "ExistingHorse"
            };
            // Act
            var result = await handler.Handle(command, CancellationToken.None);
            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(ErrorCodes.HORSE_NAME_IN_USE, result.Error?.Code);
        }

        [Fact]
        public async Task Handle_ShouldReturnSuccessResult_WhenHorseUpdateSucceeds()
        {
            // Arrange
            var existingHorse = Horse.Create("OldHorse", DateTime.Now.AddYears(-5), HorseType.Racehorse);
            MockHorseRepository.Setup(repo => repo.Get(It.IsAny<Guid>())).ReturnsAsync(existingHorse.Value);
            MockHorseRepository.Setup(repo => repo.NameInUse(It.IsAny<string>(), It.IsAny<Guid>())).ReturnsAsync(false);
            var command = new UpdateHorseCommand()
            {
                Id = existingHorse.Value.Id,
                Name = "UpdatedHorse"
            };
            // Act
            var result = await handler.Handle(command, CancellationToken.None);
            // Assert
            Assert.True(result.IsSuccess);
        }

    }
}
