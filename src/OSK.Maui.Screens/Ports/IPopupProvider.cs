using OSK.Hexagonal.MetaData;
using OSK.Maui.Screens.Models;

namespace OSK.Maui.Screens.Ports
{
    /// <summary>
    /// A provider object that is capable of creating a popup handler that manages pressenting a popup to a user
    /// </summary>
    [HexagonalIntegration(HexagonalIntegrationType.IntegrationOptional)]
    public interface IPopupProvider
    {
        /// <summary>
        /// Gets a <see cref="PopupHandler"/> object that manages the interactions between a popup screen and consumers calling the method
        /// </summary>
        /// <param name="popupNavigation">The <see cref="PopupNavigation"/> that describes the popup to show users</param>
        /// <param name="cancellationToken">A token to cancel the operation</param>
        /// <returns>The popup handler that was created by the provider</returns>
        ValueTask<PopupHandler> GetPopupAsync(PopupNavigation popupNavigation, CancellationToken cancellationToken = default);
    }
}
