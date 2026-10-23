using ChallengeHAPSA.Application.Ports.Commands;
using ChallengeHAPSA.Domain.Common;
using ChallengeHAPSA.Domain.Common.Enums;
using ChallengeHAPSA.Domain.Horses;

namespace ChallengeHAPSA.Application.Commands
{
    internal sealed class DisableHorseCommandHandler : ICommandHandler<DisableHorseCommand, Result>
    {
        private readonly IHorseRepository horseRepository;

        public DisableHorseCommandHandler(IHorseRepository horseRepository)
        {
            this.horseRepository = horseRepository;
        }

        public async Task<Result> Handle(DisableHorseCommand request, CancellationToken cancellationToken)
        {
            var horse = await this.horseRepository.Get(request.Id);

            if (horse is null)
            {
                return ErrorCodes.HORSE_NOT_FOUND;
            }

            var result = horse.Disable();

            if (result.IsFailure)
            {
                return result.Error;
            }

            await this.horseRepository.Update(horse);
            return Result.Success();
        }
    }
}
