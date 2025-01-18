using OSK.Maui.Screens.Commands;
using OSK.Maui.Screens.Models;
using OSK.Maui.Screens.Ports;

namespace OSK.Maui.Screens.Internal.Services
{
    internal class ScreenCommandFactory(IServiceProvider serviceProvider) : IScreenCommandFactory
    {
        #region IScreenCommandFactory

        public IScreenCommand CreateNavigationCommand(ScreenNavigation navigation)
        {
            ArgumentNullException.ThrowIfNull(navigation);

            return ActivatorUtilities.CreateInstance<ScreenNavigationCommand>(serviceProvider, navigation);
        }

        public IScreenCommand CreateNavigationCommand<TParameters>(ScreenNavigation navigation, TParameters parameters)
        {
            ArgumentNullException.ThrowIfNull(navigation);
            ArgumentNullException.ThrowIfNull(parameters);

            return ActivatorUtilities.CreateInstance<ScreenNavigationCommand<TParameters>>(serviceProvider, navigation, parameters);
        }

        public IScreenPopupCommand CreatePopupCommand<TPopup>(PopupNavigation navigation) 
            where TPopup : IScreenPopup
        {
            ArgumentNullException.ThrowIfNull(navigation);

            return ActivatorUtilities.CreateInstance<ScreenPopupCommand<TPopup>>(serviceProvider, navigation);
        }

        public IScreenPopupCommand CreatePopupCommand<TPopup, TParameters>(PopupNavigation navigation, TParameters parameters) 
            where TPopup : IScreenPopup<TParameters>
        {
            ArgumentNullException.ThrowIfNull(navigation);
            ArgumentNullException.ThrowIfNull(parameters);

            return ActivatorUtilities.CreateInstance<ScreenPopupCommand<TPopup, TParameters>>(serviceProvider, navigation, parameters);
        }

        #endregion
    }
}
