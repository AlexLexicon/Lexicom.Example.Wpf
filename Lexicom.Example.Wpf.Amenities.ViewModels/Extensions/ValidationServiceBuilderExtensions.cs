using Lexicom.Validation;
using Lexicom.Validation.Extensions;

namespace Lexicom.Example.Wpf.Amenities.ViewModels.Extensions;
public static class ValidationServiceBuilderExtensions
{
    public static void AddViewModels(this IValidationServiceBuilder builder)
    {
        builder.AddRuleSets<AssemblyScanMarker>();
    }
}
