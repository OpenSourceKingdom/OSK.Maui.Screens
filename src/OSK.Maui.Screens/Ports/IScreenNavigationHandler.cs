namespace OSK.Maui.Screens.Ports
{
    public interface IScreenNavigationHandler
    {
        Task<object> NavigateToAsync(string route, Type screenType, CancellationToken cancellationToken = default);
    }
}
