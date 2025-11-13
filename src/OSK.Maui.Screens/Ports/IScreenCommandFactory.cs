using OSK.Hexagonal.MetaData;
using OSK.Maui.Screens.Models;

namespace OSK.Maui.Screens.Ports;

/// <summary>
/// Allows creating navigational commands using the library
/// </summary>
[HexagonalIntegration(HexagonalIntegrationType.LibraryProvided, HexagonalIntegrationType.ConsumerPointOfEntry)]
public interface IScreenCommandFactory
{
    /// <summary>
    /// Creates a command that will navigate using the specified screen navigation
    /// </summary>
    /// <param name="navigation">The navigation information</param>
    /// <returns>A command that will navigate to the screen specified in the navigation</returns>
    IScreenCommand CreateNavigationCommand(ScreenNavigation navigation);

    /// <summary>
    /// Creates a command that will navigate using the specified screen navigation
    /// </summary>
    /// <param name="navigation">The navigation information</param>
    /// <param name="parameters">THe parameters to intiialize the screen with upon navigation</param>
    /// <returns>A command that will navigate to the screen specified in the navigation</returns>
    IScreenCommand CreateNavigationCommand<TParameters>(ScreenNavigation navigation, TParameters parameters);

    /// <summary>
    /// Creates a command that will initiate displaying a popup
    /// </summary>
    /// <param name="navigation">The popup navigation</param>
    /// <returns>A command that will display a popup using the specified navigation information</returns>
    IScreenPopupCommand CreatePopupCommand(PopupNavigation navigation);

    /// <summary>
    /// Creates a command that will initiate displaying a popup
    /// </summary>
    /// <typeparam name="TPopup">The type of popup to show</typeparam>
    /// <typeparam name="TParameters">The type of parameters the popup uses for intialization</typeparam>
    /// <param name="navigation">The popup navigation</param>
    /// <param name="parameters">The parameters to initialize the popup with upon navigation</param>
    /// <returns>A command that will display a popup using the specified navigation information</returns>
    IScreenPopupCommand CreatePopupCommand<TPopup, TParameters>(PopupNavigation navigation, TParameters parameters)
        where TPopup : IScreenPopup<TParameters>;
}
