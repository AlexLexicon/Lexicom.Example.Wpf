using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Lexicom.Example.Wpf.Amenities.Application.Notifications;
using Lexicom.Example.Wpf.Amenities.ViewModels.RuleSets;
using Lexicom.Validation;
using MediatR;
using System.Collections.ObjectModel;

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
        _orderTextValidator = orderTextValidator;

        OrderTextIsValid = true;
        OrderTextErrors = [];
    }

    [ObservableProperty]
    private HeaderViewModel _headerViewModel;
    [ObservableProperty]
    private FooterViewModel _footerViewModel;
    [ObservableProperty]
    private IRuleSetValidator<OrderTextRuleSet, string?> _orderTextValidator;
    [ObservableProperty]
    private string? _orderText;
    [ObservableProperty]
    private bool _orderTextIsValid;
    [ObservableProperty]
    private ObservableCollection<string> _orderTextErrors;

    [RelayCommand]
    private async Task LoadedAsync()
    {
        await FooterViewModel.SetTitleAsync(true);
    }

    [RelayCommand]
    private void OrderTextValidated()
    {
        OrderTextErrors.Clear();
        foreach (string error in OrderTextValidator.ValidationErrors)
        {
            OrderTextErrors.Add(error);
        }
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
