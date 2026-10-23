using AutoMapper;
using ChallengeHAPSA.Api.DataContracts.DTOs;
using ChallengeHAPSA.Application.Commands;

namespace ChallengeHAPSA.Api.Infrastructure.Mappers.AutoMapper.Mappers
{
    internal sealed class UpdateHorseCommandMapper : Profile
    {
        public UpdateHorseCommandMapper()
        {
            _ = this.CreateMap<UpdateHorseInputDTO, UpdateHorseCommand>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
