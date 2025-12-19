using OSK.Maui.Screens.Blazor.Models;

namespace OSK.Maui.Screens.Blazor.Ports;

public interface IBlazorPopupComponentPage
{
    Page SetPopup(BlazorPopupPageParameters parameters);
}
