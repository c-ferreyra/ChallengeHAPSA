using ChallengeHAPSA.Domain.Common.Specifications;
using System.Linq.Expressions;

namespace ChallengeHAPSA.Domain.Horses.Specifications
{
    /// <summary>
    /// Busqueda parcial por nombre, para el listado (HorseNamedSpecification es por igualdad).
    /// </summary>
    public sealed class HorseNameContainsSpecification : Specification<Horse>
    {
        private readonly string name;

        public HorseNameContainsSpecification(string name)
        {
            this.name = name;
        }

        public override Expression<Func<Horse, bool>> ToExpression()
            => horse => horse.Name.Contains(this.name);
    }
}
