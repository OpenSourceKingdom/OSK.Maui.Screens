namespace OSK.Maui.Screens.Ports
{
    public interface IScreenPopup<TParameters>: IScreenPopup
    {
        Task InitializePopupAsync(TParameters parameters);
    }
}
