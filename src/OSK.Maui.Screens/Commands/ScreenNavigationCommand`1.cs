using OSK.Maui.Screens.Models;
using OSK.Maui.Screens.Ports;

namespace OSK.Maui.Screens.Commands
{
    public class ScreenNavigationCommand<TParameters>(IScreenService screenService, ScreenNavigation navigation,
         TParameters parameters) 
        : IScreenCommand
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
            return screenService.NavigateToScreenAsync(navigation.Route, parameters);
        }

        #endregion
    }
}
