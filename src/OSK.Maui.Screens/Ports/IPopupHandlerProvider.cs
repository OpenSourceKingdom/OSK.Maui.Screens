namespace OSK.Maui.Screens.Ports
{
    public interface IPopupHandlerProvider
    {
        ValueTask<PopupHandler> GetPopupHandlerAsync(Type popupType, Page? parentPage = null,
            CancellationToken cancellationToken = default);
    }
}
