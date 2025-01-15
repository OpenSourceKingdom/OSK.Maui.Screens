using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mopups.Interfaces;
using Mopups.Pages;

namespace OSK.Maui.Screens.Mopups.Internal
{
    internal class MopupsPopupHandler(IPopupNavigation navigation, PopupPage popup) : PopupHandler
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
