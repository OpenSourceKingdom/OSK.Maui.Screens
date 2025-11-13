using OSK.Hexagonal.MetaData;
using OSK.Maui.Screens.Models;

namespace OSK.Maui.Screens.Ports;

/// <summary>
/// Handles screen routing and popup related functions for an application.
/// </summary>
[HexagonalIntegration(HexagonalIntegrationType.LibraryProvided, HexagonalIntegrationType.ConsumerPointOfEntry)]
public interface IScreenService
{
    /// <summary>
    /// Navigates to the screen that is associated with the provided navigation parameters.
    /// </summary>
    /// <param name="navigation">The navigation arguments</param>
    /// <param name="cancellationToken">A tokent to cancel the operation</param>
    /// <returns>The screen object that is displayed</returns>
    Task<object> NavigateToScreenAsync(ScreenNavigation navigation, CancellationToken cancellationToken = default);

    /// <summary>
    /// Shows the provided popup type to the user
    /// </summary>
    /// <typeparam name="TPopupNavigation">The type of popup navgia</typeparam>
    /// <param name="navigation">The popup navigation arguments</param>
    /// <param name="cancellationToken">A token to cancel the operation</param>
    /// <returns>An <see cref="IPopupWaiter"/> associated with the popup</returns>
    Task<IPopupWaiter> ShowPopupAsync<TPopupNavigation>(TPopupNavigation navigation, CancellationToken cancellationToken = default)
        where TPopupNavigation : PopupNavigation;
}
