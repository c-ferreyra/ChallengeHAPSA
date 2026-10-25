using ChallengeHAPSA.Domain.Common.Specifications;
using System.Linq.Expressions;

namespace ChallengeHAPSA.Domain.Horses.Specifications
{
    public sealed class HorseOfTypeSpecification : Specification<Horse>
    {
        private readonly HorseType type;

        public HorseOfTypeSpecification(HorseType type)
        {
            this.type = type;
        }

        public override Expression<Func<Horse, bool>> ToExpression()
            => horse => horse.Type == this.type;
    }
}
