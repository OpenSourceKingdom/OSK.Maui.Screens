using OSK.Maui.Screens.Internal.Services;
using OSK.Maui.Screens.Ports;

namespace OSK.Maui.Screens
{
    public static class MauiAppBuilderExtensions
    {
        public static MauiAppBuilder AddPageScreen<TPage>(this MauiAppBuilder builder, string route) 
            where TPage : Page
        {
            builder.Services.AddScreen<TPage, PageScreenHandler>(route);

            return builder;
        }

        public static MauiAppBuilder AddPagePopup<TPage>(this MauiAppBuilder buiilder)
            where TPage : Page, IScreenPopup
        {
            buiilder.Services.AddPopupProvider<TPage, PageScreenHandler>();

            return buiilder;
        }
    }
}
