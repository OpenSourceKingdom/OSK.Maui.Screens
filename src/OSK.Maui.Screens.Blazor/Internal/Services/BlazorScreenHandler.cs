using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebView.Maui;
using OSK.Maui.Screens.Blazor.Ports;

namespace OSK.Maui.Screens.Blazor.Internal.Services
{
    internal class BlazorScreenHandler(IServiceProvider serviceProvider, IBlazorComponentProvider componentProvider)
        : ScreenHandler<ComponentBase>(serviceProvider)
    {
        #region ScreenHandler Overrides

        protected override async ValueTask<PopupHandler> GetPopupHandlerAsync(Page? parentPage, Type popupType,
            CancellationToken cancellationToken = default)
        {
            if (Application.Current?.MainPage is null)
            {
                throw new InvalidOperationException("Unable to set Blazor component popup without a valid main page.");
            }

            var popupPage = ServiceProvider.GetRequiredService<BlazorPopupComponentPage>();
            popupPage.SetPopupType(popupType);

            var component = await componentProvider.AwaitComponentInitializationAsync();
            return new BlazorPopupComponentHandler((BlazorPopupComponent) component, ServiceProvider.GetRequiredService<INavigation>());
        }

        protected override async Task<ComponentBase> NavigateToScreenAsync(string route, Type screenType, CancellationToken cancellationToken)
        {
            if (Application.Current?.MainPage is not ContentPage contentPage
                || contentPage?.Content is not BlazorWebView)
            {
                throw new NavigationException("Unable to navigate to blazor component when main page is not set to a content page with a blazor web view.");
            }

            var navigationManager = ServiceProvider.GetRequiredService<NavigationManager>();
            navigationManager.NavigateTo(route);

            return await componentProvider.AwaitComponentInitializationAsync();
        }

        #endregion
    }
}
