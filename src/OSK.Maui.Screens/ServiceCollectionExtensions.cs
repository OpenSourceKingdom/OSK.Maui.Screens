using OSK.Maui.Screens.Internal.Services;
using OSK.Maui.Screens.Models;
using OSK.Maui.Screens.Ports;

namespace OSK.Maui.Screens
{
    public static class ServiceCollectionExtensions
    {
        #region Screen Services

        /// <summary>
        /// Adds the core screen navigation services that can handle the screen and popup navigation requests
        /// </summary>
        /// <param name="services">The services to add to</param>
        /// <returns>The services for chaining</returns>
        public static IServiceCollection AddScreenNavigation(this IServiceCollection services)
        {
            services.AddTransient<IScreenService, ScreenService>();
            services.AddTransient<IScreenCommandFactory, ScreenCommandFactory>();
            services.AddTransient<PageScreenHandler>();
            services.AddPagePopup<PagePopup>();

            return services;
        }

        #endregion

        #region Integrations

        /// <summary>
        /// Adds a popup descriptor that is based on MAUI Pages
        /// </summary>
        /// <typeparam name="TPopup">A popup of a page type</typeparam>
        /// <param name="services">The services to add to</param>
        /// <returns>The services for chaining</returns>
        public static IServiceCollection AddPagePopup<TPopup>(this IServiceCollection services)
            where TPopup : Page, IScreenPopup
        {
            services.AddPopupProvider<TPopup, PageScreenHandler>();

            return services;
        }

        /// <summary>
        /// Adds a screen, registering it to the given route and associating it to the provided navigation handler
        /// </summary>
        /// <typeparam name="TScreen">The screen type</typeparam>
        /// <typeparam name="TScreenNavigation">The navigation handler that is associated to screens of the provided type</typeparam>
        /// <param name="services">THe services to add to</param>
        /// <param name="route">The route the screen is assigned to</param>
        /// <returns>The services for chaining</returns>
        public static IServiceCollection AddScreen<TScreen, TScreenNavigation>(this IServiceCollection services, string route)
            where TScreenNavigation : IScreenNavigationHandler
        {
            services.AddScreen(route, typeof(TScreen), typeof(TScreenNavigation));

            return services;
        }

        /// <summary>
        /// Adds a screen, registering it to the given route and associating it to the provided navigation handler
        /// </summary>
        /// <param name="services">THe services to add to</param>
        /// <param name="route">The route the screen is assigned to</param>
        /// <param name="screenType">The type of screen that is displayed</param>
        /// <param name="navigationHandlerType">The navigation handler that handles trnasitions to the screen</param>
        /// <returns>The services for chaining</returns>
        public static IServiceCollection AddScreen(this IServiceCollection services, string route, Type screenType, 
            Type navigationHandlerType)
        {
            Routing.RegisterRoute(route, screenType);
            return services.AddScreenDescriptor(new ScreenRouteDescriptor(route, navigationHandlerType, screenType));
        }

        /// <summary>
        /// Adds a given screen descriptor the dependency container
        /// </summary>
        /// <param name="services">The services to add to</param>
        /// <param name="descriptor">A <see cref="ScreenRouteDescriptor"/> that describes all the required parts of a screen for appropriate navigation</param>
        /// <returns>The services for chaining</returns>
        /// <exception cref="InvalidOperationException">This is thrown when the descriptor is invalid (i.e. bad screen or navigation handler type)</exception>
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

        /// <summary>
        /// Adds a popup descriptor based on the provided types.
        /// </summary>
        /// <typeparam name="TPopupType">The popup object type</typeparam>
        /// <typeparam name="TProviderType">The popup provider type</typeparam>
        /// <param name="services">The services to add to</param>
        /// <returns>The services for chaining</returns>
        public static IServiceCollection AddPopupProvider<TPopupType, TProviderType>(this IServiceCollection services)
            where TPopupType : IScreenPopup
            where TProviderType : IPopupProvider
        {
            return services.AddPopupProvider(new PopupDescriptor(typeof(TPopupType), typeof(TProviderType)));
        }

        /// <summary>
        /// Adds a popup descriptor to the dependency container
        /// </summary>
        /// <param name="services">The services to add to</param>
        /// <param name="descriptor">The popup descriptor that describes all the required parts of a popup provider</param>
        /// <returns>The services for chaining</returns>
        /// <exception cref="InvalidOperationException"></exception>
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
