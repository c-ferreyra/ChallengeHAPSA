namespace ChallengeHAPSA.Api.Infrastructure.Mappers.AutoMapper
{
    public interface IMapper
    {
        T Map<T>(object source);
        T Map<T>(object source, T dest);
    }
}
