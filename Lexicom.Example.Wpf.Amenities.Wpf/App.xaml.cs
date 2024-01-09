using Lexicom.Configuration.Settings.For.Wpf.Extensions;
using Lexicom.Example.Wpf.Amenities.Application.Extensions;
using Lexicom.Example.Wpf.Amenities.ViewModels;
using Lexicom.Example.Wpf.Amenities.ViewModels.Extensions;
using Lexicom.Mvvm.Amenities.Extensions;
using Lexicom.Mvvm.Extensions;
using Lexicom.Mvvm.For.Wpf.Extensions;
using Lexicom.Supports.Wpf.Extensions;
using Lexicom.Validation.Amenities.Extensions;
using Lexicom.Validation.Extensions;
using Lexicom.Validation.For.Wpf.Extensions;
using Lexicom.Wpf.Amenities.Extensions;
using Lexicom.Wpf.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Lexicom.Example.Wpf.Amenities.Wpf;
public partial class App : System.Windows.Application
{
    public App()
    {
        var builder = WpfApplication.CreateBuilder(this);

        builder.Services.AddApplication();

        builder.Lexicom(l =>
        {
            l.AddMvvm(options =>
            {
                options.AddMediatR(options =>
                {
                    options.Lifetime = ServiceLifetime.Singleton;
                    options.RegisterForApplication();
                    options.RegisterForViewModels();
                });

                options.AddViewModel<MainWindowViewModel>(options =>
                {
                    options.ForWindow<MainWindowView>();
                });
                options.AddViewModel<AccountWindowViewModel>(options =>
                {
                    options.ServiceLifetime = ServiceLifetime.Transient;
                    options.ForWindow<AccountWindowView>();
                });
                options.AddViewModel<OrdersDetailsWindowViewModel>(options =>
                {
                    options.ServiceLifetime = ServiceLifetime.Transient;
                    options.ForWindow<OrdersDetailsWindowView>();
                });
                options.AddViewModel<FooterViewModel>(ServiceLifetime.Transient);
                options.AddViewModel<HeaderViewModel>(ServiceLifetime.Scoped);
                options.AddViewModel<OrderDetailsViewModel>(ServiceLifetime.Scoped);
            });
            l.AddAmenities();
            l.AddSettings(Wpf.Properties.Settings.Default);
            l.AddValidation(options =>
            {
                options.AddAmenities();
                options.AddViewModels();
            });
        });

        //var xxxxxx = builder.Services.ToReadableJsonForDebugging();

        var app = builder.Build();

        //var yyyy = app.Services.GetRequiredService<IEnumerable<INotificationHandler<NewOrderNotification>>>();

        app.StartupWindow<MainWindowView>();
    }
}

