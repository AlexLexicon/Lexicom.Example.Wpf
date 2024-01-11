using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Lexicom.Example.Wpf.Amenities.Application.Services;

namespace Lexicom.Example.Wpf.Amenities.ViewModels;
public partial class FooterViewModel : ObservableObject
{
    private readonly IWindowIdService _transientStringService;
    private readonly IWindowTitleService _windowTitleService;

    public FooterViewModel(
        IWindowIdService transientStringService, 
        IWindowTitleService windowTitleService)
    {
        _transientStringService = transientStringService;
        _windowTitleService = windowTitleService;
    }

    [ObservableProperty]
    private string? _windowId;
    [ObservableProperty]
    private string? _title;

    public async Task SetTitleAsync(bool isMain)
    {
        if (isMain)
        {
            Title = await _windowTitleService.GetMainWindowTitleAsync();
        }
        else
        {
            Title = await _windowTitleService.GetOrdersTitleAsync();
        }
    }

    [RelayCommand]
    private async Task LoadedAsync()
    {
        WindowId = await _transientStringService.GetWindowIdAsync();
    }
}
