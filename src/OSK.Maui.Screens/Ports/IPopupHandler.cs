using OSK.Hexagonal.MetaData;

namespace OSK.Maui.Screens.Ports;

/// <summary>
/// Handles communication between a user and an <see cref="IScreenPopup"/> object
/// </summary>
[HexagonalIntegration(HexagonalIntegrationType.LibraryProvided)]
public interface IPopupHandler
{
    /// <summary>
    /// Close the popup and returns a provided result to the screen that requested the popup to be displayed
    /// </summary>
    /// <param name="result">The result of the popup's operation that can be used by the caller that requested the popup</param>
    /// <returns>A task representing the close operation</returns>
    Task CloseAsync(object? result = null);
}
