using CommunityToolkit.Mvvm.ComponentModel;
using Lexicom.Example.Wpf.Amenities.Application.Models;

namespace Lexicom.Example.Wpf.Amenities.ViewModels;
public partial class OrderDetailsViewModel : ObservableObject
{
    public OrderDetailsViewModel(Order order)
    {
        Order = order;
    }

    [ObservableProperty]
    private Order _order;
}
