using System;
using System.Linq.Expressions;

namespace ChallengeHAPSA.Domain.Common.Specifications
{
    public abstract class Specification<T> : ISpecification<T>
        where T : notnull
    {
        public virtual bool IsSatisfiedBy(T obj)
        {
            return this.ToExpression().Compile()(obj);
        }

        public abstract Expression<Func<T, bool>> ToExpression();
    }
}
