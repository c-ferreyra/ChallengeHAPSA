using ChallengeHAPSA.Application.Ports.Commands;
using ChallengeHAPSA.Domain.Common;

namespace ChallengeHAPSA.Application.Commands
{
    public class DisableHorseCommand : ICommand<Result>
    {
        public Guid Id { get; set; }
    }
}
