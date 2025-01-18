using OSK.Hexagonal.MetaData;

namespace OSK.Maui.Screens.Ports
{
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
        /// <param name="route">The route to navigate to</param>
        /// <param name="screenType">The screen to display at the route</param>
        /// <param name="cancellationToken">A token to cancel the operation</param>
        /// <returns>The screen object that was navigated to</returns>
        Task<object> NavigateToAsync(string route, Type screenType, CancellationToken cancellationToken = default);
    }
}
