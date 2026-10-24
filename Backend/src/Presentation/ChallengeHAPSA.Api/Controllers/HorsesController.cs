using ChallengeHAPSA.Application.Ports.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ChallengeHAPSA.Api.Infrastructure.Mappers.AutoMapper;
using ChallengeHAPSA.Api.DataContracts.DTOs;
using ChallengeHAPSA.Application.Commands;
using ChallengeHAPSA.Application.Ports.Queries;
using ChallengeHAPSA.Domain.Common;
using ChallengeHAPSA.Application.Queries;
using ChallengeHAPSA.Api.Helpers;

namespace ChallengeHAPSA.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class HorsesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ICommandBus commandBus;
        private readonly IQueryBus queryBus;

        public HorsesController(ICommandBus commandBus, IMapper mapper, IQueryBus queryBus)
        {
            this.commandBus = commandBus ?? throw new ArgumentNullException(nameof(commandBus));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.queryBus = queryBus ?? throw new ArgumentNullException(nameof(queryBus));
        }

        // GET: api/<HorsesController>
        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] bool? status)
        {
            // con bool? el default del parametro no aplica: la clave ausente bindea a null.
            // El ?? true mantiene el requisito de listar solo habilitados por defecto.
            var result = await this.queryBus.Send(new GetHorsesQuery { Status = status ?? true });

            if (result.IsFailure)
            {
                return this.ToActionResult(result);
            }

            var horses = this.mapper.Map<IEnumerable<HorseOutputDTO>>(result.Value!);

            return this.Ok(Result<IEnumerable<HorseOutputDTO>>.Success(horses));
        }

        // GET api/<HorsesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            var result = await this.queryBus.Send(new GetHorseByIdQuery { Id = id });

            if (result.IsFailure)
            {
                return this.ToActionResult(result);
            }

            var horse = this.mapper.Map<HorseOutputDTO>(result.Value!);

            return this.Ok(Result<HorseOutputDTO>.Success(horse));
        }

        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody] CreateHorseInputDTO inputDTO)
        {
            var command = this.mapper.Map<CreateHorseCommand>(inputDTO);
            var result = await this.commandBus.Send(command);

            return this.ToActionResult(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, [FromBody] UpdateHorseInputDTO inputDTO)
        {
            var command = this.mapper.Map<UpdateHorseCommand>(inputDTO);
            command.Id = id;    

            var result = await this.commandBus.Send(command);
            return this.ToActionResult(result);

        }

        // DELETE api/<HorsesController>/5
        [HttpPatch("{id}")]
        public async Task<ActionResult> Disable(Guid id)
        {
            var command = new DisableHorseCommand { Id = id };
            var result = await this.commandBus.Send(command);

            return this.ToActionResult(result);
        }
    }
}
