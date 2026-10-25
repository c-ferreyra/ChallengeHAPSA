using ChallengeHAPSA.Application.Ports.Commands;
using ChallengeHAPSA.Domain.Common;
using ChallengeHAPSA.Domain.Horses;

namespace ChallengeHAPSA.Application.Commands
{
    public class CreateHorseCommand : ICommand<Result<Guid>>
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public HorseType Type { get; set; }
    }
}
