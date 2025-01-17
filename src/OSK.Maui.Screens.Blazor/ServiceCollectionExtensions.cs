using Microsoft.Extensions.DependencyInjection.Extensions;
using OSK.Maui.Screens.Blazor.Internal.Services;
using OSK.Maui.Screens.Blazor.Ports;

namespace OSK.Maui.Screens.Blazor
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBlazorScreens(this IServiceCollection services)
        {
            services.TryAddSingleton<IBlazorComponentProvider, BlazorComponentProvider>();
            services.TryAddTransient<BlazorScreenHandler>();
            services.TryAddTransient<BlazorPopupComponentPage>();

            return services;
        }
    }
}
