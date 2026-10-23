using ChallengeHAPSA.Domain.Horses;
using ChallengeHAPSA.Repository.EFCore.Context;
using ChallengeHAPSA.Repository.EFCore.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace ChallengeHAPSA.Repository.EFCore.Repositories
{
    internal sealed class HorseRepository : AbstractEntityRepository<Horse, Guid>, IHorseRepository
    {
        public HorseRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Task<bool> NameInUse(string name)
        {
            return this.QueryBuilder().AnyAsync(x => x.Name == name);
        }

    }
}
