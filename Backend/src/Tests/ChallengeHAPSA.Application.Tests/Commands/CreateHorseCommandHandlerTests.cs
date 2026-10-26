using ChallengeHAPSA.Domain.Horses;
using ChallengeHAPSA.Application.Commands;
using Moq;
using ChallengeHAPSA.Domain.Common.Enums;

namespace ChallengeHAPSA.Application.Tests.Commands
{
    public class CreateHorseCommandHandlerTests
    {
        private Mock<IHorseRepository> MockHorseRepository = new();
        private CreateHorseCommandHandler handler;

        public CreateHorseCommandHandlerTests()
        {
            handler = new CreateHorseCommandHandler(MockHorseRepository.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnFailureResult_WhenHorseNameIsInUse()
        {
            // Arrange
            MockHorseRepository.Setup(repo => repo.NameInUse(It.IsAny<string>())).ReturnsAsync(true);
            var command = new CreateHorseCommand()
            {
                Name = "TestHorse",
                Birthday = DateTime.Now.AddYears(-5),
                Type = HorseType.Racehorse
            };

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(ErrorCodes.HORSE_NAME_IN_USE, result.Error?.Code);
        }

        [Fact]
        public async Task Handle_ShouldReturnFailureResult_WhenHorseCreationFails()
        {
            // Arrange
            MockHorseRepository.Setup(repo => repo.NameInUse(It.IsAny<string>())).ReturnsAsync(false);
            var command = new CreateHorseCommand()
            {
                Name = "", // Invalid name to trigger failure
                Birthday = DateTime.Now.AddYears(-5),
                Type = HorseType.Racehorse
            };
            // Act
            var result = await handler.Handle(command, CancellationToken.None);
            // Assert
            Assert.True(result.IsFailure);
        }

        [Fact]
        public async Task Handle_ShouldReturnNewIdResult_WhenHorseCreationSucceeds()
        {
            // Arrange
            MockHorseRepository.Setup(repo => repo.NameInUse(It.IsAny<string>())).ReturnsAsync(false);
            var command = new CreateHorseCommand()
            {
                Name = "ValidHorseName",
                Birthday = DateTime.Now.AddYears(-5),
                Type = HorseType.Racehorse
            };
            // Act
            var result = await handler.Handle(command, CancellationToken.None);
            // Assert
            Assert.True(result.IsSuccess);
            Assert.NotEqual(Guid.Empty, result.Value);
        }
    }
}
