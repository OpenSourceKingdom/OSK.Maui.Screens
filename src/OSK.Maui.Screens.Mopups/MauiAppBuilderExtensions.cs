using Mopups.Pages;
using OSK.Maui.Screens.Mopups.Internal.Services;
using OSK.Maui.Screens.Ports;

namespace OSK.Maui.Screens.Mopups
{
    public static class MauiAppBuilderExtensions
    {
        public static MauiAppBuilder AddMopupsPopup<TPopup>(this MauiAppBuilder builder)
            where TPopup : PopupPage, IScreenPopup
        {
            builder.Services.AddPopupProvider<TPopup, MopupsPopupProvider>();

            return builder;
        }
    }
}
