using CommunityToolkit.Mvvm.ComponentModel;
using Lexicom.Example.Wpf.Amenities.Application.Models;
using Lexicom.Example.Wpf.Amenities.Application.Notifications;
using Lexicom.Example.Wpf.Amenities.Application.Services;
using MediatR;

namespace Lexicom.Example.Wpf.Amenities.ViewModels;
public partial class OrderDetailsViewModel : ObservableObject
{
    private readonly IOrdersService _ordersService;

    public OrderDetailsViewModel(
        Order order, 
        IOrdersService ordersService)
    {
        Order = order;
        _ordersService = ordersService;
    }

    [ObservableProperty]
    private Order _order;
}
