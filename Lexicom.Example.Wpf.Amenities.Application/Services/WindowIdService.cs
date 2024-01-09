namespace Lexicom.Example.Wpf.Amenities.Application.Services;
public interface IWindowIdService
{
    Task<string> GetWindowIdAsync();
}
public class WindowIdService : IWindowIdService
{
    private readonly string _windowId;

    public WindowIdService()
    {
        _windowId = $"Id: {Random.Shared.Next(10000, 100000)} (transient)";
    }

    public Task<string> GetWindowIdAsync()
    {
        return Task.FromResult(_windowId);
    }
}
