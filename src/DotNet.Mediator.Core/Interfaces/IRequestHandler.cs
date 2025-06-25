using System.Threading;
using System.Threading.Tasks;

namespace Thiagosza.Mediator.Core.Interfaces
{
    public interface IRequestHandler<in TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken = default);
    }
}
