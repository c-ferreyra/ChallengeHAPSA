
using ChallengeHAPSA.Domain.Common.Repositories;

namespace ChallengeHAPSA.Domain.Horses
{
    public interface IHorseRepository : IEntityRepository<Horse, Guid>
    {
        Task<bool> NameInUse(string name, Guid? excludeId = null);
    }
}
