using Microsoft.AspNetCore.Components;
using OSK.Maui.Screens.Blazor.Internal.Services;
using OSK.Maui.Screens.Ports;

namespace OSK.Maui.Screens.Blazor;

public static class MauiAppBuilderExtensions
{
    public static MauiAppBuilder AddBlazorScreens(this MauiAppBuilder builder)
    {
        builder.Services.AddBlazorScreens();
        return builder;
    }

    public static MauiAppBuilder AddBlazorScreen(this MauiAppBuilder builder, string route, Type blazorScreenType)
    {
        if (!blazorScreenType.IsAssignableTo(typeof(BlazorComponent)))
        {
            throw new InvalidOperationException($"The provided blazor screen type, {blazorScreenType.FullName}, does not inherit {typeof(BlazorComponent).FullName}");
        }

        builder.Services.AddScreen(route, blazorScreenType, typeof(BlazorScreenHandler));

        return builder;
    }

    public static MauiAppBuilder AddBlazorScreen<TScreen>(this MauiAppBuilder builder, string route)
        where TScreen: ComponentBase
    {
        builder.Services.AddScreen<TScreen, BlazorScreenHandler>(route);

        return builder;
    }

    public static MauiAppBuilder AddBlazorPopupComponent<TPopup>(this MauiAppBuilder builder)
        where TPopup : ComponentBase, IScreenPopup
    {
        builder.Services.AddPopupProvider<TPopup, BlazorScreenHandler>();

        return builder;
    }
}
