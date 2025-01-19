using System.Windows.Input;
using OSK.Hexagonal.MetaData;

namespace OSK.Maui.Screens.Ports
{
    /// <summary>
    /// Provides a means of using the popup navigation system using <see cref="ICommand"/> style objects
    /// </summary>
    [HexagonalIntegration(HexagonalIntegrationType.LibraryProvided)]
    public interface IScreenPopupCommand: ICommand
    {
        Task<object?> ExecuteAsync();
    }
}
