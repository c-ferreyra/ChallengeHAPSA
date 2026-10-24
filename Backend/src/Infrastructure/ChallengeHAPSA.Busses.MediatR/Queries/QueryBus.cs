using ChallengeHAPSA.Application.Ports.Queries;
using MediatR;

namespace ChallengeHAPSA.Busses.Queries.MediatR
{
    internal class QueryBus : IQueryBus
    {
        private readonly ISender sender;

        public QueryBus(ISender sender)
        {
            this.sender = sender;
        }

        public Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
        {
            return this.sender.Send(request, cancellationToken);
        }

        public Task<object> Send(object request, CancellationToken cancellationToken = default)
        {
            return this.sender.Send(request, cancellationToken);
        }

        public IAsyncEnumerable<TResponse> CreateStream<TResponse>(IStreamRequest<TResponse> request, CancellationToken cancellationToken = default) => throw new System.NotImplementedException();

        public IAsyncEnumerable<object> CreateStream(object request, CancellationToken cancellationToken = default) => throw new System.NotImplementedException();

        public Task Send<TRequest>(TRequest request, CancellationToken cancellationToken = default) where TRequest : IRequest => throw new System.NotImplementedException();
    }
}
