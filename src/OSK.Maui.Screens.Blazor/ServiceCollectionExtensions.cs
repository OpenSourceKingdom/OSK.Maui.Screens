using Microsoft.Extensions.DependencyInjection.Extensions;
using OSK.Maui.Screens.Blazor.Internal.Services;
using OSK.Maui.Screens.Blazor.Ports;
using OSK.Maui.Screens.Ports;

namespace OSK.Maui.Screens.Blazor;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds blazor related screen handlers for navigation and popups
    /// </summary>
    /// <param name="services">The services to add to</param>
    /// <returns>The services for chaining</returns>
    public static IServiceCollection AddBlazorScreens(this IServiceCollection services)
    {
        // The Maui root deppendency container doesn't consider navigations as a separate scope 
        // and there will not generate scoped dependencies in the way we'd like for this provider to function
        // Due to this, we'll make this a singleton and manually reset the provider per request to the 
        // Blazor Screen Handler
        services.TryAddSingleton<IBlazorComponentProvider, BlazorComponentProvider>();

        services.AddBlazorPopup<BlazorPopupComponent>();
        services.TryAddTransient<BlazorScreenHandler>();
        services.TryAddTransient<BlazorPopupComponentPage>();

        return services;
    }

    /// <summary>
    /// Provides a way to add blazor ppopups that deviate from the library standard <see cref="BlazorPopupComponent"/>
    /// </summary>
    /// <typeparam name="TPopup">The blazor popup component type</typeparam>
    /// <param name="services">The services to add to</param>
    /// <returns>The services for chaining</returns>
    public static IServiceCollection AddBlazorPopup<TPopup>(this IServiceCollection services) 
        where TPopup: BlazorPopupComponent, IScreenPopup
    {
        services.AddPopupProvider<TPopup, BlazorScreenHandler>();

        return services;
    }
}
