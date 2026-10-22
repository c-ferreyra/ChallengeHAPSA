using ChallengeHAPSA.Application.Ports.Commands;
using ChallengeHAPSA.Domain.Common;

namespace ChallengeHAPSA.Application.Commands
{
    public class CreateHorseCommand : ICommand<Result<int?>>
    {
        public string Name { get; set; }
        public Guid CreatorId { get; set; }
    }
}
