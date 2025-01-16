using Mopups.Pages;
using Mopups.Services;

namespace OSK.Maui.Screens.Mopups.Internal.Services
{
    internal class MopupsPopupProvider(IServiceProvider serviceProvider) : PopupHandlerProvider<PopupPage>(serviceProvider)
    {
        #region PopupHandlerProvider

        protected override PopupHandler GetPopupHandler(Page? parentPage, Type popupType)
        {
            var popup = (PopupPage)ServiceProvider.GetRequiredService(popupType);
            return new MopupsPopupHandler(MopupService.Instance, popup);
        }

        #endregion
    }
}
