using System.ComponentModel.DataAnnotations;

namespace ChallengeHAPSA.Api.DataContracts.DTOs
{
    public class CreateHorseInputDTO
    {
        [Required(ErrorMessage = "Es necesario indicar un nombre")]
        public string Name { get; set; }

        // nullable a proposito: con DateTime no-nullable, un birthday ausente en el json
        // cae en default(DateTime) y [Required] lo deja pasar
        [Required(ErrorMessage = "Es necesario indicar la fecha de nacimiento")]
        public DateTime? Birthday { get; set; }

        // nullable por el mismo motivo que Birthday: sin el ?, un type ausente cae en Racehorse
        [Required(ErrorMessage = "Es necesario indicar el tipo")]
        public HorseTypeDTO? Type { get; set; }
    }
}
