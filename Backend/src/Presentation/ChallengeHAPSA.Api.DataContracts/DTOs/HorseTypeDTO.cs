using System.Text.Json.Serialization;

namespace ChallengeHAPSA.Api.DataContracts.DTOs
{
    // espejo de Domain.Horses.HorseType (DataContracts no referencia al dominio); AutoMapper mapea por nombre.
    // En el json viaja en minuscula, que es como lo tipa el front
    public enum HorseTypeDTO
    {
        [JsonStringEnumMemberName("racehorse")]
        Racehorse = 0,

        [JsonStringEnumMemberName("stallion")]
        Stallion = 1,
    }
}
