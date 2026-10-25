using ChallengeHAPSA.Application.Ports.Queries;
using ChallengeHAPSA.Domain.Common;
using ChallengeHAPSA.Domain.Horses;

namespace ChallengeHAPSA.Application.Queries
{
    public class GetHorsesQuery : IQuery<Result<IEnumerable<HorseDTO>>>
    {
        public bool? Status { get; set; }
        public string? Name { get; set; }
        public HorseType? Type { get; set; }
    }
}
