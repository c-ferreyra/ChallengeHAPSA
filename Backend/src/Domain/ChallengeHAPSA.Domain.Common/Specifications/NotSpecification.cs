using System;
using System.Linq.Expressions;

namespace ChallengeHAPSA.Domain.Common.Specifications
{
    public class NotSpecification<T> : Specification<T>
        where T : notnull
    {
        private readonly ISpecification<T> specification;

        public NotSpecification(ISpecification<T> specification)
        {
            this.specification = specification;
        }

        public override Expression<Func<T, bool>> ToExpression()
        {
            var expression = this.specification.ToExpression();
            return Expression.Lambda<Func<T, bool>>(
                Expression.Not(expression.Body),
                expression.Parameters
            );
        }
    }
}
