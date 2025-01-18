using OSK.Hexagonal.MetaData;

namespace OSK.Maui.Screens.Ports
{
    /// <summary>
    /// A provider object that is capable of creating a popup handler that manages pressenting a popup to a user
    /// </summary>
    [HexagonalIntegration(HexagonalIntegrationType.IntegrationOptional)]
    public interface IPopupHandlerProvider
    {
        /// <summary>
        /// Gets a <see cref="PopupHandler"/> object that manages the interactions between a popup screen and consumers calling the method
        /// </summary>
        /// <param name="popupType">The <see cref="IScreenPopup"/> popup to show users</param>
        /// <param name="parentPage">A page that represents the anchored parent for the displayed popup</param>
        /// <param name="cancellationToken">A token to cancel the operation</param>
        /// <returns>The popup handler that was created by the provider</returns>
        ValueTask<PopupHandler> GetPopupHandlerAsync(Type popupType, Page? parentPage = null, 
            CancellationToken cancellationToken = default);
    }
}
