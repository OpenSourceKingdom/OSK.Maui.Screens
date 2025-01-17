using OSK.Maui.Screens.Internal.Services;
using OSK.Maui.Screens.Models;
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
            services.AddScreen(route, typeof(TScreen), typeof(TScreenNavigation));

            return services;
        }

        public static IServiceCollection AddScreen(this IServiceCollection services, string route, Type screenType, 
            Type navigationHandlerType)
        {
            if (!navigationHandlerType.IsAssignableTo(typeof(IScreenNavigationHandler)))
            {
                throw new InvalidOperationException($"The provided Navigation Handler type is not a valid navigation handler.");
            }

            services.AddTransient(_ => new ScreenRouteDescriptor(route,
                screenHandlerType: navigationHandlerType,
                screenType: screenType));

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
