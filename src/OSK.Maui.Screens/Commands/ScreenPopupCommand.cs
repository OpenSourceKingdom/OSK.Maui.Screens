using OSK.Maui.Screens.Models;
using OSK.Maui.Screens.Ports;

namespace OSK.Maui.Screens.Commands
{
    public class ScreenPopupCommand(IScreenService screenService, PopupNavigation navigation) : IScreenPopupCommand
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

        public async Task<object?> ExecuteAsync()
        {
            var popupWaiter = await screenService.ShowPopupAsync(navigation);
            return await popupWaiter.WaitForCloseAsync();
        }

        #endregion
    }
}
