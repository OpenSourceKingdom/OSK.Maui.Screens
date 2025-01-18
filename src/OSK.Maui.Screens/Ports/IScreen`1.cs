using OSK.Hexagonal.MetaData;

namespace OSK.Maui.Screens.Ports
{
    /// <summary>
    /// Represents the main screen presented to a user. This provides a mechanism for strongly typed parameters to be passed to the screen.
    /// </summary>
    /// <typeparam name="TParameters">A strongly typed parameter object that is used to intiialize the screen</typeparam>
    [HexagonalIntegration(HexagonalIntegrationType.ConsumerOptional)]
    public interface IScreen<TParameters>: IScreen
    {
        /// <summary>
        /// Initializes a screen with a provided set of parameters
        /// </summary>
        /// <param name="parameters">A strongly typed parameter object to initialize the screen</param>
        /// <returns>The task for the operation</returns>
        Task InitializeScreenAsync(TParameters parameters);
    }
}
