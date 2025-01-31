﻿using Mopups.Interfaces;
using Mopups.Pages;
using OSK.Maui.Screens.Ports;

namespace OSK.Maui.Screens.Mopups.Internal
{
    internal class MopupsPopupHandler(IPopupNavigation navigation, PopupPage popup) : PopupHandler((IScreenPopup)popup)
    {
        #region Variables

        private readonly TaskCompletionSource<object?> _taskCompletionSource = new();

        #endregion

        #region PopupHandler Overrides

        public override async Task CloseAsync(object? result = null)
        {
            _taskCompletionSource.TrySetResult(result);
            await navigation.PopAsync();
        }

        public override async Task<object?> WaitForCloseAsync()
        {
            await navigation.PushAsync(popup);
            return _taskCompletionSource.Task;
        }

        #endregion
    }
}
