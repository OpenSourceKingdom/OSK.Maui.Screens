namespace OSK.Maui.Screens.Internal
{
    internal class PopupDescriptor(Type popupType, Type popupHandlerProviderType)
    {
        public Type PopupType => popupType;

        public Type HandlerProviderType => popupHandlerProviderType;
    }
}
