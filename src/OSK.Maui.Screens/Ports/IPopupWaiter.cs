namespace OSK.Maui.Screens.Ports
{
    public interface IPopupWaiter
    {
        IScreenPopup Popup { get; }

        Task<object?> WaitForCloseAsync();
    }
}
