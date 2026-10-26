using ChallengeHAPSA.Application.Ports.Commands;
using ChallengeHAPSA.Domain.Common;
using ChallengeHAPSA.Domain.Common.Enums;
using ChallengeHAPSA.Domain.Horses;

namespace ChallengeHAPSA.Application.Commands
{
    public sealed class EnableHorseCommandHandler : ICommandHandler<EnableHorseCommand, Result>
    {
        private readonly IHorseRepository horseRepository;

        public EnableHorseCommandHandler(IHorseRepository horseRepository)
        {
            this.horseRepository = horseRepository;
        }

        public async Task<Result> Handle(EnableHorseCommand request, CancellationToken cancellationToken)
        {
            var horse = await this.horseRepository.Get(request.Id);

            if (horse is null)
            {
                return ErrorCodes.HORSE_NOT_FOUND;
            }

            var result = horse.Enable();

            if (result.IsFailure)
            {
                return result.Error!;
            }

            await this.horseRepository.Update(horse);
            return Result.Success();
        }
    }
}
