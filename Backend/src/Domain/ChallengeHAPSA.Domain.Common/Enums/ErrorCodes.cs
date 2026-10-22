using System.ComponentModel.DataAnnotations;

namespace ChallengeHAPSA.Domain.Common.Enums
{
    public enum ErrorCodes
    {
        [Display(Name = "Ocurrió un error inesperado")] // db, infra, nullpointers, etc.
        UNKNOWN_ERROR = -1,

        // 1 - 100: Example
        [Display(Name = "El nombre indicado para la <entidad> ya esta en uso")]
        EXAMPLE_NAME_IN_USE = 1,

        [Display(Name = "El nombre indicado para la <entidad> no esta permitido")]
        EXAMPLE_NAME_NOT_ALLOWED = 2,
    }
}
