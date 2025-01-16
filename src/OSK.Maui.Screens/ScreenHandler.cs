using OSK.Maui.Screens.Ports;

namespace OSK.Maui.Screens
{
    public abstract class ScreenHandler<TScreen>(IServiceProvider serviceProvider): IScreenHandler
    {
        #region Variables

        protected IServiceProvider ServiceProvider => serviceProvider;

        #endregion

        #region IScreenHandler

        public PopupHandler GetPopupHandler(Type popupType, Page? parentPage = null)
        {
            ArgumentNullException.ThrowIfNull(popupType);
            if (!popupType.IsAssignableTo(typeof(Page)))
            {
                throw new InvalidNavigationException($"Popup Provider of type {GetType().FullName} only create popups of type {typeof(Page).FullName}.");
            }

            return GetPopupHandler(parentPage, popupType);
        }

        public async Task<object> NavigateToAsync(string route, Type screenType, CancellationToken cancellationToken = default)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(route);
            ArgumentNullException.ThrowIfNull(screenType);
            if (!screenType.IsAssignableTo(typeof(TScreen)))
            {
                throw new InvalidNavigationException($"Navigation Handler {GetType().FullName} can only navigate to screens of type {typeof(TScreen).FullName}.");
            }

            var screen = await NavigateToScreenAsync(route, screenType, cancellationToken);
            if (screen is null)
            {
                throw new InvalidNavigationException("Unable to navigate to screen.");
            }

            return screen;
        }

        #endregion

        #region Helpers

        protected abstract PopupHandler GetPopupHandler(Page? parentPage, Type popupType);
        protected abstract Task<TScreen> NavigateToScreenAsync(string route, Type screenType, CancellationToken cancellationToken);

        #endregion
    }
}
