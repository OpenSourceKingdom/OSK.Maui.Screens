using OSK.Maui.Screens.Ports;

namespace OSK.Maui.Screens.Blazor
{
    public abstract class BlazorPopupComponent<T> : BlazorPopupComponent, IScreenPopup<T>
    {
        public abstract Task InitializePopupAsync(T parameters);
    }
}
