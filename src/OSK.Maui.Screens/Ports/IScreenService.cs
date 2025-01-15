using OSK.Hexagonal.MetaData;
using OSK.Maui.Screens.Models;

namespace OSK.Maui.Screens.Ports
{
    [HexagonalIntegration(HexagonalIntegrationType.LibraryProvided, HexagonalIntegrationType.ConsumerPointOfEntry)]
    public interface IScreenService
    {
        Task NavigateToScreenAsync(ScreenNavigation navigation, CancellationToken cancellationToken = default);

        Task<object?> OpenPopupAsync<TPopup>(PopupNavigation navigation, CancellationToken cancellationToken = default)
            where TPopup : IScreenPopup;
    }
}
