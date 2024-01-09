using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Lexicom.Example.Wpf.Amenities.Application.Notifications;
using Lexicom.Example.Wpf.Amenities.Application.Services;
using Lexicom.Mvvm;
using MediatR;

namespace Lexicom.Example.Wpf.Amenities.ViewModels;
public partial class HeaderViewModel : ObservableObject, INotificationHandler<NewOrderNotification>
{
    private readonly IViewModelFactory _viewModelFactory;
    private readonly IWindowTitleService _windowIdService;
    private readonly IOrdersService _ordersService;

    public HeaderViewModel(
        IViewModelFactory viewModelFactory,
        IWindowTitleService windowIdService,
        IOrdersService ordersService)
    {
        _viewModelFactory = viewModelFactory;
        _windowIdService = windowIdService;
        _ordersService = ordersService;
    }

    [ObservableProperty]
    private string? _windowId;
    [ObservableProperty]
    public int _ordersCount;

    public async Task Handle(NewOrderNotification notification, CancellationToken cancellationToken)
    {
        OrdersCount = await _ordersService.GetOrdersCountAsync();
    }

    [RelayCommand]
    private async Task LoadedAsync()
    {
        WindowId = await _windowIdService.GetMainWindowTitleAsync();
    }

    [RelayCommand]
    private void OpenOrdersDetailsWindow()
    {
        var ordersDetailsWindowViewModel = _viewModelFactory.Create<OrdersDetailsWindowViewModel>();

        ordersDetailsWindowViewModel.ShowCommand?.Execute(null);
    }
}
