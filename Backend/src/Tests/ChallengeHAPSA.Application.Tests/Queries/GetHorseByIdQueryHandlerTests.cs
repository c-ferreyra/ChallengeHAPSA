using ChallengeHAPSA.Application.Queries;
using ChallengeHAPSA.Domain.Common.Enums;
using ChallengeHAPSA.Domain.Horses;
using Moq;

namespace ChallengeHAPSA.Application.Tests.Queries
{
    public class GetHorseByIdQueryHandlerTests
    {
        private Mock<IHorseRepository> MockHorseRepository = new();
        private GetHorseByIdQueryHandler handler;
        public GetHorseByIdQueryHandlerTests()
        {
            handler = new GetHorseByIdQueryHandler(MockHorseRepository.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnFailureResult_WhenHorseNotFound()
        {
            // Arrange
            MockHorseRepository.Setup(repo => repo.Get(It.IsAny<Guid>())).ReturnsAsync((Horse)null);
            var query = new GetHorseByIdQuery();
            // Act
            var result = await handler.Handle(query, CancellationToken.None);
            // Assert
            Assert.True(result.IsFailure);
            Assert.Equal(ErrorCodes.HORSE_NOT_FOUND, result.Error?.Code);
        }

        [Fact]
        public async Task Handle_ShouldReturnHorseDTO_WhenHorseFound()
        {
            // Arrange
            var horse = Horse.Create("TestHorse", DateTime.Now.AddYears(-5), HorseType.Racehorse).Value;
            MockHorseRepository.Setup(repo => repo.Get(horse.Id)).ReturnsAsync(horse);
            var query = new GetHorseByIdQuery()
            {
                Id = horse.Id
            };
            // Act
            var result = await handler.Handle(query, CancellationToken.None);
            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(horse.Id, result.Value?.Id);
            Assert.Equal(horse.Name, result.Value?.Name);
            Assert.Equal(horse.Birthday, result.Value?.Birthday);
            Assert.Equal(horse.Status, result.Value?.Status);
            Assert.Equal(horse.Type, result.Value?.Type);
        }
    }
}
