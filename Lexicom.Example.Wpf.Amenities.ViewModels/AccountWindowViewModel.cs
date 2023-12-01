using CommunityToolkit.Mvvm.ComponentModel;

namespace Lexicom.Example.Wpf.Amenities.ViewModels;
public partial class AccountWindowViewModel : ObservableObject
{
    public AccountWindowViewModel(HeaderViewModel headerViewModel)
    {
        _headerViewModel = headerViewModel;
    }

    [ObservableProperty]
    private HeaderViewModel _headerViewModel;
}
