using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OSK.Maui.Screens.Ports;

namespace OSK.Maui.Screens
{
    public abstract class ScreenNavigationHandler<TScreen>(IServiceProvider serviceProvider) : IScreenNavigationHandler
    {
        #region Variables

        protected IServiceProvider ServiceProvider => serviceProvider;

        #endregion

        #region IScreenNavigationHandler

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

        protected abstract Task<TScreen> NavigateToScreenAsync(string route, Type screenType, CancellationToken cancellationToken);

        #endregion
    }
}
