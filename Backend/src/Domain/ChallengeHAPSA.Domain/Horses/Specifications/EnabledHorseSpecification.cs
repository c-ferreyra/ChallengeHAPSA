using ChallengeHAPSA.Domain.Common.Specifications;
using System.Linq.Expressions;

namespace ChallengeHAPSA.Domain.Horses.Specifications
{
    /// <summary>
    /// Un caballo esta habilitado mientras no se le haya dado de baja logica.
    /// </summary>
    public sealed class EnabledHorseSpecification : Specification<Horse>
    {
        public override Expression<Func<Horse, bool>> ToExpression()
            => horse => horse.Status;
    }
}
