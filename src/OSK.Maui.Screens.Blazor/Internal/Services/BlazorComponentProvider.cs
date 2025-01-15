using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using OSK.Maui.Screens.Blazor.Ports;

namespace OSK.Maui.Screens.Blazor.Internal.Services
{
    internal class BlazorComponentProvider : IBlazorComponentProvider
    {
        #region Variables

        private readonly TaskCompletionSource<ComponentBase> _taskCompletionSource = new();

        #endregion

        #region IBlazorComponentProvider

        public Task<ComponentBase> AwaitComponentInitializationAsync()
        {
            return _taskCompletionSource.Task;
        }

        public void SetInitializedComponent(ComponentBase component)
        {
            ArgumentNullException.ThrowIfNull(component);

            _taskCompletionSource?.SetResult(component);
        }

        #endregion
    }
}
