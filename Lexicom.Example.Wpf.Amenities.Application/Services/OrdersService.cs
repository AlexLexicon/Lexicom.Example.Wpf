using Lexicom.Example.Wpf.Amenities.Application.Models;

namespace Lexicom.Example.Wpf.Amenities.Application.Services;
public interface IOrdersService
{
    Task AddOrderAsync(string text);
    Task<IReadOnlyList<Order>> GetOrdersAsync();
    Task<int> GetOrdersCountAsync();
}
public class OrdersService : IOrdersService
{
    private readonly List<Order> _orders;

    public OrdersService()
    {
        _orders = [];
    }

    public Task<IReadOnlyList<Order>> GetOrdersAsync()
    {
        return Task.FromResult<IReadOnlyList<Order>>(_orders);
    }

    public async Task AddOrderAsync(string text)
    {
        int count = await GetOrdersCountAsync();

        _orders.Add(new Order
        {
            Index = count,
            Text = text,
        });
    }

    public Task<int> GetOrdersCountAsync()
    {
        return Task.FromResult(_orders.Count);
    }
}
