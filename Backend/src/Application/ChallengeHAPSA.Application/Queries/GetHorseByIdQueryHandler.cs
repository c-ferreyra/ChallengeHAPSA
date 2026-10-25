using ChallengeHAPSA.Application.Ports.Queries;
using ChallengeHAPSA.Domain.Common;
using ChallengeHAPSA.Domain.Common.Enums;
using ChallengeHAPSA.Domain.Horses;

namespace ChallengeHAPSA.Application.Queries
{
    internal sealed class GetHorseByIdQueryHandler : IQueryHandler<GetHorseByIdQuery, Result<HorseDTO>>
    {
        private readonly IHorseRepository horseRepository;

        public GetHorseByIdQueryHandler(IHorseRepository horseRepository)
        {
            this.horseRepository = horseRepository;
        }

        public async Task<Result<HorseDTO>> Handle(GetHorseByIdQuery request, CancellationToken cancellationToken)
        {
            var horse = await this.horseRepository.Get(request.Id);

            if (horse == null)
            {
                return ErrorCodes.HORSE_NOT_FOUND;
            }

            return new HorseDTO
            {
                Id = horse.Id,
                Name = horse.Name,
                Birthday = horse.Birthday,
                Status = horse.Status,
                Type = horse.Type
            };
        }
    }
}
