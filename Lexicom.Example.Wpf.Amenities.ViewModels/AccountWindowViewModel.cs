using CommunityToolkit.Mvvm.ComponentModel;

namespace Lexicom.Example.Wpf.Amenities.ViewModels;
public partial class AccountWindowViewModel : ObservableObject
{
    public AccountWindowViewModel(
        HeaderViewModel headerViewModel,
        FooterViewModel footerViewModel)
    {
        _headerViewModel = headerViewModel;
        _footerViewModel = footerViewModel;
    }

    [ObservableProperty]
    private HeaderViewModel _headerViewModel;
    [ObservableProperty]
    private FooterViewModel _footerViewModel;
}
