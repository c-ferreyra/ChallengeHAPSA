namespace ChallengeHAPSA.Domain.Common.Specifications
{
    public abstract class CompositeSpecification<T> : Specification<T>, ICompositeSpecification<T>
        where T : notnull
    {
        public ISpecification<T> Left { get; }

        public ISpecification<T> Right { get; }

        protected CompositeSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            this.Left = left;
            this.Right = right;
        }
    }
}
