using OSK.Maui.Screens.Internal.Services;

namespace OSK.Maui.Screens
{
    public static class MauiAppBuilderExtensions
    {
        public static MauiAppBuilder AddScreenNavigation(this MauiAppBuilder builder)
        {
            builder.Services.AddScreenNavigation();

            return builder;
        }

        public static MauiAppBuilder AddPageScreen<TPage>(this MauiAppBuilder builder, string route) 
            where TPage : Page
        {
            builder.Services.AddScreen<TPage, PageScreenHandler>(route);

            return builder;
        }
    }
}
