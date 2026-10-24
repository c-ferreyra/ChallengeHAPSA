namespace ChallengeHAPSA.Api.DataContracts.DTOs
{
    public class HorseOutputDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public bool Status { get; set; }
    }
}
