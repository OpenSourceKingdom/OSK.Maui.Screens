using OSK.Maui.Screens.Blazor.Models;
using OSK.Maui.Screens.Blazor.Ports;

namespace OSK.Maui.Screens.Blazor.PopupPage.Internal.Services;

internal class BlazorPopupComponentPageFactory(IServiceProvider provider) : IBlazorPopupPageFactory
{
    #region IBlazorPopupPageFactory

    public Page CreatePopupPage(BlazorPopupPageParameters parameters)
    {
        var page = provider.GetRequiredService<IBlazorPopupComponentPage>();
        return page.SetPopup(parameters);
    }

    #endregion
}
