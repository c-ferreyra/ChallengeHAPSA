using IAutoMapper = AutoMapper.IMapper;
using IMapper = ChallengeHAPSA.Api.Infrastructure.Mappers.AutoMapper.IMapper;

namespace ChallengeHAPSA.Api.Infrastructure.Mappers.AutoMapper
{
    internal sealed class Mapper : IMapper
    {
        private readonly IAutoMapper mapper;

        public Mapper(IAutoMapper mapper)
        {
            this.mapper = mapper;
        }

        public T Map<T>(object source)
        {
            return this.mapper.Map<T>(source);
        }

        public T Map<T>(object source, T dest)
        {
            return this.mapper.Map(source, dest);
        }
    }
}
