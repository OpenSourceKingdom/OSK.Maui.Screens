namespace OSK.Maui.Screens.Models;

public class PopupDescriptor(Type popupType, Type popupProviderType)
{
    public Type PopupType => popupType;

    public Type PopupProviderType => popupProviderType;
}
