namespace OSK.Maui.Screens.Ports
{
    public interface IPopupHandler
    {
        Task CloseAsync(object? result = null);
    }
}
