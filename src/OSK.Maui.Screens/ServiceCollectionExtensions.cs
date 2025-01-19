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
            services.AddTransient<IScreenCommandFactory, ScreenCommandFactory>();

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
            Routing.RegisterRoute(route, screenType);
            return services.AddScreenDescriptor(new ScreenRouteDescriptor(route, navigationHandlerType, screenType));
        }

        public static IServiceCollection AddScreenDescriptor(this IServiceCollection services, ScreenRouteDescriptor descriptor)
        {
            ArgumentNullException.ThrowIfNull(descriptor);
            if (!descriptor.ScreenHandlerType.IsAssignableTo(typeof(IScreenNavigationHandler)))
            {
                throw new InvalidOperationException($"The provided Navigation Handler type is not a valid navigation handler.");
            }

            services.AddTransient(_ => descriptor);
            return services;
        }

        public static IServiceCollection AddPopupProvider<TPopupType, TProviderType>(this IServiceCollection services)
            where TPopupType : IScreenPopup
            where TProviderType : IPopupProvider
        {
            return services.AddPopupProvider(new PopupDescriptor(typeof(TPopupType), typeof(TProviderType)));
        }

        public static IServiceCollection AddPopupProvider(this IServiceCollection services, PopupDescriptor descriptor)
        {
            ArgumentNullException.ThrowIfNull(descriptor);
            if (!descriptor.PopupType.IsAssignableTo(typeof(IScreenPopup)))
            {
                throw new InvalidOperationException($"The provided Navigation Handler type is not a valid navigation handler.");
            }

            services.AddTransient(_ => descriptor);
            return services;
        }

        #endregion
    }
}
