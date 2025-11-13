using OSK.Maui.Screens.Ports;

namespace OSK.Maui.Screens.Blazor;

public abstract class BlazorPopupComponent: BlazorComponent, IScreenPopup
{
    public required IPopupHandler PopupHandler { get; set; }
}
