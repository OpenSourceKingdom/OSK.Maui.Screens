using OSK.Maui.Screens.Ports;

namespace OSK.Maui.Screens
{
    public abstract class PopupHandler : IPopupHandler
    {
        public abstract Task<object?> WaitForCloseAsync();

        public abstract Task CloseAsync(object? result = null);
    }
}
