using OSK.Hexagonal.MetaData;
using OSK.Maui.Screens.Models;

namespace OSK.Maui.Screens.Ports;

/// <summary>
/// Represents an object capable of performing navigation to a provided screen
/// </summary>
[HexagonalIntegration(HexagonalIntegrationType.IntegrationOptional)]
public interface IScreenNavigationHandler
{
    /// <summary>
    /// Navigates to the the provided route and displaying the provided screen type. This route must be registered via
    /// the <see cref="ServiceCollectionExtensions.AddScreen(IServiceCollection, string, Type, Type)"/> or similar method.
    /// </summary>
    /// <param name="descriptor">The <see cref="ScreenRouteDescriptor"/> that describes the route being navigated to</param>
    /// <param name="cancellationToken">A token to cancel the operation</param>
    /// <returns>The screen object that was navigated to</returns>
    Task<object> NavigateToAsync(ScreenRouteDescriptor descriptor, CancellationToken cancellationToken = default);
}
