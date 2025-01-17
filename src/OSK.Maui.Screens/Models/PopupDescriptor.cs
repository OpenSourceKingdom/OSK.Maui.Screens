namespace OSK.Maui.Screens.Models
{
    public class PopupDescriptor(Type popupType, Type popupHandlerProviderType)
    {
        public Type PopupType => popupType;

        public Type HandlerProviderType => popupHandlerProviderType;
    }
}
