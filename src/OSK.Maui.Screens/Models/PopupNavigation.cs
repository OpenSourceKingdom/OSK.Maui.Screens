namespace OSK.Maui.Screens.Models;

public class PopupNavigation(Type popupType, Page? parentPage = null)
{
    public Type PopupType => popupType;

    public Page? ParentPage => parentPage;
}
