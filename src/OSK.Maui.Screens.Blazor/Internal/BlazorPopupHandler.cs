namespace OSK.Maui.Screens.Blazor.Internal;

internal class BlazorPopupComponentHandler(BlazorPopupComponent component, INavigation navigation) : PopupHandler(component)
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

    public override Task<object?> WaitForCloseAsync()
    {
        return _taskCompletionSource.Task;
    }
}
