using Mopups.Pages;
using Mopups.Services;
using OSK.Maui.Screens.Models;
using PopupNavigation = OSK.Maui.Screens.Models.PopupNavigation;

namespace OSK.Maui.Screens.Mopups.Internal.Services
{
    internal class MopupsPopupProvider(IServiceProvider serviceProvider) : PopupProvider<PopupPage>(serviceProvider)
    {
        #region PopupHandlerProvider

        protected override ValueTask<PopupHandler> GetPopupHandlerAsync(PopupNavigation popupNavigation, 
            CancellationToken cancellationToken = default)
        {
            var popup = (PopupPage)ServiceProvider.GetRequiredService(popupNavigation.PopupType);
            return new ValueTask<PopupHandler>(new MopupsPopupHandler(MopupService.Instance, popup));
        }

        #endregion
    }
}
