using ChallengeHAPSA.Application.Queries;
using ChallengeHAPSA.Domain.Horses;
using Moq;

namespace ChallengeHAPSA.Application.Tests.Queries
{
    public class GetHorsesQueryHandlerTests
    {
        private Mock<IHorseRepository> MockHorseRepository = new();
        private GetHorsesQueryHandler handler;
        public GetHorsesQueryHandlerTests()
        {
            handler = new GetHorsesQueryHandler(MockHorseRepository.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnListOfHorseDTOs_WhenHorsesExist()
        {
            // Arrange
            var horses = new List<Horse>
            {
                Horse.Create("TestHorse1", DateTime.Now.AddYears(-5), HorseType.Racehorse).Value,
                Horse.Create("TestHorse2", DateTime.Now.AddYears(-3), HorseType.Stallion).Value
            };

            MockHorseRepository.Setup(repo => repo.QueryBuilder()).Returns(horses.AsQueryable());
            MockHorseRepository
                .Setup(repo => repo.ListAsync(It.IsAny<IQueryable<Horse>>()))
                .ReturnsAsync((IQueryable<Horse> q) => q.ToList());
            var query = new GetHorsesQuery();
            // Act
            var result = await handler.Handle(query, CancellationToken.None);
            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(2, result.Value!.Count());
        }
    }
}
