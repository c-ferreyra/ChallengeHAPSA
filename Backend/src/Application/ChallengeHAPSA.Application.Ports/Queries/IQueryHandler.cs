using MediatR;

namespace ChallengeHAPSA.Application.Ports.Queries
{
    public interface IQueryHandler<in T, TR> : IRequestHandler<T, TR> where T : IQuery<TR>
    {
    }
}
