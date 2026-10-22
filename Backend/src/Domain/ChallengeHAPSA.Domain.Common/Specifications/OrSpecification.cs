using ChallengeHAPSA.Domain.Common.Extensions;
using System.Linq.Expressions;

namespace ChallengeHAPSA.Domain.Common.Specifications
{
    public class OrSpecification<T> : CompositeSpecification<T>
        where T : notnull
    {
        public OrSpecification(ISpecification<T> left, ISpecification<T> right) : base(left, right)
        {

        }

        public override Expression<Func<T, bool>> ToExpression()
        {
            return Left.ToExpression().Or(Right.ToExpression());
        }
    }
}
