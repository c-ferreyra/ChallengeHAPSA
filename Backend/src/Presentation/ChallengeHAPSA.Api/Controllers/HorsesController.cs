using ChallengeHAPSA.Application.Ports.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ChallengeHAPSA.Api.Infrastructure.Mappers.AutoMapper;
using ChallengeHAPSA.Api.DataContracts.DTOs;
using ChallengeHAPSA.Application.Commands;
using ChallengeHAPSA.Domain.Common;
using ChallengeHAPSA.Application.Queries;

namespace ChallengeHAPSA.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class HorsesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ICommandBus commandBus;

        public HorsesController(ICommandBus commandBus, IMapper mapper)
        {
            this.commandBus = commandBus ?? throw new ArgumentNullException(nameof(commandBus));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // GET: api/<HorsesController>
        //[HttpGet]
        //public async Task<IEnumerable<Result<HorseDTO>> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<HorsesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody] CreateHorseInputDTO inputDTO)
        {
            var command = this.mapper.Map<CreateHorseCommand>(inputDTO);
            var result = await this.commandBus.Send(command);

            return this.Ok(result);
        }

        public async Task<ActionResult> Update(Guid id, [FromBody] UpdateHorseInputDTO inputDTO)
        {
            var command = this.mapper.Map<UpdateHorseCommand>(inputDTO);
            command.Id = id;    

            var result = await this.commandBus.Send(command);
            return this.Ok(result);

        }

        // DELETE api/<HorsesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
