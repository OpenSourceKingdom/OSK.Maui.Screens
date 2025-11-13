using OSK.Maui.Screens.Ports;

namespace OSK.Maui.Screens;

public abstract class PagePopup : Page, IScreenPopup
{
    public required IPopupHandler PopupHandler { set; protected get; }
}
