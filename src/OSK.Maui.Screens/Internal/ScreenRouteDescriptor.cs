namespace OSK.Maui.Screens.Internal
{
    internal class ScreenRouteDescriptor(string route, Type screenHandlerType, Type screenType)
    {
        public string Route => route;

        public Type ScreenHandlerType => screenHandlerType;

        public Type ScreenType => screenType;
    }
}
