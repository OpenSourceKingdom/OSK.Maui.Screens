using System.Windows.Input;
using OSK.Hexagonal.MetaData;

namespace OSK.Maui.Screens.Ports;

/// <summary>
/// Provides a means of using the screen navigation system using <see cref="ICommand"/> style objects
/// </summary>
[HexagonalIntegration(HexagonalIntegrationType.LibraryProvided)]
public interface IScreenCommand: ICommand
{
    Task<object> ExecuteAsync();
}
