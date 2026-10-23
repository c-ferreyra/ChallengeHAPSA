using ChallengeHAPSA.Application.Ports.Commands;
using ChallengeHAPSA.Domain.Common;

namespace ChallengeHAPSA.Application.Commands
{
    public class CreateHorseCommand : ICommand<Result<Guid>>
    {
        public string Name { get; set; }
    }
}
