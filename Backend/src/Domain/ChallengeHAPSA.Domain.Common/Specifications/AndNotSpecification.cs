namespace ChallengeHAPSA.Domain.Common.Specifications
{
    public class AndNotSpecification<T> : AndSpecification<T>
        where T : notnull
    {
        public AndNotSpecification(ISpecification<T> left, ISpecification<T> right) : base(left, new NotSpecification<T>(right))
        {

        }
    }
}
