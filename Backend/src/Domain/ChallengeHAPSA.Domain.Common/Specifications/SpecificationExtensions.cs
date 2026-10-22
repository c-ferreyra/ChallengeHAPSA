namespace ChallengeHAPSA.Domain.Common.Specifications
{
    public static class SpecificationExtensions
    {
        public static ISpecification<T> And<T>(this ISpecification<T> left, ISpecification<T> right)
            where T : notnull
        {
            return new AndSpecification<T>(left, right);
        }

        public static ISpecification<T> AndNot<T>(this ISpecification<T> left, ISpecification<T> right)
            where T : notnull
        {
            return new AndNotSpecification<T>(left, right);
        }

        public static ISpecification<T> Or<T>(this ISpecification<T> left, ISpecification<T> right)
            where T : notnull
        {
            return new OrSpecification<T>(left, right);
        }

        public static ISpecification<T> OrNot<T>(this ISpecification<T> left, ISpecification<T> right)
            where T : notnull
        {
            return new OrNotSpecification<T>(left, right);
        }

        public static ISpecification<T> Not<T>(this ISpecification<T> specification)
            where T : notnull
        {
            return new NotSpecification<T>(specification);
        }
    }
}
