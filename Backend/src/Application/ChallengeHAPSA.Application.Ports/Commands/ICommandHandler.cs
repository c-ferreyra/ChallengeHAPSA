using MediatR;

namespace ChallengeHAPSA.Application.Ports.Commands
{
    public interface ICommandHandler<in T, TR> : IRequestHandler<T, TR>
        where T : ICommand<TR>
    {
    }

    public interface ICommandHandler<in T> : IRequestHandler<T>
    where T : ICommand
    {

    }

}
