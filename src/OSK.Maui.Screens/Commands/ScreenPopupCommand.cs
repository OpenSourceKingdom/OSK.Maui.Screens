using OSK.Maui.Screens.Models;
using OSK.Maui.Screens.Ports;

namespace OSK.Maui.Screens.Commands
{
    public class ScreenPopupCommand<TPopup>(IScreenService screenService, PopupNavigation navigation) : IScreenPopupCommand
        where TPopup : IScreenPopup
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
            return screenService.ShowPopupAsync<TPopup>(navigation.ParentPage);
        }

        #endregion
    }
}
