using ChallengeHAPSA.Application;

namespace ChallengeHAPSA.Api.Helpers
{
    public static class ServiceConfigure
    {
        public static void AddMediatR(this IServiceCollection services)
        {
            // se escanea el assembly de Application, que es donde viven los handlers;
            // asi cada command/handler nuevo se registra solo, sin tocar esto
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(ApplicationAssemblyMarker).Assembly));
        }
    }
}
