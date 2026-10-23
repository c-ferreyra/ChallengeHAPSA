using ChallengeHAPSA.Repository.EFCore;

namespace ChallengeHAPSA.Api.Helpers
{
    public static class DependencyConfigure
    {
        public static void InstallDependencies(this IServiceCollection service, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Falta la cadena de conexion 'DefaultConnection' en la configuracion.");

            service.RegisterImplementations(connectionString);
        }
    }
}
