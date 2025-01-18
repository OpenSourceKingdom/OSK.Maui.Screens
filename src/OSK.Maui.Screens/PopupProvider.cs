using OSK.Maui.Screens.Exceptions;
using OSK.Maui.Screens.Models;
using OSK.Maui.Screens.Ports;

namespace OSK.Maui.Screens
{
    public abstract class PopupProvider<TScreen>(IServiceProvider serviceProvider) : IPopupProvider
    {
        #region Variables

        protected IServiceProvider ServiceProvider => serviceProvider;

        #endregion

        #region IPopupHandlerProvider

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

        #endregion

        #region Helpers

        protected abstract ValueTask<PopupHandler> GetPopupHandlerAsync(PopupDescriptor descriptor, Page? parentPage, 
            CancellationToken cancellationToken);

        #endregion
    }
}
