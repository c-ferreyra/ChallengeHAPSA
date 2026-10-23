using ChallengeHAPSA.Domain.Common.Entities;
using ChallengeHAPSA.Domain.Common.Specifications;

namespace ChallengeHAPSA.Domain.Common.Repositories
{
    public interface IEntityRepository<T, TK>
        where T : Entity<TK>
        where TK : struct
    {
        Task Create(T entity);

        Task Update(T entity);

        Task<T> Get(TK id);

        IQueryable<T> QueryBuilder();

        Task<T> FirstOrDefaultAsync(IQueryable<T> query);

        Task<T> FirstOrDefaultAsync(ISpecification<T> specification);

        Task Remove(TK id);

        Task<T> SingleOrDefaultAsync(IQueryable<T> query);

        Task<T> SingleOrDefaultAsync(ISpecification<T> specification);

        Task<bool> AnyAsync(IQueryable<T> query);

        Task<bool> AnyAsync(ISpecification<T> specification);
    }
}
