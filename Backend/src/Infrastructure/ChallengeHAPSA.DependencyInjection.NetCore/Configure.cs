using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChallengeHAPSA.DependencyInjection.NetCore
{
    public static class Configure
    {
        public static void InstallDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Falta la cadena de conexion 'DefaultConnection' en la configuracion.");

            // se llaman como estaticos (y no con sintaxis de extension) porque todos los
            // instaladores exponen el mismo nombre de metodo; asi queda claro de que capa es cada uno
            Repository.EFCore.ServiceInstaller.RegisterImplementations(services, connectionString);
            Busses.MediatR.ServiceInstaller.RegisterImplementations(services);
            Api.Infrastructure.Mappers.AutoMapper.ServiceInstaller.RegisterImplementations(services);
        }
    }
}
