using ChallengeHAPSA.Domain.Common.Specifications;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace ChallengeHAPSA.Domain.Horses.Specifications
{
    public sealed class HorseNamedSpecification : Specification<Horse>
    {
        private readonly string name;

        public HorseNamedSpecification(string name)
        {
            this.name = name;
        }

        public override Expression<Func<Horse, bool>> ToExpression()
            => horse => horse.Name == this.name;


    }

    public sealed class HorseWithIdSpecification : Specification<Horse>
    {
        private readonly Guid Id;

        public HorseWithIdSpecification(Guid id)
        {
            this.Id = id;
        }

        public override Expression<Func<Horse, bool>> ToExpression()
            => horse => horse.Id == this.Id;
    }
}
