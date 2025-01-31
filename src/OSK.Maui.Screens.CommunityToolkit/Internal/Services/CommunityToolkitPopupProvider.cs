﻿using CommunityToolkit.Maui.Views;
using OSK.Maui.Screens.Models;

namespace OSK.Maui.Screens.CommunityToolkit.Internal.Services
{
    internal class CommunityToolkitPopupProvider(IServiceProvider serviceProvider) : PopupProvider<Popup>(serviceProvider)
    {
        #region PopupHandlerProvider

        protected override ValueTask<PopupHandler> GetPopupHandlerAsync(PopupNavigation popupNavigation, CancellationToken cancellationToken)
        {
            var popup = (Popup)ServiceProvider.GetRequiredService(popupNavigation.PopupType);
            var parentPage = popupNavigation.ParentPage ?? Shell.Current.Window.Page ?? Application.Current?.MainPage
                ?? throw new InvalidOperationException("Unable to show CommunityToolkit Popup without a valid parent page.");

            return new ValueTask<PopupHandler>(new CommunityToolkitPopupHandler(popup, parentPage));
        }

        #endregion
    }
}
