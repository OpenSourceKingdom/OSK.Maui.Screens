using OSK.Maui.Screens.Ports;

namespace OSK.Maui.Screens.UnitTests.Helpers
{
    public class TestPopupHandler(IScreenPopup popup) : PopupHandler(popup)
    {
        public object? CloseResult { get; set; }

        public override Task CloseAsync(object? result = null)
        {
            return Task.CompletedTask;
        }

        public override Task<object?> WaitForCloseAsync()
        {
            return Task.FromResult(CloseResult);
        }
    }
}
