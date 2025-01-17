using OSK.Maui.Screens.Models;
using OSK.Maui.Screens.Ports;

namespace OSK.Maui.Screens
{
    public static class ScreenServiceExtensions
    {
        #region Navigation

        public static Task NavigateToScreenAsync(this IScreenService screenService, string route,
            CancellationToken cancellationToken = default)
        {
            return screenService.NavigateToScreenAsync(new ScreenNavigation(route), cancellationToken);
        }

        public static async Task NavigateToScreenAsync<TParameters>(this IScreenService screenService, string route,
            TParameters parameters, CancellationToken cancellationToken = default)
        {
            var screen = await screenService.NavigateToScreenAsync(new ScreenNavigation(route), cancellationToken);
            if (screen is IScreen<TParameters> typedScreen)
            {
                await typedScreen.InitializeScreenAsync(parameters);
                return;
            }

            throw new InvalidNavigationException($"Unable to navigate to route {route} since the screen was expected to be of type {typeof(IScreen<TParameters>).FullName} but was {screen.GetType().FullName}.");
        }

        #endregion

        #region Popups

        public static async Task<object?> ShowPopupAsync<TPopup>(this IScreenService screenService, Page? parent = null,
            CancellationToken cancellationToken = default)
            where TPopup: IScreenPopup
        {
            var popupWaiter = await screenService.ShowPopupAsync<TPopup>(new PopupNavigation(parent), cancellationToken);
            return await popupWaiter.WaitForCloseAsync();
        }

        public static async Task<object?> ShowPopupAsync<TPopup, TParameters>(this IScreenService screenService, TParameters parameters,
             Page? parent = null, CancellationToken cancellationToken = default)
            where TPopup : IScreenPopup<TParameters>
        {
            var popupWaiter = await screenService.ShowPopupAsync<TPopup>(new PopupNavigation(parent), cancellationToken);
            if (popupWaiter.Popup is IScreenPopup<TParameters> typedPopup)
            {
                await typedPopup.InitializePopupAsync(parameters);
                return await popupWaiter.WaitForCloseAsync();
            }

            throw new InvalidNavigationException($"Unable to show popup since the popup was expected to be of type {typeof(IScreenPopup<TParameters>).FullName} but was {popupWaiter.GetType().FullName}.");
        }

        #endregion
    }
}
