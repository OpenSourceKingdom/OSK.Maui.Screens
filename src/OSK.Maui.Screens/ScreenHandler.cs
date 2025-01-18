using OSK.Maui.Screens.Exceptions;
using OSK.Maui.Screens.Models;
using OSK.Maui.Screens.Ports;

namespace OSK.Maui.Screens
{
    public abstract class ScreenHandler<TScreen>(IServiceProvider serviceProvider): IScreenHandler
    {
        #region Variables

        protected IServiceProvider ServiceProvider => serviceProvider;

        #endregion

        #region IScreenHandler

        public ValueTask<PopupHandler> GetPopupAsync(PopupDescriptor descriptor, Page? parentPage = null,
            CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(descriptor?.PopupType);
            ArgumentNullException.ThrowIfNull(descriptor.PopupProviderType);

            if (!descriptor.PopupType.IsAssignableTo(typeof(TScreen)))
            {
                throw new ScreenPopupNavigationException($"Popup Provider of type {GetType().FullName} can only create popups of type {typeof(TScreen).FullName}.");
            }

            return GetPopupHandlerAsync(descriptor, parentPage, cancellationToken);
        }

        public async Task<object> NavigateToAsync(ScreenRouteDescriptor descriptor, CancellationToken cancellationToken = default)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(descriptor?.Route);
            ArgumentNullException.ThrowIfNull(descriptor.ScreenHandlerType);
            ArgumentNullException.ThrowIfNull(descriptor.ScreenType);

            if (!descriptor.ScreenType.IsAssignableTo(typeof(TScreen)))
            {
                throw new ScreenNavigationException($"Navigation Handler {GetType().FullName} can only navigate to screens of type {typeof(TScreen).FullName}.");
            }

            var screen = await NavigateToScreenAsync(descriptor, cancellationToken);
            if (screen is null)
            {
                throw new ScreenNavigationException("Unable to navigate to screen.");
            }

            return screen;
        }

        #endregion

        #region Helpers

        protected abstract ValueTask<PopupHandler> GetPopupHandlerAsync(PopupDescriptor descriptor, Page? parentPage, CancellationToken cancellationToken = default);
        protected abstract Task<TScreen> NavigateToScreenAsync(ScreenRouteDescriptor descriptor, CancellationToken cancellationToken);

        #endregion
    }
}
