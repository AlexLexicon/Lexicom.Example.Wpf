using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Lexicom.Example.Wpf.Amenities.Application.Notifications;
using MediatR;

namespace Lexicom.Example.Wpf.Amenities.ViewModels;
public partial class MainWindowViewModel : ObservableObject
{
    private static int TotalOrders { get; set; }

    private readonly IMediator _mediator;

    public MainWindowViewModel(
        IMediator mediator,
        HeaderViewModel headerViewModel)
    {
        _mediator = mediator;
        _headerViewModel = headerViewModel;
    }

    [ObservableProperty]
    private HeaderViewModel _headerViewModel;

    [RelayCommand]
    private void CreateOrder()
    {
        TotalOrders++;

        _mediator.Publish(new NewOrderNotification(TotalOrders, Guid.NewGuid().ToString()));
    }
}
