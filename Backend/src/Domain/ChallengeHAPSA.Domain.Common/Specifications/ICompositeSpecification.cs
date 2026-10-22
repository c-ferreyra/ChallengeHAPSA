namespace ChallengeHAPSA.Domain.Common.Specifications
{
    public interface ICompositeSpecification<T> : ISpecification<T>
        where T : notnull
    {
        ISpecification<T> Left { get; }

        ISpecification<T> Right { get; }
    }
}
