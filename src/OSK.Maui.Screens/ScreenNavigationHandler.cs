using OSK.Maui.Screens.Exceptions;
using OSK.Maui.Screens.Models;
using OSK.Maui.Screens.Ports;

namespace OSK.Maui.Screens;

public abstract class ScreenNavigationHandler<TScreen>(IServiceProvider serviceProvider) : IScreenNavigationHandler
{
    #region Variables

    protected IServiceProvider ServiceProvider => serviceProvider;

    #endregion

    #region IScreenNavigationHandler

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

    protected abstract Task<TScreen> NavigateToScreenAsync(ScreenRouteDescriptor descriptor, CancellationToken cancellationToken);

    #endregion
}
