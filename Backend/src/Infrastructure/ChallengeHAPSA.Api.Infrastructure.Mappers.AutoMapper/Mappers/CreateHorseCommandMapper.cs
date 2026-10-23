using AutoMapper;
using ChallengeHAPSA.Api.DataContracts.DTOs;
using ChallengeHAPSA.Application.Commands;

namespace ChallengeHAPSA.Api.Infrastructure.Mappers.AutoMapper.Mappers
{
    internal sealed class CreateHorseCommandMapper : Profile
    {
        public CreateHorseCommandMapper()
        {
            _ = this.CreateMap<CreateHorseInputDTO, CreateHorseCommand>();
        }
    }
}
