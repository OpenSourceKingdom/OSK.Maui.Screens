using Microsoft.AspNetCore.Components;
using OSK.Maui.Screens.Blazor.Internal.Services;
using OSK.Maui.Screens.Ports;

namespace OSK.Maui.Screens.Blazor
{
    public static class MauiAppBuilderExtensions
    {
        public static MauiAppBuilder AddBlazorScreen<TScreen>(this MauiAppBuilder builder, string route)
            where TScreen: ComponentBase
        {
            builder.Services.AddScreen<TScreen, BlazorScreenHandler>(route);

            return builder;
        }

        public static MauiAppBuilder AddBlazorPopup<TPopup>(this MauiAppBuilder builder)
            where TPopup : ComponentBase, IScreenPopup
        {
            builder.Services.AddPopupProvider<TPopup, BlazorScreenHandler>();

            return builder;
        }
    }
}
