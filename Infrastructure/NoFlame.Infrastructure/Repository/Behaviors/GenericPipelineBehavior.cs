using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace NoFlame.Infrastructure.Repository.Behaviors
{
    public class GenericPipelineBehavior<TRequest,TResponse> :IPipelineBehavior<TRequest,TResponse>
    {
        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            return next.Invoke();
        }
    }
}