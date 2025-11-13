using OSK.Maui.Screens.Models;
using OSK.Maui.Screens.Ports;

namespace OSK.Maui.Screens.Commands;

public class ScreenPopupCommand<TPopup, TParameters>(IScreenService screenService, 
    PopupNavigation navigation, TParameters parameters) : IScreenPopupCommand
    where TPopup : IScreenPopup<TParameters>
{
    #region IScreenPopupCommand

    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        _ = ExecuteAsync();
    }

    public Task<object?> ExecuteAsync()
    {
        return screenService.ShowPopupAsync<TPopup, TParameters>(parameters, navigation.ParentPage);
    }

    #endregion
}
