namespace Lexicom.Example.Wpf.Amenities.Application.Services;
public interface IWindowTitleService
{
    Task<string> GetMainWindowTitleAsync();
    Task<string> GetOrdersTitleAsync();
}
public class WindowTitleService : IWindowTitleService
{
    private readonly string _mainWindowTitle;
    private readonly string _ordersWindowTitle;

    public WindowTitleService()
    {
        _mainWindowTitle = $"Main [{Random.Shared.Next(10, 100)}] Window (scoped)";
        _ordersWindowTitle = $"Orders [{Random.Shared.Next(10, 100)}] Window (scoped)";
    }

    public Task<string> GetMainWindowTitleAsync()
    {
        return Task.FromResult(_mainWindowTitle);
    }

    public Task<string> GetOrdersTitleAsync()
    {
        return Task.FromResult(_ordersWindowTitle);
    }
}
