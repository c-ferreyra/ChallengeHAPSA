using ChallengeHAPSA.Domain.Common.Entities;
using ChallengeHAPSA.Domain.Common.Repositories;
using ChallengeHAPSA.Domain.Common.Specifications;
using ChallengeHAPSA.Repository.EFCore.Context;
using Microsoft.EntityFrameworkCore;

namespace ChallengeHAPSA.Repository.EFCore.Repositories.Base
{
    public abstract class AbstractEntityRepository<T, TK> : IEntityRepository<T, TK>
        where T : Entity<TK>
        where TK : struct
    {
        protected ApplicationDbContext Context { get; }

        public AbstractEntityRepository(
            ApplicationDbContext context
        )
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public virtual async Task Create(T entity)
        {
            _ = await this.Context.AddAsync(entity);
            _ = await this.Context.SaveChangesAsync();
        }

        public virtual Task<T?> Get(TK id) => this.Context.Set<T>().FirstOrDefaultAsync(e => e.Id.Equals(id));

        public async Task Update(T entity)
        {
            _ = this.Context.Update(entity);
            _ = await this.Context.SaveChangesAsync();
        }

        public IQueryable<T> QueryBuilder() => this.Context.Set<T>();

        public Task<T?> FirstOrDefaultAsync(IQueryable<T> query) => query.FirstOrDefaultAsync();

        public Task<T?> FirstOrDefaultAsync(ISpecification<T> specification) => this.Context.Set<T>().FirstOrDefaultAsync(specification.ToExpression());

        public Task<T?> SingleOrDefaultAsync(IQueryable<T> query) => query.SingleOrDefaultAsync();

        public Task<T?> SingleOrDefaultAsync(ISpecification<T> specification) => this.Context.Set<T>().SingleOrDefaultAsync(specification.ToExpression());

        public Task<bool> AnyAsync(IQueryable<T> query) => query.AnyAsync();

        public Task<bool> AnyAsync(ISpecification<T> specification) => this.Context.Set<T>().AnyAsync(specification.ToExpression());

        public Task<List<T>> ListAsync(IQueryable<T> query) => query.ToListAsync();
    }
}
