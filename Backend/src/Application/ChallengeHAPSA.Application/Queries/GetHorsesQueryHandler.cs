using ChallengeHAPSA.Application.Ports.Queries;
using ChallengeHAPSA.Domain.Common;
using ChallengeHAPSA.Domain.Common.Specifications;
using ChallengeHAPSA.Domain.Horses;
using ChallengeHAPSA.Domain.Horses.Specifications;

namespace ChallengeHAPSA.Application.Queries
{
    internal sealed class GetHorsesQueryHandler : IQueryHandler<GetHorsesQuery, Result<IEnumerable<HorseDTO>>>
    {
        private readonly IHorseRepository _horseRepository;

        public GetHorsesQueryHandler(IHorseRepository horseRepository)
        {
            _horseRepository = horseRepository;
        }

        public async Task<Result<IEnumerable<HorseDTO>>> Handle(GetHorsesQuery request, CancellationToken cancellationToken)
        {
            // Status null trae habilitados y deshabilitados
            ISpecification<Horse>? spec = request.Status switch
            {
                true => new EnabledHorseSpecification(),
                false => new EnabledHorseSpecification().Not(),
                null => null,
            };

            if (!string.IsNullOrWhiteSpace(request.Name))
            {
                var nameSpec = new HorseNameContainsSpecification(request.Name.Trim());
                spec = spec is null ? nameSpec : spec.And(nameSpec);
            }

            if (request.Type is not null)
            {
                var typeSpec = new HorseOfTypeSpecification(request.Type.Value);
                spec = spec is null ? typeSpec : spec.And(typeSpec);
            }

            var query = this._horseRepository.QueryBuilder();

            if (spec is not null)
            {
                query = query.Where(spec.ToExpression());
            }

            var horses = await _horseRepository.ListAsync(query.OrderBy(n => n.Name));
            
            return horses.Select(h => new HorseDTO
            {
                Id = h.Id,
                Name = h.Name,
                Birthday = h.Birthday,
                Status = h.Status,
                Type = h.Type
            }).ToList();
        }
    }
}
