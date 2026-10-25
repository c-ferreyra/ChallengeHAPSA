using System.ComponentModel.DataAnnotations;

namespace ChallengeHAPSA.Domain.Common.Enums
{
    public enum ErrorCodes
    {
        [Display(Name = "Ocurrió un error inesperado")] // db, infra, nullpointers, etc.
        UNKNOWN_ERROR = -1,

        // 1 - 100: Example
        [Display(Name = "El nombre indicado para la <entidad> ya esta en uso")]
        HORSE_NAME_IN_USE = 1,

        [Display(Name = "El nombre indicado para la <entidad> no esta permitido")]
        HORSE_NAME_NOT_ALLOWED = 2,

        [Display(Name = "Este caballo ya esta deshabilitado")]
        HORSE_ALREADY_DISABLED = 3,

        [Display(Name = "Caballo no encontrado")]
        HORSE_NOT_FOUND = 4,

        [Display(Name = "Este caballo ya esta habilitado")]
        HORSE_ALREADY_ENABLED = 5,
    }
}
