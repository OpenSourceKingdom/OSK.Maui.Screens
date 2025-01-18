using Mopups.Pages;
using Mopups.Services;
using OSK.Maui.Screens.Models;

namespace OSK.Maui.Screens.Mopups.Internal.Services
{
    internal class MopupsPopupProvider(IServiceProvider serviceProvider) : PopupProvider<PopupPage>(serviceProvider)
    {
        #region PopupHandlerProvider

        protected override ValueTask<PopupHandler> GetPopupHandlerAsync(PopupDescriptor descriptor, Page? parentPage, 
            CancellationToken cancellationToken = default)
        {
            var popup = (PopupPage)ServiceProvider.GetRequiredService(descriptor.PopupType);
            return new ValueTask<PopupHandler>(new MopupsPopupHandler(MopupService.Instance, popup));
        }

        #endregion
    }
}
