using Microsoft.Extensions.DependencyInjection.Extensions;
using OSK.Maui.Screens.Blazor.PopupPage.Options;
using OSK.Maui.Screens.Blazor.Ports;

namespace OSK.Maui.Screens.Blazor.PopupPage;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection UseBlazorPopupPage(this IServiceCollection services, Action<BlazorPopupPageOptions> configuration)
    {
        services.TryAddTransient<IBlazorPopupComponentPage, BlazorWebViewPopupComponentPage>();

        services.Configure(configuration);

        return services;
    }
}
