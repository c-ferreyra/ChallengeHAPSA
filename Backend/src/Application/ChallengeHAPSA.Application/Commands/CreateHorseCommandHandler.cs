using ChallengeHAPSA.Application.Ports.Commands;
using ChallengeHAPSA.Domain.Common;
using ChallengeHAPSA.Domain.Common.Enums;
using ChallengeHAPSA.Domain.Horses;

namespace ChallengeHAPSA.Application.Commands
{
    internal sealed class CreateHorseCommandHandler : ICommandHandler<CreateHorseCommand, Result<Guid>>
    {
        private readonly IHorseRepository horseRepository;

        public CreateHorseCommandHandler(IHorseRepository horseRepository)
        {
            this.horseRepository = horseRepository;
        }

        public async Task<Result<Guid>> Handle(CreateHorseCommand request, CancellationToken cancellationToken)
        {
            var existsName = await this.horseRepository.NameInUse(request.Name);

            if (existsName)
            {
                return ErrorCodes.HORSE_NAME_IN_USE;
            }

            var result = Horse.Create(request.Name, request.Birthday, request.Type);

            if (result.IsFailure)
            {
                return result.Error!;
            }

            await this.horseRepository.Create(result.Value);
            return result.Value.Id;
        }
    }
}
