using OSK.Maui.Screens.Ports;

namespace OSK.Maui.Screens.Blazor;

public abstract class BlazorComponent<TParameters> : BlazorComponent, IScreen<TParameters>
{
    public abstract Task InitializeScreenAsync(TParameters parameters);
}
