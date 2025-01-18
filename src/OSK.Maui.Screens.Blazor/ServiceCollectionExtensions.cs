using Microsoft.Extensions.DependencyInjection.Extensions;
using OSK.Maui.Screens.Blazor.Internal.Services;
using OSK.Maui.Screens.Blazor.Ports;

namespace OSK.Maui.Screens.Blazor
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBlazorScreens(this IServiceCollection services)
        {
            // The Maui root deppendency container doesn't consider navigations as a separate scope 
            // and there will not generate scoped dependencies in the way we'd like for this provider to function
            // Due to this, we'll make this a singleton and manually reset the provider per request to the 
            // Blazor Screen Handler
            services.TryAddSingleton<IBlazorComponentProvider, BlazorComponentProvider>();

            services.TryAddTransient<BlazorScreenHandler>();
            services.TryAddTransient<BlazorPopupComponentPage>();

            return services;
        }
    }
}
