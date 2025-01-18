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
        /// <param name="descriptor">The <see cref="PopupDescriptor"/> that describes the popup to show users</param>
        /// <param name="parentPage">A page that represents the anchored parent for the displayed popup</param>
        /// <param name="cancellationToken">A token to cancel the operation</param>
        /// <returns>The popup handler that was created by the provider</returns>
        ValueTask<PopupHandler> GetPopupAsync(PopupDescriptor descriptor, Page? parentPage = null, 
            CancellationToken cancellationToken = default);
    }
}
