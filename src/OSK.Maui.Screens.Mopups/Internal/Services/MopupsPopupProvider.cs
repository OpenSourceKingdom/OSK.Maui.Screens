using Microsoft.Extensions.DependencyInjection;
using Mopups.Pages;
using Mopups.Services;

namespace OSK.Maui.Screens.Mopups.Internal.Services
{
    internal class MopupsPopupProvider(IServiceProvider serviceProvider) : PopupHandlerProvider<PopupPage>(serviceProvider)
    {
        #region PopupHandlerProvider

        protected override ValueTask<PopupHandler> GetPopupHandlerAsync(Page? parentPage, Type popupType, CancellationToken cancellationToken)
        {
            var popup = (PopupPage)ServiceProvider.GetRequiredService(popupType);
            return new ValueTask<PopupHandler>(new MopupsPopupHandler(MopupService.Instance, popup));
        }

        #endregion
    }
}
