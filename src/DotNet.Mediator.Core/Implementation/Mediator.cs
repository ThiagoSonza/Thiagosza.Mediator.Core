using DotNet.Mediator.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DotNet.Mediator.Core.Implementation
{
    public class Mediator : IMediator
    {
        private readonly IServiceProvider serviceProvider;

        public Mediator(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default)
        {
            var requestType = request.GetType();
            var handlerType = typeof(IRequestHandler<,>).MakeGenericType(requestType, typeof(TResponse));

            var handler = serviceProvider.GetService(handlerType)
                ?? throw new InvalidOperationException($"Handler for {requestType.Name} not found");

            var method = handlerType.GetMethod("Handle")
                ?? throw new InvalidOperationException($"Method not found for {requestType.Name}");

            var result = method.Invoke(handler, new object[] { request, cancellationToken });
            if (!(result is Task<TResponse> task))
                throw new InvalidOperationException($"Method returned unexpected type {result}");

            return await task;
        }

        public async Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default) where TNotification : INotification
        {
            var notificationType = notification.GetType();
            var handlerType = typeof(INotificationHandler<>).MakeGenericType(notificationType);

            var handlers = serviceProvider.GetServices(handlerType);

            foreach (var handler in handlers)
            {
                var method = handlerType.GetMethod("Handle")
                    ?? throw new InvalidOperationException($"Method not found for {notificationType.Name}");

                await (Task)method
                    .Invoke(handler, new object[] { notification, cancellationToken });
            }
        }
    }
}
