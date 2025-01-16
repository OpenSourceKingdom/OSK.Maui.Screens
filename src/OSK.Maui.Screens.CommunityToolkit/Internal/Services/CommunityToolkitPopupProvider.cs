using CommunityToolkit.Maui.Views;

namespace OSK.Maui.Screens.CommunityToolkit.Internal.Services
{
    internal class CommunityToolkitPopupProvider(IServiceProvider serviceProvider) : PopupHandlerProvider<Popup>(serviceProvider)
    {
        #region PopupHandlerProvider

        protected override PopupHandler GetPopupHandler(Page? parentPage, Type popupType)
        {
            var popup = (Popup)ServiceProvider.GetRequiredService(popupType);
            parentPage ??= Shell.Current.Window.Page ?? Application.Current?.MainPage
                ?? throw new InvalidOperationException("Unable to show CommunityToolkit Popup without a valid parent page.");

            return new CommunityToolkitPopupHandler(popup, parentPage);
        }

        #endregion
    }
}
