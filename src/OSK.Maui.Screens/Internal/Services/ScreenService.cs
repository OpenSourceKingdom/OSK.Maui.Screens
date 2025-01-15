using OSK.Maui.Screens.Models;
using OSK.Maui.Screens.Ports;

namespace OSK.Maui.Screens.Internal.Services
{
    internal class ScreenService(IEnumerable<ScreenRouteDescriptor> routeDescriptors,
        IEnumerable<PopupDescriptor> popupDescriptors, IServiceProvider serviceProvider) : IScreenService
    {
        #region IScreenService

        public async Task NavigateToScreenAsync(ScreenNavigation navigation, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(navigation);
            ArgumentException.ThrowIfNullOrWhiteSpace(navigation?.Route);

            var routeDescriptor = GetRouteDesriptorOrThrow(navigation.Route);
            var screenNavigationHandler = (IScreenNavigationHandler)serviceProvider.GetRequiredService(routeDescriptor.ScreenHandlerType);

            await screenNavigationHandler.NavigateToAsync(navigation.Route, routeDescriptor.ScreenType, cancellationToken);
        }

        public async Task<object?> OpenPopupAsync<TPopup>(PopupNavigation navigation, CancellationToken cancellationToken = default) 
            where TPopup : IScreenPopup
        {
            ArgumentNullException.ThrowIfNull(navigation);

            var popupDescriptor = GetPopupDescriptorOrThrowAsync(typeof(TPopup));
            var popupHandlerProvider = (IPopupHandlerProvider)serviceProvider.GetRequiredService(popupDescriptor.HandlerProviderType);
            var popupHandler = await popupHandlerProvider.GetPopupHandlerAsync(popupDescriptor.PopupType, navigation.ParentPage);
            
            return await popupHandler.WaitForCloseAsync();
        }

        #endregion

        #region Helpers

        private ScreenRouteDescriptor GetRouteDesriptorOrThrow(string route)
        {
            var routeDescriptor = routeDescriptors.FirstOrDefault(descriptor => string.Equals(route, descriptor.Route, StringComparison.OrdinalIgnoreCase));
            return routeDescriptor is null
                ? throw new InvalidOperationException($"The provided route {route} did not match with a known route. Ensure a route descriptor has been added to the DI container for navigation.")
                : routeDescriptor;
        }

        private PopupDescriptor GetPopupDescriptorOrThrowAsync(Type popupType)
        {
            var popupDescriptor = popupDescriptors.FirstOrDefault(descriptor => descriptor.PopupType == popupType);
            return popupDescriptor is null
                ? throw new InvalidOperationException($"The provided popup type {popupType.FullName} does not have a valid popup context provider. Ensure an associated context provider has been added to the DI container for the popup.")
                : popupDescriptor;
        }

        #endregion
    }
}
