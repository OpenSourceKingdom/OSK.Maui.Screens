using OSK.Maui.Screens.Exceptions;
using OSK.Maui.Screens.Models;

namespace OSK.Maui.Screens.Internal.Services
{
    internal class PageScreenHandler(IServiceProvider serviceProvider) : ScreenHandler<Page>(serviceProvider)
    {
        #region ScreenHandler Overrides

        protected override ValueTask<PopupHandler> GetPopupHandlerAsync(PopupNavigation popupNavigation,
            CancellationToken cancellationToken)
        {
            var popup = (Page)ServiceProvider.GetRequiredService(popupNavigation.PopupType);

            if (popupNavigation.ParentPage is not null)
            {
                return new ValueTask<PopupHandler>(new PagePopupHandler(popupNavigation.ParentPage.Navigation, popup));
            }

            if (Shell.Current is not null)
            {
                return new ValueTask<PopupHandler>(new PagePopupHandler(Shell.Current.Navigation, popup));
            }

            if (Application.Current?.MainPage is null)
            {
                throw new ScreenPopupNavigationException("Unable to create a popup without a current application set.");
            }

            return new ValueTask<PopupHandler>(new PagePopupHandler(Application.Current.MainPage.Navigation, popup));
        }

        protected override async Task<Page> NavigateToScreenAsync(ScreenRouteDescriptor descriptor, CancellationToken cancellationToken)
        {            
            var screen = (Page)ServiceProvider.GetRequiredService(descriptor.ScreenType);

            // App Shell
            if (Shell.Current != null)
            {
                await Shell.Current.GoToAsync(new ShellNavigationState(descriptor.Route));
                return screen;
            }

            if (Application.Current is null)
            {
                throw new ScreenNavigationException("Unable to navigate to a page without a current application set.");
            }

            if (Application.Current.MainPage is NavigationPage navigationPage)
            {
                await navigationPage.PushAsync(screen);
            }
            else
            {
                Application.Current.MainPage = screen;
            }

            return screen;
        }

        #endregion
    }
}
