using OSK.Maui.Screens.Blazor.Models;

namespace OSK.Maui.Screens.Blazor.Ports;

public interface IBlazorPopupPageFactory
{
    Page CreatePopupPage(BlazorPopupPageParameters parameters);
}
