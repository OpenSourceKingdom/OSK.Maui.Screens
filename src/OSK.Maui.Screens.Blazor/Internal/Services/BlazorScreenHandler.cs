using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebView.Maui;
using OSK.Maui.Screens.Blazor.Ports;
using OSK.Maui.Screens.Exceptions;
using OSK.Maui.Screens.Models;

namespace OSK.Maui.Screens.Blazor.Internal.Services
{
    internal class BlazorScreenHandler(IServiceProvider serviceProvider, IBlazorComponentProvider componentProvider)
        : ScreenHandler<ComponentBase>(serviceProvider)
    {
        #region ScreenHandler Overrides

        protected override async ValueTask<PopupHandler> GetPopupHandlerAsync(PopupDescriptor descriptor, Page? parentPage,
            CancellationToken cancellationToken = default)
        {
            if (Application.Current?.MainPage is null)
            {
                throw new ScreenPopupNavigationException("Unable to set Blazor component popup without a valid main page.");
            }

            componentProvider.Reset();

            var popupPage = ServiceProvider.GetRequiredService<BlazorPopupComponentPage>();
            popupPage.SetPopupType(descriptor.PopupType, parentPage ?? Application.Current.MainPage);

            var navigation = parentPage?.Navigation ?? Application.Current.MainPage.Navigation;
            await navigation.PushModalAsync(popupPage);

            var component = await componentProvider.AwaitComponentInitializationAsync();
            return new BlazorPopupComponentHandler((BlazorPopupComponent)component, navigation);
        }

        protected override async Task<ComponentBase> NavigateToScreenAsync(ScreenRouteDescriptor descriptor, CancellationToken cancellationToken)
        {
            if (Application.Current?.MainPage is not ContentPage contentPage
                || contentPage?.Content is not BlazorWebView)
            {
                throw new ScreenNavigationException("Unable to navigate to blazor component when main page is not set to a content page with a blazor web view.");
            }

            componentProvider.Reset();

            var navigationManager = ServiceProvider.GetRequiredService<NavigationManager>();
            navigationManager.NavigateTo(descriptor.Route);

            return await componentProvider.AwaitComponentInitializationAsync();
        }

        #endregion
    }
}
