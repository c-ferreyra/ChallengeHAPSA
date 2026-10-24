using ChallengeHAPSA.Application.Ports.Commands;
using ChallengeHAPSA.Application.Ports.Queries;
using ChallengeHAPSA.Busses.Commands.MediatR;
using ChallengeHAPSA.Busses.Queries.MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ChallengeHAPSA.Busses.MediatR
{
    public static class ServiceInstaller
    {
        public static void RegisterImplementations(this IServiceCollection serviceCollection)
        {
            // el bus no tiene estado, asi que transient alcanza
            _ = serviceCollection.AddTransient<ICommandBus, CommandBus>();
            _ = serviceCollection.AddTransient<IQueryBus, QueryBus>();
        }
    }
}
