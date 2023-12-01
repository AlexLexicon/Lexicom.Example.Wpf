using Microsoft.Extensions.DependencyInjection;

namespace Lexicom.Example.Wpf.Amenities.Application.Extensions;
public static class MediatRServiceConfigurationExtensions
{
    public static void RegisterForApplication(this MediatRServiceConfiguration mediatRServiceConfiguration)
    {
        mediatRServiceConfiguration.RegisterServicesFromAssemblyContaining<AssemblyScanMarker>();
    }
}
