namespace OSK.Maui.Screens.Ports
{
    public interface IScreen<TParameters>: IScreen
    {
        Task InitializeScreenAsync(TParameters parameters);
    }
}
