using OSK.Hexagonal.MetaData;

namespace OSK.Maui.Screens.Ports
{
    /// <summary>
    /// Provides access to an objects with the capability of listening to the closure of a popup screen
    /// </summary>
    [HexagonalIntegration(HexagonalIntegrationType.LibraryProvided)]
    public interface IPopupWaiter
    {
        /// <summary>
        /// The popup being displayed to a user
        /// </summary>
        IScreenPopup Popup { get; }

        /// <summary>
        /// Waits for the popup to be closed by the user and returns a generic result
        /// </summary>
        /// <returns>A result from the popup to be returned to the caller</returns>
        Task<object?> WaitForCloseAsync();
    }
}
