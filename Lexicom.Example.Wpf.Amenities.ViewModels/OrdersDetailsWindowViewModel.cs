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
    private readonly IWindowTitleService _windowTitleService;

    public OrdersDetailsWindowViewModel(
        FooterViewModel footerViewModel,
        IViewModelFactory viewModelFactory,
        IOrdersService ordersService,
        IWindowTitleService windowTitleService)
    {
        _footerViewModel = footerViewModel;

        _viewModelFactory = viewModelFactory;
        _ordersService = ordersService;
        _windowTitleService = windowTitleService;

        _orderViewModels = [];
    }

    [ObservableProperty]
    private string? _title;
    [ObservableProperty]
    private int _ordersCount;
    [ObservableProperty]
    private FooterViewModel? _footerViewModel;
    [ObservableProperty]
    private ObservableCollection<OrderDetailsViewModel> _orderViewModels;
    public ICommand? ShowCommand { get; set; }

    public async Task Handle(NewOrderNotification notification, CancellationToken cancellationToken)
    {
        await LoadOrdersAsync();
    }

    [RelayCommand]
    private async Task LoadedAsync()
    {
        FooterViewModel = _viewModelFactory.Create<FooterViewModel>();

        Title = await _windowTitleService.GetOrdersTitleAsync();

        await FooterViewModel.SetTitleAsync(false);

        await LoadOrdersAsync();
    }

    private async Task LoadOrdersAsync()
    {
        OrderViewModels.Clear();

        IReadOnlyList<Order> orders = await _ordersService.GetOrdersAsync();
        foreach (Order order in orders)
        {
            var orderDetailsViewModel = _viewModelFactory.Create<OrderDetailsViewModel, Order>(order);

            OrderViewModels.Add(orderDetailsViewModel);
        }

        OrdersCount = await _ordersService.GetOrdersCountAsync();
    }
}
