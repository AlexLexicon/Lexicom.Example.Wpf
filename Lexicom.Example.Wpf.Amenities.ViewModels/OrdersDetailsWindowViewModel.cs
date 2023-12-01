using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Lexicom.Example.Wpf.Amenities.Application.Models;
using Lexicom.Example.Wpf.Amenities.Application.Notifications;
using Lexicom.Example.Wpf.Amenities.Application.Services;
using Lexicom.Mvvm;
using MediatR;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Lexicom.Example.Wpf.Amenities.ViewModels;
public partial class OrdersDetailsWindowViewModel : ObservableObject, IShowableViewModel, INotificationHandler<NewOrderNotification>
{
    private readonly IViewModelFactory _viewModelFactory;
    private readonly IOrdersService _ordersService;

    public OrdersDetailsWindowViewModel(
        IViewModelFactory viewModelFactory,
        HeaderViewModel headerViewModel,
        IOrdersService ordersService)
    {
        _viewModelFactory = viewModelFactory;
        _headerViewModel = headerViewModel;

        _orderViewModels = [];
        _ordersService = ordersService;
    }

    [ObservableProperty]
    private HeaderViewModel _headerViewModel;
    [ObservableProperty]
    private ObservableCollection<OrderDetailsViewModel> _orderViewModels;
    public ICommand? ShowCommand { get; set; }

    public async Task Handle(NewOrderNotification notification, CancellationToken cancellationToken)
    {
        await LoadOrdersAsync();
    }

    [RelayCommand]
    private async Task LoadOrdersAsync()
    {
        OrderViewModels.Clear();

        var orders = await _ordersService.GetOrdersAsync();
        foreach (var order in orders)
        {
            var orderDetailsViewModel = _viewModelFactory.Create<OrderDetailsViewModel, Order>(order);

            OrderViewModels.Add(orderDetailsViewModel);
        }
    }
}
