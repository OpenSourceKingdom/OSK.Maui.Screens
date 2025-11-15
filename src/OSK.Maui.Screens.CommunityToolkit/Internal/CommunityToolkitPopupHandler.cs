using CommunityToolkit.Maui.Views;
using OSK.Maui.Screens.Ports;

namespace OSK.Maui.Screens.CommunityToolkit.Internal;

internal class CommunityToolkitPopupHandler(Popup popup, Page parent) : PopupHandler((IScreenPopup)popup)
{
    public override Task CloseAsync(object? result = null)
    {
        return popup.CloseAsync(result);
    }

    public override async Task<object?> WaitForCloseAsync()
    {
        return parent.ShowPopupAsync(popup);
    }
}
