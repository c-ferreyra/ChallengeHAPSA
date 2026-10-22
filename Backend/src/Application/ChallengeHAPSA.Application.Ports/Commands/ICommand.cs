using MediatR;

namespace ChallengeHAPSA.Application.Ports.Commands
{
    public interface ICommand<out T> : IRequest<T>
    {

    }

    public interface ICommand : IRequest
    {

    }
}
