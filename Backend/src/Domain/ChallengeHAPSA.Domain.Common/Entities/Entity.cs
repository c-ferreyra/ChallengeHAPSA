
namespace ChallengeHAPSA.Domain.Common.Entities
{
    public abstract class Entity<T>
        where T : struct
    {
        public virtual T Id { get; protected set; }
    }

    public abstract class Entity : Entity<Guid>
    {
        protected Entity()
        {
            this.Id = Guid.CreateVersion7();
        }
    }
}
