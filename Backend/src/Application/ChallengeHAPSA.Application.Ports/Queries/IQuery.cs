using MediatR;

namespace ChallengeHAPSA.Application.Ports.Queries
{
    public interface IQuery<out T> : IRequest<T>
    {
    }
}
