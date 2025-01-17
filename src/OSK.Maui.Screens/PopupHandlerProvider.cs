using OSK.Maui.Screens.Ports;

namespace OSK.Maui.Screens
{
    public abstract class PopupHandlerProvider<TScreen>(IServiceProvider serviceProvider) : IPopupHandlerProvider
    {
        #region Variables

        protected IServiceProvider ServiceProvider => serviceProvider;

        #endregion

        #region IPopupHandlerProvider

        public ValueTask<PopupHandler> GetPopupHandlerAsync(Type popupType, Page? parentPage = null, 
            CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(popupType);
            if (!popupType.IsAssignableTo(typeof(Page)))
            {
                throw new InvalidNavigationException($"Popup Provider of type {GetType().FullName} only create popups of type {typeof(Page).FullName}.");
            }

            return GetPopupHandlerAsync(parentPage, popupType, cancellationToken);
        }

        #endregion

        #region Helpers

        protected abstract ValueTask<PopupHandler> GetPopupHandlerAsync(Page? parentPage, Type popupType, 
            CancellationToken cancellationToken);

        #endregion
    }
}
