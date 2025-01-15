using OSK.Maui.Screens.Internal;
using OSK.Maui.Screens.Internal.Services;
using OSK.Maui.Screens.Ports;

namespace OSK.Maui.Screens
{
    public static class ServiceCollectionExtensions
    {
        #region Screen Services

        public static IServiceCollection AddScreenNavigation(this IServiceCollection services)
        {
            services.AddTransient<IScreenService, ScreenService>();

            return services;
        }

        #endregion

        #region Integrations

        public static IServiceCollection AddScreen<TScreen, TScreenNavigation>(this IServiceCollection services, string route)
            where TScreenNavigation : IScreenNavigationHandler
        {
            services.AddTransient(_ => new ScreenRouteDescriptor(route,
                screenHandlerType: typeof(TScreenNavigation),
                screenType: typeof(TScreen)));

            return services;
        }

        public static IServiceCollection AddPopupProvider<TPopupType, TProviderType>(this IServiceCollection services)
            where TPopupType : IScreenPopup
            where TProviderType : IPopupHandlerProvider
        {
            services.AddTransient(_ => new PopupDescriptor(typeof(TPopupType), typeof(TProviderType)));

            return services;
        }

        #endregion
    }
}
