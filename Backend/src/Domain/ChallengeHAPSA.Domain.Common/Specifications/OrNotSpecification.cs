namespace ChallengeHAPSA.Domain.Common.Specifications
{
    public class OrNotSpecification<T> : OrSpecification<T>
        where T : notnull
    {
        public OrNotSpecification(ISpecification<T> left, ISpecification<T> right) : base(left, new NotSpecification<T>(right))
        {

        }
    }
}
