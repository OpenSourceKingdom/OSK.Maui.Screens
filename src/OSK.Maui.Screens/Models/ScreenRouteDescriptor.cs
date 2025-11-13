namespace OSK.Maui.Screens.Models;

public class ScreenRouteDescriptor(string route, Type screenHandlerType, Type screenType)
{
    public string Route => route;

    public Type ScreenHandlerType => screenHandlerType;

    public Type ScreenType => screenType;
}
