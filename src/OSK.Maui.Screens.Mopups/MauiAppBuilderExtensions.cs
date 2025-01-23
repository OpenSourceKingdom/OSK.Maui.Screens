using Microsoft.Extensions.DependencyInjection.Extensions;
using Mopups.Pages;
using OSK.Maui.Screens.Mopups.Internal.Services;
using OSK.Maui.Screens.Ports;

namespace OSK.Maui.Screens.Mopups
{
    public static class MauiAppBuilderExtensions
    {
        /// <summary>
        /// Add Mopup related screen popup handlers to the builder
        /// </summary>
        /// <param name="builder">The builder to add to</param>
        /// <returns>The builder for chaining</returns>
        public static MauiAppBuilder AddMopupsScreens(this MauiAppBuilder builder)
        {
            builder.Services.TryAddTransient<MopupsPopupProvider>();
            builder.AddMopupsPopup<MopupPopup>();

            return builder;
        }

        /// <summary>
        /// Adds mpopup related popup types that deviate from the standard <see cref="MopupPopup"/>
        /// </summary>
        /// <typeparam name="TPopup">The mopup popup type</typeparam>
        /// <param name="builder">The builder to add to</param>
        /// <returns>The builder for chaining</returns>
        public static MauiAppBuilder AddMopupsPopup<TPopup>(this MauiAppBuilder builder)
            where TPopup : IScreenPopup
        {
            builder.Services.AddPopupProvider<TPopup, MopupsPopupProvider>();

            return builder;
        }
    }
}
