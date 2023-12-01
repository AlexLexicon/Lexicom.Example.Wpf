using Lexicom.Example.Wpf.Amenities.Application.Notifications;
using Lexicom.Example.Wpf.Amenities.Application.Services;
using MediatR;

namespace Lexicom.Example.Wpf.Amenities.Application.Handlers;
public class NewOrderNotificationHandler : INotificationHandler<NewOrderNotification>
{
    private readonly IOrdersService _ordersService;

    public NewOrderNotificationHandler(IOrdersService ordersService)
    {
        _ordersService = ordersService;
    }

    public async Task Handle(NewOrderNotification notification, CancellationToken cancellationToken)
    {
        await _ordersService.AddOrderAsync(notification.Index, notification.Name);
    }
}
