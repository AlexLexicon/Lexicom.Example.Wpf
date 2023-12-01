using MediatR;

namespace Lexicom.Example.Wpf.Amenities.Application.Notifications;
public record class NewOrderNotification(int Index, string Name) : INotification
{
}
