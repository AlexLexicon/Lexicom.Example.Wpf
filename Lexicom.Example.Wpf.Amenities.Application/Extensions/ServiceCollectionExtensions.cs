using Lexicom.Example.Wpf.Amenities.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Lexicom.Example.Wpf.Amenities.Application.Extensions;
public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddSingleton<IOrdersService, OrdersService>();

        services.AddScoped<IWindowTitleService, WindowTitleService>();
        services.AddTransient<IWindowIdService, WindowIdService>();
    }
}
