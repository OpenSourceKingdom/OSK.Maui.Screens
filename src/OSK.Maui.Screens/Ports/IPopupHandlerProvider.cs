namespace OSK.Maui.Screens.Ports
{
    public interface IPopupHandlerProvider
    {
        PopupHandler GetPopupHandler(Type popupType, Page? parentPage = null);
    }
}
