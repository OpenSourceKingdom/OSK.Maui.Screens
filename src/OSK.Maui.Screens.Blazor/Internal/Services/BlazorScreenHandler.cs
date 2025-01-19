using System.Numerics;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebView.Maui;
using OSK.Maui.Screens.Blazor.Models;
using OSK.Maui.Screens.Blazor.Ports;
using OSK.Maui.Screens.Exceptions;
using OSK.Maui.Screens.Models;

namespace OSK.Maui.Screens.Blazor.Internal.Services
{
    internal class BlazorScreenHandler(IServiceProvider serviceProvider, IBlazorComponentProvider componentProvider)
        : ScreenHandler<BlazorComponent>(serviceProvider)
    {
        #region ScreenHandler Overrides

        protected override async ValueTask<PopupHandler> GetPopupHandlerAsync(PopupNavigation popupNavigation,
            CancellationToken cancellationToken = default)
        {
            var parentPage = popupNavigation.ParentPage ?? Application.Current?.MainPage;
            if (parentPage is null)
            {
                throw new ScreenPopupNavigationException("Unable to set Blazor component popup without a valid main or parent page.");
            }

            componentProvider.Reset();

            var popupPage = ServiceProvider.GetRequiredService<BlazorPopupComponentPage>();

            var blazorNavigation = popupNavigation as BlazorPopupNavigation;
            var width = GetDimensionValue(blazorNavigation?.Width, (float)parentPage.Width);
            var height = GetDimensionValue(blazorNavigation?.Height, (float)parentPage.Height);
            var xTranslation = GetDimensionValue(blazorNavigation?.XTranslation, (float)parentPage.Width);
            var yTranslation = GetDimensionValue(blazorNavigation?.YTranslation, (float)parentPage.Height);

            popupPage.SetPopup(popupNavigation.PopupType, new Vector2(width, height), new Vector2(xTranslation, yTranslation));
            await parentPage.Navigation.PushModalAsync(popupPage);

            var component = await componentProvider.AwaitComponentInitializationAsync();
            return new BlazorPopupComponentHandler((BlazorPopupComponent)component, parentPage.Navigation);
        }

        protected override async Task<BlazorComponent> NavigateToScreenAsync(ScreenRouteDescriptor descriptor, CancellationToken cancellationToken)
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

        #region Helpers

        private float GetDimensionValue(float? requestedDimension, float parentDimension)
        {
            if (requestedDimension.HasValue)
            {
                return requestedDimension.Value > 1 
                    ? requestedDimension.Value 
                    : parentDimension * requestedDimension.Value;
            }

            return parentDimension / 2;
        }

        #endregion
    }
}
