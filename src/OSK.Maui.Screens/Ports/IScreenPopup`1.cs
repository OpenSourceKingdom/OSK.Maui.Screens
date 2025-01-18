using OSK.Hexagonal.MetaData;

namespace OSK.Maui.Screens.Ports
{
    /// <summary>
    /// Represents a popup to a user that has a provided mechanism to receive strongly typed parameters for initialization
    /// </summary>
    /// <typeparam name="TParameters">The type of parameters used to initialize the popup</typeparam>
    [HexagonalIntegration(HexagonalIntegrationType.IntegrationOptional)]
    public interface IScreenPopup<TParameters>: IScreenPopup
    {
        /// <summary>
        /// Initializes a popup with the given strongly typed parameters
        /// </summary>
        /// <param name="parameters">The parameters to initialize the popup</param>
        /// <returns>The task for the operation</returns>
        Task InitializePopupAsync(TParameters parameters);
    }
}
