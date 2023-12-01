using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Lexicom.Example.Wpf.Amenities.Application.Notifications;
using Lexicom.Mvvm;
using MediatR;

namespace Lexicom.Example.Wpf.Amenities.ViewModels;
public partial class HeaderViewModel : ObservableObject, INotificationHandler<NewOrderNotification>
{
    private readonly IViewModelFactory _viewModelFactory;

    public HeaderViewModel(IViewModelFactory viewModelFactory)
    {
        _viewModelFactory = viewModelFactory;
    }

    [ObservableProperty]
    public int _ordersCount;

    public Task Handle(NewOrderNotification notification, CancellationToken cancellationToken)
    {
        OrdersCount++;

        return Task.CompletedTask;
    }

    [RelayCommand]
    private void OpenMyAccountWindow()
    {

    }

    [RelayCommand]
    private void OpenOrdersDetailsWindow()
    {
        var ordersDetailsWindowViewModel = _viewModelFactory.Create<OrdersDetailsWindowViewModel>();

        ordersDetailsWindowViewModel.ShowCommand?.Execute(null);
    }
}
