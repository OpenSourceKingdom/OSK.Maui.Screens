using CommunityToolkit.Maui.Views;
using OSK.Maui.Screens.CommunityToolkit.Internal.Services;
using OSK.Maui.Screens.Ports;

namespace OSK.Maui.Screens.CommunityToolkit
{
    public static class MauiAppBuilderExtensions
    {
        public static MauiAppBuilder AddCommunityPopup<TPopup>(this MauiAppBuilder builder)
            where TPopup : Popup, IScreenPopup
        {
            builder.Services.AddPopupProvider<TPopup, CommunityToolkitPopupProvider>();

            return builder;
        }
    }
}
