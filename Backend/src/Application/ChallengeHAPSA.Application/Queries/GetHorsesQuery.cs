using ChallengeHAPSA.Application.Ports.Queries;
using ChallengeHAPSA.Domain.Common;

namespace ChallengeHAPSA.Application.Queries
{
    public class GetHorsesQuery : IQuery<Result<IEnumerable<HorseDTO>>>
    {
        public bool? Status { get; set; }
        public string? Name { get; set; }
    }
}
