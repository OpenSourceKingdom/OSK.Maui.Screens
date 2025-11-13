using OSK.Maui.Screens.Ports;

namespace OSK.Maui.Screens.Internal;

internal class PagePopupHandler(INavigation navigation, Page popup) : PopupHandler((IScreenPopup)popup)
{
    #region Variables

    private readonly TaskCompletionSource<object?> _taskCompletionSource = new();

    #endregion

    #region PopupHandler Overrides

    public override Task CloseAsync(object? result = null)
    {
        _taskCompletionSource.TrySetResult(result);

        return MainThread.IsMainThread
            ? navigation.PopModalAsync()
            : MainThread.InvokeOnMainThreadAsync(navigation.PopModalAsync);
    }

    public override async Task<object?> WaitForCloseAsync()
    {
        await navigation.PushModalAsync(popup);
        return _taskCompletionSource.Task;
    }

    #endregion
}
