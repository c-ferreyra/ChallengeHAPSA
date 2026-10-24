using ChallengeHAPSA.Application.Ports.Queries;
using ChallengeHAPSA.Domain.Common;

namespace ChallengeHAPSA.Application.Queries
{
    public class GetHorseByIdQuery : IQuery<Result<HorseDTO>>
    {
        public Guid Id { get; set; }
    }
}
