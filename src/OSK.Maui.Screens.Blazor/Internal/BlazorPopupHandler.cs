using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using OSK.Maui.Screens.Blazor.Ports;

namespace OSK.Maui.Screens.Blazor.Internal
{
    internal class BlazorPopupHandler(IBlazorComponentProvider componentProvider, INavigation navigation) : PopupHandler
    {
        #region Variables

        private readonly TaskCompletionSource<object?> _taskCompletionSource = new();

        #endregion

        public override Task CloseAsync(object? result = null)
        {
            _taskCompletionSource.TrySetResult(result);

            return MainThread.IsMainThread
                ? navigation.PopModalAsync()
                : MainThread.InvokeOnMainThreadAsync(navigation.PopModalAsync);
        }

        public override async Task<object?> WaitForCloseAsync()
        {
            await componentProvider.AwaitComponentInitializationAsync();
            return _taskCompletionSource.Task;
        }
    }
}
