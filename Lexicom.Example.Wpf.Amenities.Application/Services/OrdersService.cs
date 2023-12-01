using Lexicom.Example.Wpf.Amenities.Application.Models;

namespace Lexicom.Example.Wpf.Amenities.Application.Services;
public interface IOrdersService
{
    Task AddOrderAsync(int index, string name);
    Task<IReadOnlyList<Order>> GetOrdersAsync();
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

    public Task AddOrderAsync(int index, string name)
    {
        _orders.Add(new Order
        {
            Index = index,
            Name = name,
        });

        return Task.CompletedTask;
    }
}
