using ChallengeHAPSA.Application.Ports.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ChallengeHAPSA.Api.Infrastructure.Mappers.AutoMapper;
using ChallengeHAPSA.Api.DataContracts.DTOs;
using ChallengeHAPSA.Application.Commands;

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
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

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

        // PUT api/<HorsesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HorsesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
