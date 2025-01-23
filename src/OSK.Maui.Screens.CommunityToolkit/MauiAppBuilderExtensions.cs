using CommunityToolkit.Maui.Views;
using Microsoft.Extensions.DependencyInjection.Extensions;
using OSK.Maui.Screens.CommunityToolkit.Internal.Services;
using OSK.Maui.Screens.Ports;

namespace OSK.Maui.Screens.CommunityToolkit
{
    public static class MauiAppBuilderExtensions
    {
        /// <summary>
        /// Adds community toolkit related screen popup handling
        /// </summary>
        /// <param name="builder">The maui app builder to add to</param>
        /// <returns>The builder fo rchaining</returns>
        public static MauiAppBuilder AddCommunityScreens(this MauiAppBuilder builder)
        {
            builder.Services.TryAddTransient<CommunityToolkitPopupProvider>();
            builder.AddCommunityPopup<CommunityPopup>();

            return builder;
        }

        /// <summary>
        /// Adds a custom community popup type that deviates from the standard <see cref="CommunityPopup"/>
        /// </summary>
        /// <typeparam name="TPopup">The community toolkit popup type</typeparam>
        /// <param name="builder">The builder to add to</param>
        /// <returns>The builder for chaining</returns>
        public static MauiAppBuilder AddCommunityPopup<TPopup>(this MauiAppBuilder builder)
            where TPopup: Popup, IScreenPopup
        {
            builder.Services.AddPopupProvider<TPopup, CommunityToolkitPopupProvider>();

            return builder;
        }
    }
}
