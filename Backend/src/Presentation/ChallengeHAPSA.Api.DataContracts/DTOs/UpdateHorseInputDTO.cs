
using System.ComponentModel.DataAnnotations;

namespace ChallengeHAPSA.Api.DataContracts.DTOs
{
    public class UpdateHorseInputDTO
    {
        [Required(ErrorMessage = "Es necesario indicar un nombre")]
        public string Name { get; set; }
    }
}
