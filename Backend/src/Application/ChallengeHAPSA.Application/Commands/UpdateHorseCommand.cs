using ChallengeHAPSA.Application.Ports.Commands;
using ChallengeHAPSA.Domain.Common;

namespace ChallengeHAPSA.Application.Commands
{
    public class UpdateHorseCommand : ICommand<Result>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
