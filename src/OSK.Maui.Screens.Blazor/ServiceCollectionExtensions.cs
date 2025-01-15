using Microsoft.Extensions.DependencyInjection.Extensions;
using OSK.Maui.Screens.Blazor.Internal.Services;
using OSK.Maui.Screens.Blazor.Ports;

namespace OSK.Maui.Screens.Blazor
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBlazorScreens(this IServiceCollection services)
        {
            services.TryAddScoped<IBlazorComponentProvider, BlazorComponentProvider>();

            return services;
        }
    }
}
