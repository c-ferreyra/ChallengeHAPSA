using ChallengeHAPSA.Domain.Common.Extensions;
using System.Linq.Expressions;

namespace ChallengeHAPSA.Domain.Common.Specifications
{
    public class AndSpecification<T> : CompositeSpecification<T>
        where T : notnull
    {
        public AndSpecification(ISpecification<T> left, ISpecification<T> right) : base(left, right)
        {

        }

        public override Expression<Func<T, bool>> ToExpression()
        {
            return this.Left.ToExpression().And(this.Right.ToExpression());
        }
    }
}
