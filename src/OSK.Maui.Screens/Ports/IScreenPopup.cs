using OSK.Hexagonal.MetaData;

namespace OSK.Maui.Screens.Ports
{
    /// <summary>
    /// Represents a screen that is meant to be a popup
    /// </summary>
    [HexagonalIntegration(HexagonalIntegrationType.ConsumerOptional)]
    public interface IScreenPopup: IScreen
    {
        IPopupHandler PopupHandler { set; }
    }
}
