using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace ChallengeHAPSA.Api.Infrastructure.Mappers.AutoMapper
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
