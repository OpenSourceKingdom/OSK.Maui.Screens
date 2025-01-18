using OSK.Maui.Screens.Models;
using OSK.Maui.Screens.Ports;

namespace OSK.Maui.Screens.Commands
{
    internal class ScreenNavigationCommand(IScreenService screenService, ScreenNavigation navigation) : IScreenCommand
    {
        #region IScreenCommand

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _ = ExecuteAsync();
        }

        public Task<object> ExecuteAsync()
        {
            return screenService.NavigateToScreenAsync(navigation);
        }

        #endregion
    }
}
