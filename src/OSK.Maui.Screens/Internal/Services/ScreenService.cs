using OSK.Maui.Screens.Exceptions;
using OSK.Maui.Screens.Models;
using OSK.Maui.Screens.Ports;

namespace OSK.Maui.Screens.Internal.Services
{
    internal class ScreenService(IEnumerable<ScreenRouteDescriptor> routeDescriptors,
        IEnumerable<PopupDescriptor> popupDescriptors, IServiceProvider serviceProvider) : IScreenService
    {
        #region IScreenService

        public async Task<object> NavigateToScreenAsync(ScreenNavigation navigation, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(navigation);
            ArgumentException.ThrowIfNullOrWhiteSpace(navigation?.Route);

            var routeDescriptor = GetRouteDesriptorOrThrow(navigation.Route);
            var screenNavigationHandler = (IScreenNavigationHandler)serviceProvider.GetRequiredService(routeDescriptor.ScreenHandlerType);

            return await screenNavigationHandler.NavigateToAsync(routeDescriptor, cancellationToken);
        }

        public async Task<IPopupWaiter> ShowPopupAsync<TPopup>(PopupNavigation navigation, CancellationToken cancellationToken = default) 
            where TPopup : IScreenPopup
        {
            ArgumentNullException.ThrowIfNull(navigation);

            var popupDescriptor = GetPopupDescriptorOrThrowAsync(typeof(TPopup));

            var popupHandlerProvider = (IPopupProvider)serviceProvider.GetRequiredService(popupDescriptor.PopupProviderType);
            var popupHandler = await popupHandlerProvider.GetPopupAsync(popupDescriptor, navigation.ParentPage);

            return popupHandler;
        }

        #endregion

        #region Helpers

        private ScreenRouteDescriptor GetRouteDesriptorOrThrow(string route)
        {
            var routeDescriptor = routeDescriptors.FirstOrDefault(descriptor => string.Equals(route, descriptor.Route, StringComparison.OrdinalIgnoreCase));
            return routeDescriptor is null
                ? throw new ScreenNavigationException($"The provided route {route} did not match with a known route. Ensure a route descriptor has been added to the DI container for navigation.")
                : routeDescriptor;
        }

        private PopupDescriptor GetPopupDescriptorOrThrowAsync(Type popupType)
        {
            var popupDescriptor = popupDescriptors.FirstOrDefault(descriptor => descriptor.PopupType == popupType);
            return popupDescriptor is null
                ? throw new ScreenNavigationException($"The provided popup type {popupType.FullName} does not have a valid popup context provider. Ensure an associated context provider has been added to the DI container for the popup.")
                : popupDescriptor;
        }

        #endregion
    }
}
