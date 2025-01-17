using OSK.Maui.Screens.Ports;

namespace OSK.Maui.Screens
{
    public abstract class PopupHandler : IPopupHandler, IPopupWaiter
    {
        #region Constructors

        public PopupHandler(IScreenPopup popup)
        {
            Popup = popup;

            Popup.PopupHandler = this;
        }

        #endregion

        #region IPopupHandler, IPopupWaiter
        public IScreenPopup Popup { get; private set; }

        public abstract Task<object?> WaitForCloseAsync();

        public abstract Task CloseAsync(object? result = null);

        #endregion
    }
}
