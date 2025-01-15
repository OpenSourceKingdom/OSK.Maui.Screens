using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using OSK.Maui.Screens.Ports;

namespace OSK.Maui.Screens
{
    public abstract class ScreenHandler<TScreen>(IServiceProvider serviceProvider): IScreenHandler
    {
        #region Variables

        protected IServiceProvider ServiceProvider => serviceProvider;

        #endregion

        #region IScreenHandler

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

        protected abstract ValueTask<PopupHandler> GetPopupHandlerAsync(Page? parentPage, Type popupType, CancellationToken cancellationToken);
        protected abstract Task<TScreen> NavigateToScreenAsync(string route, Type screenType, CancellationToken cancellationToken);

        #endregion
    }
}
