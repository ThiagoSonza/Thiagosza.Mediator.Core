using System.Threading;
using System.Threading.Tasks;

namespace Thiagosza.Mediator.Core.Interfaces
{
    public interface INotificationHandler<in TNotification>
        where TNotification : INotification
    {
        Task Handle(TNotification notification, CancellationToken cancellationToken);
    }
}
