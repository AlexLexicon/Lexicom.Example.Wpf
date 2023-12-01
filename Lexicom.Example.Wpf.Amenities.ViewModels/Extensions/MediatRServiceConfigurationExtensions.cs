using Microsoft.Extensions.DependencyInjection;

namespace Lexicom.Example.Wpf.Amenities.ViewModels.Extensions;
public static class MediatRServiceConfigurationExtensions
{
    public static void RegisterForViewModels(this MediatRServiceConfiguration mediatRServiceConfiguration)
    {
        mediatRServiceConfiguration.RegisterServicesFromAssemblyContaining<AssemblyScanMarker>();
    }
}
