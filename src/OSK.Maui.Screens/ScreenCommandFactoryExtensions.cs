using OSK.Maui.Screens.Models;
using OSK.Maui.Screens.Ports;

namespace OSK.Maui.Screens
{
    public static class ScreenCommandFactoryExtensions
    {
        public static IScreenCommand CreateNavigationCommand(this IScreenCommandFactory factory, string route)
            => factory.CreateNavigationCommand(new ScreenNavigation(route));

        public static IScreenCommand CreateNavigationCommand<TParameters>(this IScreenCommandFactory factory, string route,
            TParameters parameters)
            => factory.CreateNavigationCommand(new ScreenNavigation(route), parameters);

        public static IScreenPopupCommand CreatePopupCommand<TPopup>(this IScreenCommandFactory factory, Page? parentPage = null)
            where TPopup : IScreenPopup
            => factory.CreatePopupCommand<TPopup>(new PopupNavigation(parentPage));

        public static IScreenPopupCommand CreatePopupCommand<TPopup, TParameters>(this IScreenCommandFactory factory,
            TParameters parameters, Page? parentPage = null)
            where TPopup : IScreenPopup<TParameters>
            => factory.CreatePopupCommand<TPopup, TParameters>(new PopupNavigation(parentPage), parameters);
    }
}
