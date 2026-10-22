using System.Reflection;
using ChallengeHAPSA.Api.Infrastructure.Mappers.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Infrastructure.Mappers.AutoMapper
{
    public static class ServiceInstaller
    {
        public static void RegisterImplementations(this IServiceCollection serviceCollection)
        {
            _ = serviceCollection.AddAutoMapper(cfg => cfg.DisableConstructorMapping(), Assembly.GetExecutingAssembly());

            _ = serviceCollection.AddScoped<IMapper, Mapper>();
        }
    }
}
