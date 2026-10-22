namespace ChallengeHAPSA.Api.Helpers
{
    public static class ServiceConfigure
    {
        public static void AddMediatR(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(ServiceConfigure).Assembly));
        }
    }
}
