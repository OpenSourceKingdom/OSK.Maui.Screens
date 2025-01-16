using OSK.Maui.Screens.Ports;

namespace OSK.Maui.Screens
{
    public abstract class PopupHandlerProvider<TScreen>(IServiceProvider serviceProvider) : IPopupHandlerProvider
    {
        #region Variables

        protected IServiceProvider ServiceProvider => serviceProvider;

        #endregion

        #region IPopupHandlerProvider

        public PopupHandler GetPopupHandler(Type popupType, Page? parentPage = null)
        {
            ArgumentNullException.ThrowIfNull(popupType);
            if (!popupType.IsAssignableTo(typeof(Page)))
            {
                throw new InvalidNavigationException($"Popup Provider of type {GetType().FullName} only create popups of type {typeof(Page).FullName}.");
            }

            return GetPopupHandler(parentPage, popupType);
        }

        #endregion

        #region Helpers

        protected abstract PopupHandler GetPopupHandler(Page? parentPage, Type popupType);

        #endregion
    }
}
