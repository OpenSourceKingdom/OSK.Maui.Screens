using Microsoft.AspNetCore.Components;
using OSK.Maui.Screens.Blazor.Ports;

namespace OSK.Maui.Screens.Blazor.Internal.Services
{
    internal class BlazorComponentProvider : IBlazorComponentProvider
    {
        #region Variables

        private TaskCompletionSource<ComponentBase> _taskCompletionSource = new();

        #endregion

        #region IBlazorComponentProvider

        public void Reset()
        {
            _taskCompletionSource = new();
        }

        public Task<ComponentBase> AwaitComponentInitializationAsync()
        {
            return _taskCompletionSource.Task;
        }

        public void SetInitializedComponent(ComponentBase component)
        {
            if (_taskCompletionSource.Task.IsCompleted)
            {
                return;
            }

            ArgumentNullException.ThrowIfNull(component);
            _taskCompletionSource?.SetResult(component);
        }

        #endregion
    }
}
