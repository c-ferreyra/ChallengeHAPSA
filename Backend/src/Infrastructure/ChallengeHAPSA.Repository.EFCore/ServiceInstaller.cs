using ChallengeHAPSA.Domain.Horses;
using ChallengeHAPSA.Repository.EFCore.Context;
using ChallengeHAPSA.Repository.EFCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ChallengeHAPSA.Repository.EFCore
{
    public static class ServiceInstaller
    {
        public static void RegisterImplementations(this IServiceCollection serviceCollection, string connectionString)
        {
            _ = serviceCollection.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            _ = serviceCollection.AddScoped<IHorseRepository, HorseRepository>();
        }
    }
}
