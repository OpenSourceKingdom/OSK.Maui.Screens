using OSK.Maui.Screens.Ports;

namespace OSK.Maui.Screens
{
    public abstract class PopupHandler(IScreenPopup popup) : IPopupHandler, IPopupWaiter
    {
        public IScreenPopup Popup => popup;

        public abstract Task<object?> WaitForCloseAsync();

        public abstract Task CloseAsync(object? result = null);
    }
}
