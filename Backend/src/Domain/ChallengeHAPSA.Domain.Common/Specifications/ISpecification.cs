using System;
using System.Linq.Expressions;

namespace ChallengeHAPSA.Domain.Common.Specifications
{
    public interface ISpecification<T>
        where T : notnull
    {
        bool IsSatisfiedBy(T obj);

        Expression<Func<T, bool>> ToExpression();
    }
}
