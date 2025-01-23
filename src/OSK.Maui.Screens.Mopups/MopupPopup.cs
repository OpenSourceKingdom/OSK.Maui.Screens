using Mopups.Pages;
using OSK.Maui.Screens.Ports;

namespace OSK.Maui.Screens.Mopups
{
    public class MopupPopup : PopupPage, IScreenPopup
    {
        public required IPopupHandler PopupHandler { set; protected get; }
    }
}
