using Microsoft.AspNetCore.Components;
using OSK.Maui.Screens.Blazor.Ports;
using OSK.Maui.Screens.Ports;

namespace OSK.Maui.Screens.Blazor;

public abstract class BlazorComponent : ComponentBase, IScreen
{
    #region Variables

    [Inject]
    public required IBlazorComponentProvider ComponentProvider { get; set; }

    #endregion

    #region Helpers

    protected override void OnInitialized()
    {
        base.OnInitialized();

        ComponentProvider.SetInitializedComponent(this);
    }

    #endregion
}
