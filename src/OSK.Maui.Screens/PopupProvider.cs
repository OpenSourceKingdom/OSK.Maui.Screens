using OSK.Maui.Screens.Exceptions;
using OSK.Maui.Screens.Models;
using OSK.Maui.Screens.Ports;

namespace OSK.Maui.Screens
{
    public abstract class PopupProvider<TPopup>(IServiceProvider serviceProvider) : IPopupProvider
    {
        #region Variables

        protected IServiceProvider ServiceProvider => serviceProvider;

        #endregion

        #region IPopupHandlerProvider

        public ValueTask<PopupHandler> GetPopupAsync(PopupNavigation popupNavigation, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(popupNavigation?.PopupType);

            if (!popupNavigation.PopupType.IsAssignableTo(typeof(TPopup)))
            {
                throw new ScreenPopupNavigationException($"Popup Provider of type {GetType().FullName} can only create popups of type {typeof(TPopup).FullName}.");
            }

            return GetPopupHandlerAsync(popupNavigation, cancellationToken);
        }

        #endregion

        #region Helpers

        protected abstract ValueTask<PopupHandler> GetPopupHandlerAsync(PopupNavigation popupNavigation, 
            CancellationToken cancellationToken);

        #endregion
    }
}
