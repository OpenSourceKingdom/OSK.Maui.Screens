using Microsoft.AspNetCore.Components;
using OSK.Maui.Screens.Blazor.Ports;

namespace OSK.Maui.Screens.Blazor.Internal.Services;

/// <summary>
/// Provides a mechanism to get a <see cref="ComponentBase"/> after it has been initialized since there is no other direct
/// way to get the component
/// </summary>
internal class BlazorComponentProvider : IBlazorComponentProvider
{
    #region Variables

    private TaskCompletionSource<BlazorComponent> _taskCompletionSource = new();

    #endregion

    #region IBlazorComponentProvider

    public void Reset()
    {
        _taskCompletionSource = new();
    }

    public Task<BlazorComponent> AwaitComponentInitializationAsync()
    {
        return _taskCompletionSource.Task;
    }

    public void SetInitializedComponent(BlazorComponent component)
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
