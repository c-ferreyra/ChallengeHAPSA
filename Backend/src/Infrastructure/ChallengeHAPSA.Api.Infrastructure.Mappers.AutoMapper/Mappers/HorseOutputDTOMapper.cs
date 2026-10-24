using AutoMapper;
using ChallengeHAPSA.Api.DataContracts.DTOs;
using ChallengeHAPSA.Application.Queries;

namespace ChallengeHAPSA.Api.Infrastructure.Mappers.AutoMapper.Mappers
{
    internal sealed class HorseOutputDTOMapper : Profile
    {
        public HorseOutputDTOMapper()
        {
            _ = this.CreateMap<HorseDTO, HorseOutputDTO>();
        }
    }
}
