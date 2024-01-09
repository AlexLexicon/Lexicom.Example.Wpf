using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Lexicom.Example.Wpf.Amenities.Application.Notifications;
using Lexicom.Example.Wpf.Amenities.ViewModels.RuleSets;
using Lexicom.Validation;
using MediatR;

namespace Lexicom.Example.Wpf.Amenities.ViewModels;
public partial class MainWindowViewModel : ObservableObject
{
    private readonly IMediator _mediator;

    public MainWindowViewModel(
        IMediator mediator,
        HeaderViewModel headerViewModel,
        FooterViewModel footerViewModel,
        IRuleSetValidator<OrderTextRuleSet, string?> orderTextValidator)
    {
        _mediator = mediator;
        _headerViewModel = headerViewModel;
        _footerViewModel = footerViewModel;
        _orderTextValidation = orderTextValidator.Validation;
        OrderTextIsValid = true;
    }

    [ObservableProperty]
    private HeaderViewModel _headerViewModel;
    [ObservableProperty]
    private FooterViewModel _footerViewModel;
    [ObservableProperty]
    private Func<string, IEnumerable<string>>? _orderTextValidation;
    [ObservableProperty]
    private string? _orderText;
    [ObservableProperty]
    private bool _orderTextIsValid;

    [RelayCommand]
    private async Task LoadedAsync()
    {
        await FooterViewModel.SetTitleAsync(true);
    }

    [RelayCommand]
    private async Task CreateOrderAsync()
    {
        if (!string.IsNullOrWhiteSpace(OrderText))
        {
            await _mediator.Publish(new NewOrderNotification
            {
                Text = OrderText
            });
        }
    }
}
