using CommunityToolkit.Maui.Views;
using Microsoft.Extensions.DependencyInjection;

namespace OSK.Maui.Screens.CommunityToolkit.Internal.Services
{
    internal class CommunityToolkitPopupProvider(IServiceProvider serviceProvider) : PopupHandlerProvider<Popup>(serviceProvider)
    {
        #region PopupHandlerProvider

        protected override ValueTask<PopupHandler> GetPopupHandlerAsync(Page? parentPage, Type popupType, CancellationToken cancellationToken)
        {
            var popup = (Popup)ServiceProvider.GetRequiredService(popupType);
            parentPage ??= Shell.Current.Window.Page ?? Application.Current?.MainPage
                ?? throw new InvalidOperationException("Unable to show CommunityToolkit Popup without a valid parent page.");

            return new ValueTask<PopupHandler>(new CommunityToolkitPopupHandler(popup, parentPage));
        }

        #endregion
    }
}
