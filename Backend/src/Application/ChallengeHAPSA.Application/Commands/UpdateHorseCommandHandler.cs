using ChallengeHAPSA.Application.Ports.Commands;
using ChallengeHAPSA.Domain.Common;
using ChallengeHAPSA.Domain.Common.Enums;
using ChallengeHAPSA.Domain.Horses;

namespace ChallengeHAPSA.Application.Commands
{
    public sealed class UpdateHorseCommandHandler : ICommandHandler<UpdateHorseCommand, Result>
    {
        private readonly IHorseRepository horseRepository;

        public UpdateHorseCommandHandler(IHorseRepository horseRepository)
        {
            this.horseRepository = horseRepository;
        }

        public async Task<Result> Handle(UpdateHorseCommand request, CancellationToken cancellationToken)
        {
            var horse = await this.horseRepository.Get(request.Id);

            if (horse is null)
            {
                return ErrorCodes.HORSE_NOT_FOUND;
            }

            if (await this.horseRepository.NameInUse(request.Name, request.Id))
            {
                return ErrorCodes.HORSE_NAME_IN_USE;
            }

            var result = horse.Rename(request.Name);

            if (result.IsFailure)
            {
                return result.Error!;
            }

            await this.horseRepository.Update(horse);
            return Result.Success();
        }
    }
}
