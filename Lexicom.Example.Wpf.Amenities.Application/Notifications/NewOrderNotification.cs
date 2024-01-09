using MediatR;

namespace Lexicom.Example.Wpf.Amenities.Application.Notifications;
public record class NewOrderNotification() : INotification
{
    public required string Text { get; init; }
}
